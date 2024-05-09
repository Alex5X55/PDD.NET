using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.UserDetials.Commands.CreateUserDetail;

public sealed class CreateUserDetailMapper : Profile
{
    public CreateUserDetailMapper()
    {
        CreateMap<CreateUserDetailInternalRequest, UserDetail>();
        CreateMap<UserDetail, CreateUserDetailResponse>();
    }
}