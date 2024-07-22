using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Users.Queries.GetUser;

public sealed class GetUserMapper : Profile
{
    public GetUserMapper()
    {
        CreateMap<User, GetUserResponse>();
    }
}