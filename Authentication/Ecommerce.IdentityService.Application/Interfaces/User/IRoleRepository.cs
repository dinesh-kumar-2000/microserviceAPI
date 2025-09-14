using Ecommerce.IdentityService.Domain.Entities;

namespace Ecommerce.IdentityService.Application.Interfaces.User;

public interface IRoleRepository
{
    // Role CRUD
    Task<Role?> GetByIdAsync(Guid id);
    Task<Role?> GetByNameAsync(string name);
    Task<IEnumerable<Role>> GetAllAsync();
    Task CreateAsync(Role role);
    Task UpdateAsync(Role role);
    Task DeleteAsync(Guid id);

    // Claims attached to a Role
    Task<IEnumerable<RoleClaim>> GetClaimsAsync(Guid roleId);
    Task AddClaimAsync(Guid roleId, RoleClaim claim);
    Task RemoveClaimAsync(Guid roleId, int claimId);

    Task<Role?> GetByNameWithPermissionsAsync(string name);

    Task<IEnumerable<UserRole>> GetUserRolesAsync(Guid roleId);
}
