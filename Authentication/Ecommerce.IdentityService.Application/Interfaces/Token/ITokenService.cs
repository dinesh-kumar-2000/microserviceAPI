using Ecommerce.IdentityService.Domain.Entities;
using Ecommerce.Shared.Constants.User;

namespace Ecommerce.IdentityService.Application.Interfaces.Token;

public interface ITokenService
{
    string GenerateToken(Domain.Entities.User user);
    string GenerateToken(Domain.Entities.User user, IList<Domain.Entities.UserRole> roles);
    string GenerateSecureRandomToken(int length = 64);
}
