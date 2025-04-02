using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flow_view_database.Content;

public record ContentPreviewDTO(
    Guid id,
    Guid UserId,
    string Title,
    string Description,
    string Thumbnail,
    string FilePath,
    ContentType Type,
    DateTime? ReleaseDate,
    int Likes,
    int Dislikes,
    int Views);

