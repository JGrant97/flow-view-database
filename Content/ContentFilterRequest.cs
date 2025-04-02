
namespace flow_view_database.Content;

public record ContentFilterRequest(
    ICollection<Guid>? UserIds, 
    string? Title, 
    ICollection<ContentType> Type, 
    ICollection<string>? Tags, 
    DateTime? MinDate,
    DateTime? MaxDate, 
    int page,
    int pageSize,
    ContentSortType SortType, 
    ContentSort Sort);