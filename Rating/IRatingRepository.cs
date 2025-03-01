using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flow_view_database.Rating;
public interface IRatingRepository
{
    IQueryable<Rating> Get();
    Task<Rating> GetAsync(Guid id);
    Task<Rating> CreateAsync(Rating rating);
    Task<Rating> UpdateAsync(Rating rating);
    Task DeleteAsync(Guid id);
}
