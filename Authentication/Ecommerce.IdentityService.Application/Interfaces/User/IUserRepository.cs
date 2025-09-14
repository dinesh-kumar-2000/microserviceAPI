using Ecommerce.IdentityService.Domain.Entities;
using Ecommerce.Shared.Constants.User;

namespace Ecommerce.IdentityService.Application.Interfaces.User;

public interface IUserRepository
{
    Task<Domain.Entities.User?> GetByIdAsync(Guid id);
    Task<Domain.Entities.User?> GetByEmailAsync(string email);
    Task<Domain.Entities.User?> GetByUserNameAsync(string userName);
    Task CreateAsync(Domain.Entities.User user);
    Task UpdateAsync(Domain.Entities.User user);
    Task DeleteAsync(Guid id);
    Task AssignRoleAsync(Guid userId, Guid roleId);

    Task<IEnumerable<Domain.Entities.UserRole>> GetUserRolesAsync(Guid userId);
    Task<IEnumerable<UserClaim>> GetUserClaimsAsync(Guid userId);
    // Add more as needed
}