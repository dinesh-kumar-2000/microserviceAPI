namespace Ecommerce.IdentityService.Domain.Entities
{
    public class RoleClaim
    {
        public int Id { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public string ClaimType { get; set; } = string.Empty;
        public string ClaimValue { get; set; } = string.Empty;
    }
}
