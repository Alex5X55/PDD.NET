using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Users.Queries.GetUserAuthInfo;

public sealed class GetUserAuthMapper : Profile
{
    public GetUserAuthMapper()
    {
        CreateMap<User, GetUserAuthResponse>()
            .ForMember(dest => dest.UserDetail, opt => opt.MapFrom(src => src.UserDetail))
            .ForMember(
                dest => dest.Roles,
                opt => opt.MapFrom(src => src.UserInRoles.Select(ur => ur.Role))
            );

        //CreateMap<UserDetail, UserDetailDTO>();
        //CreateMap<Role, RoleDTO>();
    }
}