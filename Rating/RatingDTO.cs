using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flow_view_database.Rating;

public record RatingDTO(Guid Id, Guid AspNetUserId, Guid ContentId, bool Like, DateTime LastUpdated);