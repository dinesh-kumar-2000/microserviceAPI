using Ecommerce.IdentityService.Application.Interfaces.Dapper;
using Ecommerce.IdentityService.Application.Interfaces.User;
using Ecommerce.IdentityService.Domain.Entities;
using System.Data;

namespace Ecommerce.IdentityService.Infrastructure.Persistence.Repositories.User;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly IDapperRepository _dapperRepository;
    public UserRoleRepository(IDapperRepository dbConnectionFactory)
    {
        _dapperRepository = dbConnectionFactory;
    }
    public async Task AddUserRoleAsync(UserRole userRole)
    {
        var sql = "INSERT INTO UserRoles (UserId, RoleId) VALUES (@UserId, @RoleId)";
        await _dapperRepository.ExecuteAsync(sql, userRole);
    }

    public async Task<IEnumerable<Role>> GetRolesByUserIdAsync(Guid userId)
    {
        var sql = "GetUserRolesWithPermissionsByUserId";

        var roleDict = new Dictionary<Guid, Role>();

        var result = await _dapperRepository.QueryAsync<Role, RolePermission, Permission, Role>(
                sql,
                (role, rolePermission, permission) =>
                {
                    if (!roleDict.TryGetValue(role.Id, out var existingRole))
                    {
                        existingRole = role;
                        existingRole.RolePermissions = new List<RolePermission>();
                        roleDict[role.Id] = existingRole;
                    }

                    if (rolePermission != null && permission != null)
                    {
                        permission.Id = rolePermission.PermissionId;
                        rolePermission.Permission = permission;
                        existingRole.RolePermissions.Add(rolePermission);
                    }

                    return existingRole;
                },
                param: new { UserId = userId },
                splitOn: "RoleId,PermissionId",
                commandType: CommandType.StoredProcedure
            );

        return roleDict.Values;
    }



    public async Task<IEnumerable<Domain.Entities.User>> GetUsersByRoleIdAsync(Guid roleId)
    {
        var sql = @"
            SELECT u.* FROM Users u
            INNER JOIN UserRoles ur ON u.Id = ur.UserId
            WHERE ur.RoleId = @RoleId";
        return await _dapperRepository.QueryAsync<Domain.Entities.User>(sql, new { RoleId = roleId });
    }

    public async Task RemoveUserRoleAsync(Guid userId, Guid roleId)
    {
        var sql = "DELETE FROM UserRoles WHERE UserId = @UserId AND RoleId = @RoleId";
        await _dapperRepository.ExecuteAsync(sql, new { UserId = userId, RoleId = roleId });
    }
}
