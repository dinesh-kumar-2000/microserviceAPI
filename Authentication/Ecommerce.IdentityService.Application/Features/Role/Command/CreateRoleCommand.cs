using MediatR;

namespace Ecommerce.IdentityService.Application.Features.Role.Command
{
    public class CreateRoleCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Guid>? PermissionIds { get; set; }
    }
}
