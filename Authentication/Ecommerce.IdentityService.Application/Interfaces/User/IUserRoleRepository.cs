using Ecommerce.IdentityService.Domain.Entities;

namespace Ecommerce.IdentityService.Application.Interfaces.User;

public interface IUserRoleRepository
{
    Task AddUserRoleAsync(UserRole userRole);
    Task RemoveUserRoleAsync(Guid userId, Guid roleId);
    Task<IEnumerable<Role>> GetRolesByUserIdAsync(Guid userId);
    Task<IEnumerable<Domain.Entities.User>> GetUsersByRoleIdAsync(Guid roleId);
}
