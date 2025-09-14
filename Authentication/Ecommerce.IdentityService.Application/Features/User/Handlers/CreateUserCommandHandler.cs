using AutoMapper;
using Ecommerce.IdentityService.Application.DTOs.Role;
using Ecommerce.IdentityService.Application.DTOs.User;
using Ecommerce.IdentityService.Application.Features.User.Commands;
using Ecommerce.IdentityService.Application.Interfaces.Token;
using Ecommerce.IdentityService.Application.Interfaces.User;
using Ecommerce.IdentityService.Domain.Entities;
using Ecommerce.IdentityService.Domain.ValueObjects;
using MediatR;

namespace Ecommerce.IdentityService.Application.Features.User.Handlers;

public partial class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, AuthResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(
        IUserRepository userRepository,
        ITokenService tokenService,
        IRefreshTokenRepository refreshTokenRepository,
        IRoleRepository roleRepository,
        IUserRoleRepository userRoleRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _refreshTokenRepository = refreshTokenRepository;
        _roleRepository = roleRepository;
        _userRoleRepository = userRoleRepository;
        _mapper = mapper;
    }
    public async Task<AuthResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);
        if (existingUser != null)
            throw new ApplicationException("Email is already registered.");

        var user = new Domain.Entities.User
        {
            Id = Guid.NewGuid(),
            Email = new Email(request.Email),
            UserName = request.UserName,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PasswordHash = EncryptedPassword.FromPlain(request.Password).Hash,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
            IsEmailConfirmed = false,
            UserRoles = new List<UserRole>()
        };

        var defaultRoleName = Shared.Constants.User.UserRole.Customer;
        var roleFromDb = await _roleRepository.GetByNameWithPermissionsAsync(defaultRoleName)
            ?? throw new ApplicationException("Default customer role not found!");

        var userRole = new UserRole
        {
            UserId = user.Id,
            RoleId = roleFromDb.Id,
            RoleName = roleFromDb.RoleName,
            Role = roleFromDb
        };

        user.UserRoles.Add(userRole);

        await _userRepository.CreateAsync(user);
        await _userRoleRepository.AddUserRoleAsync(userRole);

        var jwt = _tokenService.GenerateToken(user, user.UserRoles.ToList());
        var refreshTokenValue = _tokenService.GenerateSecureRandomToken();
        var refreshToken = new RefreshToken { Id = Guid.NewGuid(), UserId = user.Id, Token = refreshTokenValue, ExpiresAt = DateTimeOffset.UtcNow.AddDays(7), CreatedAt = DateTimeOffset.UtcNow };
        await _refreshTokenRepository.AddAsync(refreshToken);

        var userDto = _mapper.Map<UserDto>(user);

        return new AuthResponseDto
        {
            Token = jwt,
            RefreshToken = refreshToken.Token,
            ExpiresAt = DateTimeOffset.UtcNow.AddMinutes(60),
            User = userDto
        };
    }

}