namespace Ecommerce.IdentityService.Application.DTOs.User;

public class AuthResponseDto
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public UserDto User { get; set; }
}
