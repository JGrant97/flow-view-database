using System.ComponentModel.DataAnnotations;

namespace flow_view_database.Content;

public class Content
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public required string Title { get; set; }
    [Required]
    public required string Description { get; set; }
    [Required]
    public required string Thumbnail { get; set; }
    [Required]
    public required string FilePath { get; set; }
    [Required]
    public required ContentType Type { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public DateTime? LastUpadted { get; set; }
}
