using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace flow_view_database.RefreshToken;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly UserManager<ApplicationUser.ApplicationUser> _userManager;

    public RefreshTokenRepository(UserManager<ApplicationUser.ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> GenerateRefreshTokenAsync(ApplicationUser.ApplicationUser user, string provider)
    {
        var randomNumber = new byte[64];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
        }

        var refreshToken = Convert.ToBase64String(randomNumber);
        var expiryDate = DateTime.UtcNow.AddDays(7).ToString("O"); // ISO 8601 format

        // Store the token in AspNetUserTokens table
        await _userManager.SetAuthenticationTokenAsync(user, provider, "RefreshToken", refreshToken);
        await _userManager.SetAuthenticationTokenAsync(user, provider, "RefreshTokenExpiry", expiryDate);

        return refreshToken;
    }

    public async Task<bool> ValidateRefreshTokenAsync(string token, ApplicationUser.ApplicationUser user, string provider)
    {
        var storedToken = await _userManager.GetAuthenticationTokenAsync(user, provider, "RefreshToken");
        var storedExpiry = await _userManager.GetAuthenticationTokenAsync(user, provider, "RefreshTokenExpiry");

        if (storedToken != token || string.IsNullOrEmpty(storedExpiry))
            return false;

        if (DateTime.TryParse(storedExpiry, out var expiryDate))
        {
            if (expiryDate < DateTime.UtcNow)
                return false;
        }
        else
        {
            return false;
        }

        return true;
    }

    public async Task RevokeRefreshTokenAsync(ApplicationUser.ApplicationUser user, string provider)
    {
        // Remove the token from AspNetUserTokens
        await _userManager.RemoveAuthenticationTokenAsync(user, provider, "RefreshToken");
        await _userManager.RemoveAuthenticationTokenAsync(user, provider, "RefreshTokenExpiry");
    }
}
