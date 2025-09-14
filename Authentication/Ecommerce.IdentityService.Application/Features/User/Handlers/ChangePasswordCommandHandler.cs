using Ecommerce.IdentityService.Application.Features.User.Commands;
using Ecommerce.IdentityService.Application.Interfaces.User;
using Ecommerce.IdentityService.Domain.ValueObjects;
using MediatR;

namespace Ecommerce.IdentityService.Application.Features.User.Handlers;

public partial class CreateUserCommandHandler
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public ChangePasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                return false;

            // Verify old password if required
            if (!string.IsNullOrEmpty(request.CurrentPassword))
            {
                if (!EncryptedPassword.Verify(request.CurrentPassword, user.PasswordHash))
                    return false;
            }

            // Set new password (hashed)
            user.PasswordHash = EncryptedPassword.FromPlain(request.NewPassword).Hash!;
            user.UpdatedAt = DateTimeOffset.UtcNow;
            await _userRepository.UpdateAsync(user);
            return true;
        }
    }
}