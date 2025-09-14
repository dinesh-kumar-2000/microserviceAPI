using Ecommerce.IdentityService.Application.Interfaces.Dapper;
using Ecommerce.IdentityService.Application.Interfaces.User;
using Ecommerce.IdentityService.Domain.Entities;

namespace Ecommerce.IdentityService.Infrastructure.Persistence.Repositories.User;

public class UserRepository : IUserRepository
{
    private readonly IDapperRepository _dapperRepository;
    public UserRepository(IDapperRepository dapperRepository)
    {
       _dapperRepository = dapperRepository;
    }

    public async Task AssignRoleAsync(Guid userId, Guid roleId)
    {
        await _dapperRepository.ExecuteAsync(
            "[dbo].[sp_AssignRoleToUser]",
            new { UserId = userId, RoleId = roleId }
        );
    }

    public async Task CreateAsync(Domain.Entities.User user)
    {
        await _dapperRepository.ExecuteAsync(
            "[dbo].[sp_CreateUser]",
             new
             {
                 Id = user.Id,
                 Email = user.Email.Value,
                 Username = user.UserName,
                 PasswordHash = user.PasswordHash,
                 FirstName = user.FirstName,
                 LastName = user.LastName
             }
            );
    }

    public async Task DeleteAsync(Guid id)
    {
        const string sql = @"DELET FROM Users WHERE UserId = @UserId";
         await _dapperRepository.ExecuteAsync(
            sql, new { UserId = id }
            );
    }

    public async Task<Domain.Entities.User?> GetByEmailAsync(string email)
    {
        return await _dapperRepository.QueryFirstOrDefaultAsync<Domain.Entities.User>(
        "[dbo].[sp_GetUserByEmailWithRoles]",
        new { Email = email }
    );
    }

    public async Task<Domain.Entities.User?> GetByIdAsync(Guid id)
    {
        return await _dapperRepository.QueryFirstOrDefaultAsync<Domain.Entities.User>(
            "[dbo].[sp_GetUserById]",
            new { UserId = id }
            );
    }

    public Task<Domain.Entities.User?> GetByUserNameAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserClaim>> GetUserClaimsAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Domain.Entities.UserRole>> GetUserRolesAsync(Guid userId)
    {
        return await _dapperRepository.QueryAsync<Domain.Entities.UserRole>(
        "[dbo].[sp_GetRolesForUser]",
        new { UserId = userId }
        );
    }

    public async Task UpdateAsync(Domain.Entities.User user)
    {
        await _dapperRepository.ExecuteAsync(
            "[dbo].[sp_UpdateUser]",
             new
             {
                 Id = user.Id,
                 Email = user.Email.Value,
                 Username = user.UserName,
                 PasswordHash = user.PasswordHash,
                 FirstName = user.FirstName,
                 LastName = user.LastName
             }
            );
    }
}
