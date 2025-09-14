using AutoMapper;
using Ecommerce.IdentityService.Application.DTOs.User;
using Ecommerce.IdentityService.Application.Features.User.Queries;
using Ecommerce.IdentityService.Application.Interfaces.User;
using MediatR;

namespace Ecommerce.IdentityService.Application.Features.User.Handlers;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
            return null;
        var dto = new UserDto
        {

        };
        return dto;
    }
}
