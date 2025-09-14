namespace Ecommerce.IdentityService.Application.DTOs.Role;

public class AssignUserRoleDto
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}
