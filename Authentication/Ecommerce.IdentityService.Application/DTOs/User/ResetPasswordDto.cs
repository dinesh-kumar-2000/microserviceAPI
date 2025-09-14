namespace Ecommerce.IdentityService.Application.DTOs.User;

public class ResetPasswordDto
{
    public string ResetToken { get; set; }
    public string NewPassword { get; set; }
}
