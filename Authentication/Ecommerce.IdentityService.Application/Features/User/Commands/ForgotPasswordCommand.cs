using MediatR;

namespace Ecommerce.IdentityService.Application.Features.User.Commands;

public class ForgotPasswordCommand : IRequest<Unit>
{
    public string Email { get; set; }
}
