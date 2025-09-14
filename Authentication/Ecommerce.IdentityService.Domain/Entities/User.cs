using Ecommerce.IdentityService.Domain.ValueObjects;

namespace Ecommerce.IdentityService.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = string.Empty;
        public Email Email { get; set; }
        public string PasswordHash { get; set; } = string.Empty; 
        public string? SecurityStamp { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsLockedOut { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Many-to-many roles
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<UserClaim> UserClaims { get; set; } = new List<UserClaim>();
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

        // Optional personal/contact info
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }

        // Optional for security/auditing
        public int AccessFailedCount { get; set; }
        public DateTimeOffset? LastLoginAt { get; set; }

        // 2FA, if supported
        public bool TwoFactorEnabled { get; set; }
        public string? AuthenticatorKey { get; set; }
    }
}
