using flow_view_database.Rating;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flow_view_database.Content;
public interface IContentRepository
{
    IQueryable<Content> Get();
    Task<Content> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<Content> CreateAsync(Content content, CancellationToken cancellationToken);
    Task<Content> UpdateAsync(Content content, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<List<ContentPreviewDTO>> FilterAsync(ContentFilterRequest request, CancellationToken cancellationToken);
}
