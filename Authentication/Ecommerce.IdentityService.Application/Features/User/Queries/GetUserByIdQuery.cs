using Ecommerce.IdentityService.Application.DTOs.User;
using MediatR;

namespace Ecommerce.IdentityService.Application.Features.User.Queries;

public class GetUserByIdQuery : IRequest<UserDto?>
{
    public Guid UserId { get; }

    public GetUserByIdQuery(Guid userId)
    {
        UserId = userId;
    }
}
