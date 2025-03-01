using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flow_view_database.Rating;

public class Rating
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public required Guid AspNetUserId { get; set; }
    [Required]
    public bool Like { get; set; }
    [Required]
    public DateTime LastUpdated { get; set; }
    [Required]
    [ForeignKey("Content")]
    public Guid ContentId { get; set; }
}
