namespace flow_view_database.Rating;

public record CreateRatingDTO(Guid UserId, bool Like, Guid ContentId);
