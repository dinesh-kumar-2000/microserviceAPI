namespace Ecommerce.IdentityService.Application.DTOs.User;

public class UserClaimDto
{
    public int Id { get; set; }
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
}
