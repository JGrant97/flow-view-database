using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flow_view_database.Rating;
public class RatingRepository : IRatingRepository
{
    private ApplicationDbContext.ApplicationDbContext _context;

    public RatingRepository(ApplicationDbContext.ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Rating> CreateAsync(Rating rating, CancellationToken cancellationToken)
    {
        await _context.AddAsync(rating, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return rating;
    }

    public async Task<int> GetLikes(Guid contentId, CancellationToken cancellationToken) =>
         await _context.Rating.Where(x => x.ContentId == contentId && x.Like).CountAsync(cancellationToken);

    public async Task<int> GetDislikes(Guid contentId, CancellationToken cancellationToken) =>
        await _context.Rating.Where(x => x.ContentId == contentId && !x.Like).CountAsync(cancellationToken);

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var rating = await _context.Rating.FindAsync(id, cancellationToken);

        if (rating is null)
            throw new KeyNotFoundException("Rating not foumd.");

        _context.Rating.Remove(rating);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<Rating> Get() => 
        _context.Rating.AsQueryable();

    public async Task<Rating> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await _context.Rating.FindAsync(id, cancellationToken);

        if (result is null)
            throw new KeyNotFoundException("Rating not foumd.");

        return result;
    }

    public async Task<Rating> UpdateAsync(Rating rating, CancellationToken cancellationToken)
    {
        var ratingInDb = await _context.Rating.FindAsync(rating.Id, cancellationToken);

        if (ratingInDb is null)
            throw new InvalidOperationException("Rating does not exist");

        ratingInDb.LastUpdated = DateTime.Now;
        ratingInDb.Like = rating.Like;

        await _context.SaveChangesAsync(cancellationToken);
        return ratingInDb;
    }

    public async Task<Rating?> GetByContentIdAndUserIdAsync(Guid contentId, Guid userId, CancellationToken cancellationToken) =>
        await _context.Rating.FirstOrDefaultAsync(x => x.ContentId == contentId && x.UserId == userId, cancellationToken);    
}
