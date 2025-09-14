namespace Ecommerce.IdentityService.Domain.Entities
{
    // For external logins (Google, Facebook, etc.)
    public class UserLogin
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public string LoginProvider { get; set; } = string.Empty;
        public string ProviderKey { get; set; } = string.Empty;
        public string? ProviderDisplayName { get; set; }
    }

}
