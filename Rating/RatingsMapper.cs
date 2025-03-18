namespace flow_view_database.Rating;

public static class RatingsMapper
{
    public static Rating MapToDBModel(this RatingDTO rating) =>
        new Rating()
        {
            Id = rating.Id,
            AspNetUserId = rating.AspNetUserId,
            ContentId = rating.ContentId,
            LastUpdated = rating.LastUpdated,
            Like = rating.Like,
        };

    public static List<Rating> MapToDBModel(this List<RatingDTO> rating) =>
       rating.Select(item => new Rating()
       {
           Id = item.Id,
           AspNetUserId = item.AspNetUserId,
           ContentId = item.ContentId,
           LastUpdated = item.LastUpdated,
           Like = item.Like,
       }).ToList();

    public static RatingDTO MapToDTO(this Rating rating) =>
        new RatingDTO(rating.Id, rating.AspNetUserId, rating.ContentId, rating.Like, rating.LastUpdated);

    public static List<RatingDTO> MapToDTO(this List<Rating> rating) =>
       rating.Select(item => new RatingDTO(item.Id, item.AspNetUserId, item.ContentId, item.Like, item.LastUpdated)).ToList();
}
