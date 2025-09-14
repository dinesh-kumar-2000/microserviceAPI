using Ecommerce.IdentityService.Application.Interfaces.Token;
using Ecommerce.IdentityService.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Shared.Constants;
using System.Security.Claims;

namespace Ecommerce.IdentityService.Infrastructure.Auth;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    /// <summary>
    /// Generates JWT with basic user identity claims.
    /// </summary>
    public string GenerateToken(User user)
    {
        return GenerateToken(user, null);
    }

    /// <summary>
    /// Generates JWT with user identity and supplied roles/claims.
    /// </summary>
    public string GenerateToken(User user, IList<Domain.Entities.UserRole> userRoles)
    {
        var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(Shared.Constants.ClaimTypes.UserId, user.Id.ToString()),
        new Claim(Shared.Constants.ClaimTypes.Email, user.Email.Value),
        new Claim(Shared.Constants.ClaimTypes.UserName, user.UserName),
    };

        if (userRoles != null)
        {
            foreach (var userRole in userRoles)
            {
                if (userRole != null && !string.IsNullOrWhiteSpace(userRole.RoleName))
                {
                    claims.Add(new Claim(Shared.Constants.ClaimTypes.Role, userRole.RoleName));
                }

                if (userRole?.Role?.RoleClaims != null)
                {
                    foreach (var rc in userRole.Role.RoleClaims)
                    {
                        claims.Add(new Claim(rc.ClaimType, rc.ClaimValue));
                    }
                }

                if (userRole?.Role?.RolePermissions != null)
                {
                    foreach (var rp in userRole.Role.RolePermissions)
                    {
                        var permission = rp.Permission;
                        if (permission != null && !string.IsNullOrWhiteSpace(permission.PermissionName))
                        {
                            claims.Add(new Claim("permission", permission.PermissionName));
                        }
                    }
                }
            }
        }

        var jwtKey = _configuration["Jwt:Key"];
        var jwtIssuer = _configuration["Jwt:Issuer"];
        var jwtAudience = _configuration["Jwt:Audience"];
        var expiresMinutes = int.TryParse(_configuration["Jwt:ExpiresMinutes"], out var mins) ? mins : 60;

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiresMinutes),
            signingCredentials: creds
        );

        return _tokenHandler.WriteToken(token);
    }

    public string GenerateSecureRandomToken(int length = 64)
    {
        var randomBytes = new byte[length];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
    }
}
