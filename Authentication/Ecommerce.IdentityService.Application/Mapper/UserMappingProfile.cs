using AutoMapper;
using Ecommerce.IdentityService.Application.DTOs.Role;
using Ecommerce.IdentityService.Application.DTOs.User;
using Ecommerce.IdentityService.Application.Features.User.Commands;
using Ecommerce.IdentityService.Domain.Entities;

namespace Ecommerce.IdentityService.Application.Mapper;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<LoginRequestDto, LoginUserCommand>();
        CreateMap<CreateUserDto, CreateUserCommand>();
        CreateMap<User, UserDto>();
        CreateMap<Role, RoleDto>();
        CreateMap<Permission, PermissionDto>();
        CreateMap<ResetPasswordDto, ResetPasswordCommand>();
        CreateMap<ChangePasswordDto, ChangePasswordCommand>();
        CreateMap<ForgotPasswordDto, ForgotPasswordCommand>();

    }
}
