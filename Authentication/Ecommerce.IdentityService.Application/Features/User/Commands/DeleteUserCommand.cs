using MediatR;

namespace Ecommerce.IdentityService.Application.Features.User.Commands;

public class DeleteUserCommand : IRequest<bool>
{
    public Guid UserId { get; set; }
}

