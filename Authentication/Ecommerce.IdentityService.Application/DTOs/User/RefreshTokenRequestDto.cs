namespace Ecommerce.IdentityService.Application.DTOs.User;

public class RefreshTokenRequestDto
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}
