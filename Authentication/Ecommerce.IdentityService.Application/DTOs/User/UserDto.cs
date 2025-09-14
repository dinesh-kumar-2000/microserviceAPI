using Ecommerce.IdentityService.Domain.Entities;

namespace Ecommerce.IdentityService.Application.DTOs.User;

public class UserDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsEmailConfirmed { get; set; }
    public bool IsLockedOut { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
