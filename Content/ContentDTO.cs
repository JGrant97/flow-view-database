using Microsoft.AspNetCore.Http;

namespace flow_view_database.Content;
public class ContentDTO
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Thumbnail { get; set; }
    public required string FilePath { get; set; }
    public required ContentType Type { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public DateTime? LastUpadted { get; set; }
    public ICollection<Rating.Rating>? Ratings { get; }
    public IFormFileCollection? Files { get; set; }
}
