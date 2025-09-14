namespace Ecommerce.IdentityService.Application.DTOs.Role;

public class PermissionDto
{
    public string Name { get; set; } = string.Empty; // e.g., Permissions.Product.Edit
    public string? PermissionDescription { get; set; }
}
