namespace Ecommerce.IdentityService.Application.Interfaces.User;

public interface IResetTokenService
{
    // Generate a new reset token for the user (could be email or userId)
    Task<string> GenerateToken(Guid userId);

    // Validate a token and return the userId if valid, or throw/return null if invalid
    Task<Guid?> ValidateToken(string token);

    // (Optional) Invalidate a token after use
    Task InvalidateToken(string token);

    // (Optional) Persist token to database, etc.
}
