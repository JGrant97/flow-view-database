using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flow_view_database.Rating;
public record RatingStatsDTO(int Likes, int Dislikes, RatingDTO? Rating);

