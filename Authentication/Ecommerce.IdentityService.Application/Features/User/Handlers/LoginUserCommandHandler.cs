using AutoMapper;
using Ecommerce.IdentityService.Application.DTOs.Role;
using Ecommerce.IdentityService.Application.DTOs.User;
using Ecommerce.IdentityService.Application.Features.User.Commands;
using Ecommerce.IdentityService.Application.Interfaces.Token;
using Ecommerce.IdentityService.Application.Interfaces.User;
using Ecommerce.IdentityService.Domain.Entities;
using Ecommerce.IdentityService.Domain.ValueObjects;
using MediatR;
using System.Data;
using System.Linq;

namespace Ecommerce.IdentityService.Application.Features.User.Handlers;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly ITokenService _tokenService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IMapper _mapper;

    public LoginUserCommandHandler(
        IUserRepository userRepo,
        IRoleRepository roleRepo,
        ITokenService tokenService,
        IRefreshTokenRepository refreshTokenRepo,
        IUserRoleRepository userRoleRepository,
        IMapper mapper
        )
    {
        _userRepository = userRepo;
        _roleRepository = roleRepo;
        _tokenService = tokenService;
        _refreshTokenRepository = refreshTokenRepo;
        _userRoleRepository = userRoleRepository;
        _mapper = mapper;
    }

    public async Task<AuthResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null)
            throw new ApplicationException("Invalid login credentials.");

        if (!EncryptedPassword.Verify(request.Password, user.PasswordHash))
            throw new ApplicationException("Invalid login credentials.");

        var jwt = _tokenService.GenerateToken(user, user.UserRoles.ToList());

        var refreshTokenValue = _tokenService.GenerateSecureRandomToken();
        string finalToken = refreshTokenValue;

        var existingToken = await _refreshTokenRepository.GetByUserIdAsync(user.Id);


        var roleFromDb = await _userRoleRepository.GetRolesByUserIdAsync(user.Id);

        foreach (var item in roleFromDb)
        {
            var userRole = new UserRole
            {
                UserId = user.Id,
                RoleId = item.Id,
                RoleName = item.RoleName,
                Role = item
            };

            user.UserRoles.Add(userRole);
        }

        if (existingToken != null)
        {
            existingToken.Token = refreshTokenValue;
            existingToken.ExpiresAt = DateTimeOffset.UtcNow.AddDays(7);
            existingToken.CreatedAt = DateTimeOffset.UtcNow;
            await _refreshTokenRepository.UpdateAsync(existingToken);
        }
        else
        {
            var refreshToken = new RefreshToken
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Token = refreshTokenValue,
                ExpiresAt = DateTimeOffset.UtcNow.AddDays(7),
                CreatedAt = DateTimeOffset.UtcNow
            };
            await _refreshTokenRepository.AddAsync(refreshToken);
        }

        var userDto = _mapper.Map<UserDto>(user);

        return new AuthResponseDto
        {
            Token = jwt,
            RefreshToken = finalToken, // Always the currently issued token
            ExpiresAt = DateTimeOffset.UtcNow.AddMinutes(60),
            User = userDto
        };
    }


}

