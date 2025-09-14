using Ecommerce.IdentityService.Domain.Entities;

namespace Ecommerce.IdentityService.Application.Interfaces.User;

public interface IRefreshTokenRepository
{
    Task AddAsync(RefreshToken token);
    Task<RefreshToken?> GetByTokenAsync(string token);
    Task<RefreshToken> GetByUserIdAsync(Guid userId);
    Task RevokeAsync(Guid tokenId);
    Task RevokeAllForUserAsync(Guid userId);
    Task DeleteExpiredAsync(DateTimeOffset now);
    Task UpdateAsync(RefreshToken refreshToken);
}