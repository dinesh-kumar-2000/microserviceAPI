using Dapper;
using Ecommerce.IdentityService.Application.Interfaces.Dapper;
using Ecommerce.IdentityService.Application.Interfaces.User;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace Ecommerce.IdentityService.Infrastructure.Persistence.Repositories.User;

public class ResetTokenService : IResetTokenService
{
    private readonly IDapperRepository _dapperRepository;
    public ResetTokenService(IDapperRepository dapperRepository)
    {
        _dapperRepository = dapperRepository;
    }

    public async Task<string> GenerateToken(Guid userId)
    {
        var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()) + Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        var expires = DateTime.UtcNow.AddHours(1);

        var sql = "INSERT INTO PasswordResetTokens (Token, UserId, ExpiresAt) VALUES (@Token, @UserId, @ExpiresAt)";

        await _dapperRepository.ExecuteAsync(sql, new { Token = token, UserId = userId, ExpiresAt = expires });
        return token;
    }

    public async Task<Guid?> ValidateToken(string token)
    {
        var result = await _dapperRepository.QueryFirstOrDefaultAsync<(Guid UserId, DateTime ExpiresAt, bool IsUsed)>(
                "SELECT UserId, ExpiresAt, IsUsed FROM PasswordResetTokens WHERE Token = @Token",
                new { Token = token }
            );
        if (result == default) return null;
        if (result.IsUsed || result.ExpiresAt <= DateTime.UtcNow)
            return null;
        return result.UserId;
    }

    public async Task InvalidateToken(string token)
    {
        await _dapperRepository.ExecuteAsync("UPDATE PasswordResetTokens SET IsUsed = 1 WHERE Token = @Token", new { Token = token });
    }

}

