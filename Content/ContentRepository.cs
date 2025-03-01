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

    public async Task<Content> CreateAsync(Content content)
    {
        await _context.Content.AddAsync(content);
        await _context.SaveChangesAsync();
        return content;
    }

    public async Task DeleteAsync(Guid id)
    {
        var contextInDb = await _context.Content.FindAsync(id);

        if (contextInDb is null)
            throw new KeyNotFoundException("Content does not found.");

        _context.Content.Remove(contextInDb);
        await _context.SaveChangesAsync();
    }

    public IQueryable<Content> Get() => 
        _context.Content.AsQueryable();

    public async Task<Content> GetAsync(Guid id)
    {
        var context = await _context.Content.FindAsync(id);

        if (context is null)
            throw new KeyNotFoundException("Content does not found.");

        return context;
    }

    public async Task<Content> UpdateAsync(Content content)
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

        await _context.Content.SingleAsync();
        return contextInDb;
    }
}
