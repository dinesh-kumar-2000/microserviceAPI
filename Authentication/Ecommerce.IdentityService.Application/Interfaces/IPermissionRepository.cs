using Ecommerce.IdentityService.Domain.Entities;

namespace Ecommerce.IdentityService.Application.Interfaces;

public interface IPermissionRepository
{
    Task<Permission?> GetByIdAsync(Guid id);
    Task<Permission?> GetByNameAsync(string name);
    Task<IEnumerable<Permission>> GetAllAsync();
    Task AddAsync(Permission permission);
    Task<bool> ExistsAsync(string name);
}

