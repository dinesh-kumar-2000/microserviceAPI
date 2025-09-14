namespace Ecommerce.IdentityService.Application.DTOs.User;

public class UserSummaryDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
