using MediatR;

namespace Ecommerce.IdentityService.Application.Features.User.Commands;

public class ChangePasswordCommand : IRequest<bool>
{
    public string Email { get; set; }
    public string CurrentPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}

