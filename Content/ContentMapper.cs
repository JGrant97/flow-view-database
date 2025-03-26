using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flow_view_database.Content;
public static class ContentMapper
{
    public static ContentDTO MapToDTO(this Content content) =>
        new ContentDTO(content.Id,
            content.UserId,
            content.Title,
            content.Description,
            content.Thumbnail,
            content.FilePath,
            content.Type,
            content.ReleaseDate,
            content.LastUpadted,
            null);

    public static List<ContentDTO> MapToDTO(this List<Content> content) =>
        content.Select(item => new ContentDTO(
            item.Id, 
            item.UserId,
            item.Title, 
            item.Description, 
            item.Thumbnail, 
            item.FilePath, 
            item.Type, 
            item.ReleaseDate, 
            item.LastUpadted, null))
        .ToList();

    public static Content MapToDBModel(this ContentDTO content) =>
        new Content()
        {
            Id = content.Id,
            UserId = content.UserId,
            Description = content.Description,
            FilePath = content.FilePath,
            LastUpadted = content.LastUpadted,
            ReleaseDate = content.ReleaseDate,
            Thumbnail = content.Thumbnail,
            Title = content.Title,
            Type = content.Type,
        };

    public static List<Content> MapToDBModel(this List<ContentDTO> content) =>
        content.Select(item => new Content()
        {
            Id = item.Id,
            UserId = item.UserId,
            Description = item.Description,
            FilePath = item.FilePath,
            LastUpadted = item.LastUpadted,
            ReleaseDate = item.ReleaseDate,
            Thumbnail = item.Thumbnail,
            Title = item.Title,
            Type = item.Type,
        }).ToList();
}
