using Ecommerce.IdentityService.Application.DTOs.User;
using MediatR;

namespace Ecommerce.IdentityService.Application.Features.User.Commands;

public class CreateUserCommand : IRequest<AuthResponseDto>
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    // Optional for profile
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
}

