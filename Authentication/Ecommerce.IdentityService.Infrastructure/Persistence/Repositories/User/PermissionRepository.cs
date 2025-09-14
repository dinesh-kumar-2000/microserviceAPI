using Ecommerce.IdentityService.Application.Interfaces;
using Ecommerce.IdentityService.Application.Interfaces.Dapper;
using Ecommerce.IdentityService.Domain.Entities;

namespace Ecommerce.IdentityService.Infrastructure.Persistence.Repositories.User;

public class PermissionRepository : IPermissionRepository
{
    IDapperRepository _dapperRepository;
    public PermissionRepository(IDapperRepository dapperRepository)
    {
        _dapperRepository = dapperRepository;
    }
    public async Task<Permission?> GetByIdAsync(Guid id)
    {
        return await _dapperRepository.QueryFirstOrDefaultAsync<Permission>(
            "SELECT * FROM Permissions WHERE Id = @Id", new { Id = id });
    }

    public async Task<Permission?> GetByNameAsync(string name)
    {
        return await _dapperRepository.QueryFirstOrDefaultAsync<Permission>(
            "SELECT * FROM Permissions WHERE Name = @Name", new { Name = name });
    }

    public async Task<IEnumerable<Permission>> GetAllAsync()
    {
        return await _dapperRepository.QueryAsync<Permission>(
            "SELECT * FROM Permissions");
    }

    public async Task AddAsync(Permission permission)
    {
        var sql = "INSERT INTO Permissions (Id, Name, Resource, Action, Description) VALUES (@Id, @Name, @Resource, @Action, @Description)";
        await _dapperRepository.ExecuteAsync(sql, permission);
    }

    public async Task<bool> ExistsAsync(string name)
    {
        var count = await _dapperRepository.ExecuteScalarAsync<int>(
            "SELECT COUNT(1) FROM Permissions WHERE Name = @Name", new { Name = name });
        return count > 0;
    }
}
