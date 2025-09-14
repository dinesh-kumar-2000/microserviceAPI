using MediatR;

namespace Ecommerce.IdentityService.Application.Features.User.Commands;

public class UpdateUserCommand : IRequest<bool>
{
    public Guid UserId { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    // Other updatable fields as needed
}

