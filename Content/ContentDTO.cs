using Microsoft.AspNetCore.Http;

namespace flow_view_database.Content;
public record ContentDTO(
    Guid Id, 
    Guid UserId,
    string Title, 
    string Description, 
    string Thumbnail, 
    string FilePath, 
    ContentType Type, 
    DateTime? ReleaseDate, 
    DateTime? LastUpadted,
    IFormFileCollection? Files);