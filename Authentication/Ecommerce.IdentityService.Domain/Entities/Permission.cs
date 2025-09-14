namespace Ecommerce.IdentityService.Domain.Entities
{
    public class Permission
    {
        public Guid Id { get; set; }
        public string PermissionName { get; set; } = string.Empty;
        public string Resource { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string? PermissionDescription { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
