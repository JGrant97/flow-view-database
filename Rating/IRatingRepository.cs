using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flow_view_database.Rating;
public interface IRatingRepository
{
    IQueryable<Rating> Get();
    Task<Rating> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<Rating?> GetByContentIdAndUserIdAsync(Guid contentId, Guid userId, CancellationToken cancellationToken);
    Task<Rating> CreateAsync(Rating rating, CancellationToken cancellationToken);
    Task<Rating> UpdateAsync(Rating rating, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<int> GetLikes(Guid contentId, CancellationToken cancellationToken);
    Task<int> GetDislikes(Guid contentId, CancellationToken cancellationToken);
}
