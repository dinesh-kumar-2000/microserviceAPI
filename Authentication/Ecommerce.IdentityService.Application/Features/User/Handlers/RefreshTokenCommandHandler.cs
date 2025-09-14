using AutoMapper;
using Ecommerce.IdentityService.Application.DTOs.User;
using Ecommerce.IdentityService.Application.Features.User.Commands;
using Ecommerce.IdentityService.Application.Interfaces.Token;
using Ecommerce.IdentityService.Application.Interfaces.User;
using Ecommerce.IdentityService.Domain.Entities;
using MediatR;
using System.Security;

namespace Ecommerce.IdentityService.Application.Features.User.Handlers;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthResponseDto>
{
    private readonly ITokenService _tokenService;
    private readonly IRefreshTokenRepository _refreshTokenRepo;
    private readonly IUserRepository _userRepository;

    public RefreshTokenCommandHandler(
        ITokenService tokenService,
        IRefreshTokenRepository refreshTokenRepo,
        IUserRepository userRepo)
    {
        _tokenService = tokenService;
        _refreshTokenRepo = refreshTokenRepo;
        _userRepository = userRepo;
    }

    public async Task<AuthResponseDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await _refreshTokenRepo.GetByTokenAsync(request.RefreshToken);
        if (refreshToken == null || refreshToken.RevokedAt != null || refreshToken.ExpiresAt <= DateTimeOffset.UtcNow)
            throw new SecurityException("Invalid or expired refresh token.");

        // 2. Get user
        var user = await _userRepository.GetByIdAsync(refreshToken.UserId);
        if (user == null)
            throw new SecurityException("User not found.");

        // 3. Generate new JWT and refresh token
        var jwt = _tokenService.GenerateToken(user);
        var newRefreshToken = new RefreshToken
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Token = Guid.NewGuid().ToString("N"), // or use secure/random generator
            ExpiresAt = DateTimeOffset.UtcNow.AddDays(7), // Set as per config/policy
            CreatedAt = DateTimeOffset.UtcNow
        };

        // 4. Revoke old refresh token and store the new one
        await _refreshTokenRepo.RevokeAsync(refreshToken.Id);
        await _refreshTokenRepo.AddAsync(newRefreshToken);

        var userdto = new UserDto
        {

        };

        // 5. Return new tokens and user info
        return new AuthResponseDto
        {
            Token = jwt,
            RefreshToken = newRefreshToken.Token,
            ExpiresAt = DateTimeOffset.UtcNow.AddMinutes(60), // Use JWT expiry, or grab from config
            User = userdto
        };
    }
}
