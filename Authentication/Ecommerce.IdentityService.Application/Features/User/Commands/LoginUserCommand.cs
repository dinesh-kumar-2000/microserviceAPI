using Ecommerce.IdentityService.Application.DTOs.User;
using MediatR;

namespace Ecommerce.IdentityService.Application.Features.User.Commands;

public class LoginUserCommand : IRequest<AuthResponseDto>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
