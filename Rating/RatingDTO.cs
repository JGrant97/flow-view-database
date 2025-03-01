using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flow_view_database.Rating;

public class RatingDTO
{
    public Guid Id { get; set; }
    public required Guid AspNetUserId { get; set; }
    public required bool Like { get; set; }
    public DateTime LastUpdated { get; set; }
    public required Guid ContentId { get; set; }
}
