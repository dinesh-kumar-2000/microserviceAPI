using Ecommerce.IdentityService.Application.Features.Role.Command;
using Ecommerce.IdentityService.Application.Interfaces.User;
using MediatR;

namespace Ecommerce.IdentityService.Application.Features.Role.Handler;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Guid>
{
    private readonly IRoleRepository _roleRepository;

    public CreateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Guid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var existingRole = await _roleRepository.GetByNameAsync(request.Name);
        if (existingRole != null)
            throw new ApplicationException("Role already exists.");

        var role = new Domain.Entities.Role
        {
            Id = Guid.NewGuid(),
            RoleName = request.Name,
            RoleDescription = request.Description
        };

        await _roleRepository.CreateAsync(role);
        return role.Id;
    }


}
