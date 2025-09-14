using Ecommerce.IdentityService.Application.Interfaces.Dapper;
using Ecommerce.IdentityService.Application.Interfaces.User;
using Ecommerce.IdentityService.Domain.Entities;
using Ecommerce.IdentityService.Infrastructure.Persistence.Dapper;

namespace Ecommerce.IdentityService.Infrastructure.Persistence.Repositories.User;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    IDapperRepository _dapperRepository;
    public RefreshTokenRepository(IDapperRepository dapperRepository)
    {
        _dapperRepository = dapperRepository;
    }
    public async Task AddAsync(RefreshToken token)
    {
        await _dapperRepository.ExecuteAsync(
             "[dbo].[sp_CreateRefreshToken]",
            new
            {
                token.UserId,
                token.Token,
                token.ExpiresAt
            });
    }

    public Task DeleteExpiredAsync(DateTimeOffset now)
    {
        throw new NotImplementedException();
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
       return await _dapperRepository.QueryFirstOrDefaultAsync<RefreshToken>(
            "[dbo].[sp_GetRefreshToken]", new { Token = token });
    }

    public async Task<RefreshToken?> GetByUserIdAsync(Guid userId)
    {
        const string sql = @"SELECT TOP 1 * FROM RefreshTokens WHERE UserId = @UserId";
        return await _dapperRepository.QueryFirstOrDefaultAsync<RefreshToken>(sql, new { UserId = userId });
    }
    public async Task UpdateAsync(RefreshToken refreshToken)
    {
        const string sql = @"UPDATE RefreshTokens
                         SET Token = @Token,
                             ExpiresAt = @ExpiresAt,
                             CreatedAt = @CreatedAt
                         WHERE UserId = @UserId";
        await _dapperRepository.ExecuteAsync(sql, new
        {
            Token = refreshToken.Token,
            ExpiresAt = refreshToken.ExpiresAt,
            CreatedAt = refreshToken.CreatedAt,
            UserId = refreshToken.UserId
        });
    }


    public Task RevokeAllForUserAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task RevokeAsync(Guid tokenId)
    {
        await _dapperRepository.ExecuteAsync(
            @"UPDATE [dbo].[RefreshTokens] SET RevokedAt = SYSDATETIMEOFFSET() WHERE Id = @TokenId",
            new { TokenId = tokenId });
    }
}
