using Ecommerce.IdentityService.Application.Features.User.Commands;
using Ecommerce.IdentityService.Application.Interfaces.User;
using MediatR;

namespace Ecommerce.IdentityService.Application.Features.User.Handlers;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand,Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IResetTokenService _resetTokenService;
    //private readonly IEmailService _emailService;  ToDo

    public ForgotPasswordCommandHandler(
        IUserRepository userRepository,
        IResetTokenService resetTokenService
        //,IEmailService emailService
        )
    {
        _userRepository = userRepository;
        _resetTokenService = resetTokenService;
        //_emailService = emailService;
    }

    public async Task<Unit> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        // Silently do nothing if user is not found (to prevent account enumeration)
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null)
            return Unit.Value;

        // Generate a secure reset token and store it mapped to this user
        var resetToken =await _resetTokenService.GenerateToken(user.Id);

        // Compose and send the password reset email
        var resetLink = $"https://yourapp.com/reset-password?token={resetToken}";
        var subject = "Password Reset Request";
        var message = $"Click the following link to reset your password: {resetLink}";

        //await _emailService.SendEmailAsync(user.Email, subject, message);

        return Unit.Value;
    }
}