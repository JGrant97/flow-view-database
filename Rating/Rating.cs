using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flow_view_database.Rating;

public class Rating
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public required Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual ApplicationUser.ApplicationUser? User { get; set; }
    [Required]
    public bool Like { get; set; }
    [Required]
    public DateTime LastUpdated { get; set; }
    [Required]
    public required Guid ContentId { get; set; }
    [ForeignKey("ContentId")]
    public virtual Content.Content? Content { get; set; }
}
