using flow_view_database.Rating;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flow_view_database.Content;
public class ContentRepository : IContentRepository
{
    private ApplicationDbContext.ApplicationDbContext _context;

    public ContentRepository(ApplicationDbContext.ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Content> CreateAsync(Content content, CancellationToken cancellationToken)
    {
        await _context.Content.AddAsync(content);
        await _context.SaveChangesAsync(cancellationToken);
        return content;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var contextInDb = await _context.Content.FindAsync(id, cancellationToken);

        if (contextInDb is null)
            throw new KeyNotFoundException("Content does not found.");

        _context.Rating.RemoveRange(_context.Rating.Where(x => x.ContentId == id));
        _context.Content.Remove(contextInDb);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<ContentPreviewDTO>> FilterAsync(ContentFilterRequest request, CancellationToken cancellationToken)
    {
        var contentQuery = _context.Content
                .Where(x => request.UserIds == null || request.UserIds.Contains(x.UserId))
                .Where(x => request.Title == null || EF.Functions.Like(x.Title.ToLower(), $"%{request.Title.ToLower()}%"))
                .Where(x => request.MinDate == null || x.ReleaseDate >= request.MinDate)
                .Where(x => request.MaxDate == null || x.ReleaseDate <= request.MaxDate)
                .Where(x => request.Type.Contains(x.Type))
                .GroupJoin(_context.Rating, content => content.Id, rating => rating.ContentId,
                   (content, ratings) => new
                   {
                       Content = content,
                       Likes = ratings.Count(x => x.Like),
                       Dislikes = ratings.Count(x => !x.Like),
                       Views = 0
                   });

        var sortedContentQuery = request.Sort switch
        {
            ContentSort.Descending => request.SortType switch
            {
                ContentSortType.Date => contentQuery.OrderByDescending(x => x.Content.ReleaseDate),
                ContentSortType.Alphabetical => contentQuery.OrderByDescending(x => x.Content.Title),
                ContentSortType.Views => contentQuery.OrderByDescending(x => x.Views),
                ContentSortType.Likes => contentQuery.OrderByDescending(x => x.Likes),
                ContentSortType.Dislikes => contentQuery.OrderByDescending(x => x.Dislikes),
                _ => throw new InvalidOperationException(),
            },
            ContentSort.Ascending => request.SortType switch
            {
                ContentSortType.Date => contentQuery.OrderBy(x => x.Content.ReleaseDate),
                ContentSortType.Alphabetical => contentQuery.OrderBy(x => x.Content.Title),
                ContentSortType.Views => contentQuery.OrderBy(x => x.Views),
                ContentSortType.Likes => contentQuery.OrderBy(x => x.Likes),
                ContentSortType.Dislikes => contentQuery.OrderBy(x => x.Dislikes),
                _ => throw new InvalidOperationException(),
            },
            _ => throw new InvalidOperationException(),
        };

        return await sortedContentQuery
            .Skip(request.page > 0 ? request.pageSize * request.page : 0)
            .Take(request.pageSize)
            .Select(x => 
                new ContentPreviewDTO(
                    x.Content.Id,
                    x.Content.UserId,
                    x.Content.Title,
                    x.Content.Description,
                    x.Content.Thumbnail,
                    x.Content.FilePath,
                    x.Content.Type,
                    x.Content.ReleaseDate,
                    x.Likes,
                    x.Dislikes,
                    x.Views))
            .ToListAsync(cancellationToken);
    }

    public IQueryable<Content> Get() =>
        _context.Content.AsQueryable();

    public async Task<Content> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var context = await _context.Content.FindAsync(id, cancellationToken);

        if (context is null)
            throw new KeyNotFoundException("Content does not found.");

        return context;
    }

    public async Task<Content> UpdateAsync(Content content, CancellationToken cancellationToken)
    {
        var contextInDb = await _context.Content.FindAsync(content.Id);

        if (contextInDb is null)
            throw new KeyNotFoundException("Content does not found.");

        contextInDb.Title = content.Title;
        contextInDb.Description = content.Description;
        contextInDb.ReleaseDate = content.ReleaseDate;
        contextInDb.LastUpadted = DateTime.Now;
        contextInDb.FilePath = content.FilePath;
        contextInDb.Thumbnail = content.Thumbnail;
        contextInDb.Type = content.Type;

        await _context.Content.SingleAsync(cancellationToken);
        return contextInDb;
    }
}
