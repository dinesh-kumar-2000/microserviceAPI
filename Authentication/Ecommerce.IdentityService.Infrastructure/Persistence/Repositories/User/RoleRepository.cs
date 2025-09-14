using Ecommerce.IdentityService.Application.Interfaces.Dapper;
using Ecommerce.IdentityService.Application.Interfaces.User;
using Ecommerce.IdentityService.Domain.Entities;
using System.Data;

namespace Ecommerce.IdentityService.Infrastructure.Persistence.Repositories.User
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDapperRepository _dapperRepository;

        public RoleRepository(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public async Task CreateAsync(Role role)
        {
            var sql = @"INSERT INTO Roles (Id, Name, Description) VALUES (@Id, @Name, @Description)";
            await _dapperRepository.ExecuteAsync(sql, new
            {
                Id = role.Id,
                Name = role.RoleName,
                Description = role.RoleDescription
            });

            if (role.RolePermissions != null && role.RolePermissions.Any())
            {
                var sqlRolePerm = "INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (@RoleId, @PermissionId)";
                foreach (var perm in role.RolePermissions)
                {
                    await _dapperRepository.ExecuteAsync(sqlRolePerm, new
                    {
                        RoleId = role.Id,
                        PermissionId = perm.PermissionId
                    });
                }
            }
        }


        public async Task UpdateAsync(Role role)
        {
            var sql = @"UPDATE Roles SET Name = @Name, Description = @Description WHERE Id = @Id";
            await _dapperRepository.ExecuteAsync(sql, new { role.Id, role.RoleName, role.RoleDescription });
        }

        public async Task DeleteAsync(Guid id)
        {
            var sql = @"DELETE FROM Roles WHERE Id = @Id";
            await _dapperRepository.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<Role?> GetByIdAsync(Guid id)
        {
            var sql = @"SELECT * FROM Roles WHERE Id = @Id";
            return await _dapperRepository.QueryFirstOrDefaultAsync<Role>(sql, new { Id = id });
        }

        public async Task<Role?> GetByNameAsync(string name)
        {
            var sql = @"SELECT * FROM Roles WHERE Name = @Name";
            return await _dapperRepository.QueryFirstOrDefaultAsync<Role>(sql, new { Name = name });
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            var sql = @"SELECT * FROM Roles";
            return await _dapperRepository.QueryAsync<Role>(sql);
        }

        public async Task<IEnumerable<RoleClaim>> GetClaimsAsync(Guid roleId)
        {
            var sql = @"SELECT * FROM RoleClaims WHERE RoleId = @RoleId";
            return await _dapperRepository.QueryAsync<RoleClaim>(sql, new { RoleId = roleId });
        }

        public async Task AddClaimAsync(Guid roleId, RoleClaim claim)
        {
            var sql = @"INSERT INTO RoleClaims (RoleId, ClaimType, ClaimValue)
                        VALUES (@RoleId, @ClaimType, @ClaimValue)";
            await _dapperRepository.ExecuteAsync(sql, new
            {
                RoleId = roleId,
                ClaimType = claim.ClaimType,
                ClaimValue = claim.ClaimValue
            });
        }

        public async Task RemoveClaimAsync(Guid roleId, int claimId)
        {
            var sql = @"DELETE FROM RoleClaims WHERE RoleId = @RoleId AND Id = @ClaimId";
            await _dapperRepository.ExecuteAsync(sql, new { RoleId = roleId, ClaimId = claimId });
        }

        public async Task<IEnumerable<UserRole>> GetUserRolesAsync(Guid roleId)
        {
            var sql = @"SELECT * FROM UserRoles WHERE RoleId = @RoleId";
            return await _dapperRepository.QueryAsync<UserRole>(sql, new { RoleId = roleId });
        }
        public async Task<Role?> GetByNameWithPermissionsAsync(string name)
        {
            const string storedProc = "GetRoleWithPermissionsByName";
            var roleDictionary = new Dictionary<Guid, Role>();

            var result = await _dapperRepository.QueryAsync<Role, RolePermission, Permission, Role>(
                storedProc,
                (role, rolePermission, permission) =>
                {
                    if (!roleDictionary.TryGetValue(role.Id, out var existingRole))
                    {
                        existingRole = role;
                        existingRole.RolePermissions = new List<RolePermission>();
                        roleDictionary[role.Id] = existingRole;
                    }

                    if (rolePermission != null && permission != null)
                    {
                        permission.Id = rolePermission.PermissionId;
                        rolePermission.Permission = permission;
                        existingRole.RolePermissions.Add(rolePermission);
                    }

                    return existingRole;
                },
                new { RoleName = name },
                splitOn: "RoleId,PermissionId",
                commandType: CommandType.StoredProcedure
            );

            return roleDictionary.Values.FirstOrDefault();

        }
    }
}
