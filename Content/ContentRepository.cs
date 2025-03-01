using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flow_view_database.Content;
public class ContentRepository : IContentRepository
{
    public Task<Content> CreateAsync(Content content)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Content> Get()
    {
        throw new NotImplementedException();
    }

    public Task<Content> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Content> UpdateAsync(Content content)
    {
        throw new NotImplementedException();
    }
}
