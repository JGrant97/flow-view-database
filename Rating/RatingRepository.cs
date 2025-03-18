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

    public async Task<Rating> CreateAsync(Rating rating)
    {
        await _context.AddAsync(rating);
        await _context.SaveChangesAsync();
        return rating;
    }

    public int GetLikes(Guid contentId) =>
         _context.Rating.Where(x => x.ContentId == contentId && x.Like).Count();

    public int GetDislikes(Guid contentId) =>
        _context.Rating.Where(x => x.ContentId == contentId && !x.Like).Count();

    public async Task DeleteAsync(Guid id)
    {
        var rating = await _context.Rating.FindAsync(id);

        if (rating is null)
            throw new KeyNotFoundException("Rating not foumd.");

        _context.Rating.Remove(rating);
        await _context.SaveChangesAsync();
    }

    public IQueryable<Rating> Get() => 
        _context.Rating.AsQueryable();

    public async Task<Rating> GetAsync(Guid id)
    {
        var result = await _context.Rating.FindAsync(id);

        if (result is null)
            throw new KeyNotFoundException("Rating not foumd.");

        return result;
    }

    public async Task<Rating> UpdateAsync(Rating rating)
    {
        var ratingInDb = await _context.Rating.FindAsync(rating.Id);

        if (ratingInDb is null)
            throw new InvalidOperationException("Rating does not exist");

        ratingInDb.LastUpdated = DateTime.Now;
        ratingInDb.Like = rating.Like;

        await _context.SaveChangesAsync();
        return ratingInDb;
    }

    public async Task<Rating?> GetByContentIdAndUserIdAsync(Guid contentId, Guid userId) =>
        await _context.Rating.FirstOrDefaultAsync(x => x.ContentId == contentId && x.AspNetUserId == userId);    
}
