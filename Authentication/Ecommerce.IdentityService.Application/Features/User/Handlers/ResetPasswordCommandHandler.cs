using Ecommerce.IdentityService.Application.Features.User.Commands;
using Ecommerce.IdentityService.Application.Interfaces.User;
using Ecommerce.IdentityService.Domain.ValueObjects;
using MediatR;

namespace Ecommerce.IdentityService.Application.Features.User.Handlers;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand,Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IResetTokenService _resetTokenService;

    public ResetPasswordCommandHandler(IUserRepository userRepository, IResetTokenService resetTokenService)
    {
        _userRepository = userRepository;
        _resetTokenService = resetTokenService;
    }

    public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        Guid? userId = await _resetTokenService.ValidateToken(request.ResetToken);

        if (userId == null)
            throw new ApplicationException("Invalid or expired reset token.");

        var user = await _userRepository.GetByIdAsync(userId.Value);
        if (user == null)
            throw new ApplicationException("Invalid or expired reset token.");

        user.PasswordHash = EncryptedPassword.FromPlain(request.NewPassword).Hash;
        await _userRepository.UpdateAsync(user);

        return Unit.Value;
    }
}

