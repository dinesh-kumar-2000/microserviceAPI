using MediatR;

namespace Ecommerce.IdentityService.Application.Features.User.Commands;

public class AssignUserRoleCommand : IRequest<bool>
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}

