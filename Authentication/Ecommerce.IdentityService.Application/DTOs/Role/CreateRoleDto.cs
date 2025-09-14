namespace Ecommerce.IdentityService.Application.DTOs.Role;

public class CreateRoleDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<Guid>? PermissionIds { get; set; }
}


