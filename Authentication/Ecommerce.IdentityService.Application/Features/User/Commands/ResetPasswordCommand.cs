using MediatR;

namespace Ecommerce.IdentityService.Application.Features.User.Commands;

public class ResetPasswordCommand : IRequest<Unit>
{
    public Guid UserId { get; set; } 
    public string ResetToken { get; set; }
    public string NewPassword { get; set; }
}

