namespace Ecommerce.IdentityService.Application.DTOs.Role;

public class RefreshTokenDto
{
    public Guid Id { get; set; }
    public string Token { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? RevokedAt { get; set; }
    public string? ReplacedByToken { get; set; }
}
