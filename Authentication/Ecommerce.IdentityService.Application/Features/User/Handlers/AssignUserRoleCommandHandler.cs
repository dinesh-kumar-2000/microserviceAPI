using Ecommerce.IdentityService.Application.Features.User.Commands;
using Ecommerce.IdentityService.Application.Interfaces.User;
using MediatR;

namespace Ecommerce.IdentityService.Application.Features.User.Handlers;

public partial class CreateUserCommandHandler
{
    public class AssignUserRoleCommandHandler : IRequestHandler<AssignUserRoleCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public AssignUserRoleCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<bool> Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null) return false;

            var role = await _roleRepository.GetByIdAsync(request.RoleId);
            if (role == null) return false;

            // Assign role (repository method handles upsert logic)
            await _userRepository.AssignRoleAsync(request.UserId, request.RoleId);

            return true;
        }
    }
}