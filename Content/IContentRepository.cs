using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flow_view_database.Content;
public interface IContentRepository
{
    IQueryable<Content> Get();
    Task<Content> GetAsync(Guid id);
    Task<Content> CreateAsync(Content content);
    Task<Content> UpdateAsync(Content content);
    Task DeleteAsync(Guid id);
}
