using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flow_view_database.RefreshToken;

public interface IRefreshTokenRepository
{
    Task<string> GenerateRefreshTokenAsync(ApplicationUser.ApplicationUser user, string provider);
    Task<bool> ValidateRefreshTokenAsync(string token, ApplicationUser.ApplicationUser user, string provider);
    Task RevokeRefreshTokenAsync(ApplicationUser.ApplicationUser user, string provider);
}
