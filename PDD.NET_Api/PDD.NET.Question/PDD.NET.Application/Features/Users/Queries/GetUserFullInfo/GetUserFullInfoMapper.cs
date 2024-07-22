using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Users.Queries.GetUserFullInfo;

public sealed class GetUserFullInfoMapper : Profile
{
    public GetUserFullInfoMapper()
    {
        CreateMap<User, GetUserFullInfoResponse>()
            .ForMember(dest => dest.UserDetail, opt => opt.MapFrom(src => src.UserDetail))
            .ForMember(
                dest => dest.Roles,
                opt => opt.MapFrom(src => src.UserInRoles.Select(ur => ur.Role))
            );

        CreateMap<UserDetail, UserDetailDTO>();
        CreateMap<Role, RoleDTO>();
    }
}