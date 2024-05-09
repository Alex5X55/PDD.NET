using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.UserInRoles.Commands.CreateUserInRole;

public sealed class CreateUserInRoleMapper : Profile
{
    public CreateUserInRoleMapper()
    {
        CreateMap<CreateUserInRoleRequest, UserInRole>();
    }
}