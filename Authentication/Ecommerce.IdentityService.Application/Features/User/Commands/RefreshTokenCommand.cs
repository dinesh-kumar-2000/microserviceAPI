using Ecommerce.IdentityService.Application.DTOs.User;
using MediatR;

namespace Ecommerce.IdentityService.Application.Features.User.Commands;

public class RefreshTokenCommand : IRequest<AuthResponseDto>
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}