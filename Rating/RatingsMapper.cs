namespace flow_view_database.Rating;

public static class RatingsMapper
{
    public static Rating MapToDBModel(this RatingDTO rating) =>
        new Rating()
        {
            Id = rating.Id is not null ? (Guid)rating.Id : Guid.NewGuid(),
            UserId = rating.UserId,
            ContentId = rating.ContentId,
            LastUpdated = rating.LastUpdated is not null ? (DateTime)rating.LastUpdated : DateTime.Now,
            Like = rating.Like,
        };

    public static Rating MapToDBModel(this CreateRatingDTO rating) =>
      new Rating()
      {
          Id = Guid.NewGuid(),
          UserId = rating.UserId,
          ContentId = rating.ContentId,
          LastUpdated = DateTime.Now,
          Like = rating.Like,
      };

    public static List<Rating> MapToDBModel(this List<RatingDTO> rating) =>
       rating.Select(item => new Rating()
       {
           Id = item.Id is not null ? (Guid)item.Id : Guid.NewGuid(),
           UserId = item.UserId,
           ContentId = item.ContentId,
           LastUpdated = item.LastUpdated is not null ? (DateTime)item.LastUpdated : DateTime.Now,
           Like = item.Like,
       }).ToList();

    public static List<Rating> MapToDBModel(this List<CreateRatingDTO> rating) =>
   rating.Select(item => new Rating()
       {
           Id = Guid.NewGuid(),
       UserId = item.UserId,
           ContentId = item.ContentId,
           LastUpdated = DateTime.Now,
           Like = item.Like,
       }).ToList();

    public static RatingDTO MapToDTO(this Rating rating) =>
        new RatingDTO(rating.Id, rating.UserId, rating.ContentId, rating.Like, rating.LastUpdated);

    public static CreateRatingDTO MapToCreateDTO(this Rating rating) =>
        new CreateRatingDTO(rating.UserId, rating.Like, rating.ContentId);

    public static List<RatingDTO> MapToDTO(this List<Rating> rating) =>
       rating.Select(item => new RatingDTO(item.Id, item.UserId, item.ContentId, item.Like, item.LastUpdated)).ToList();
}
