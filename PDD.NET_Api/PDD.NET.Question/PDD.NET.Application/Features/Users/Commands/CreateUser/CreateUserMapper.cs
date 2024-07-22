using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Users.Commands.CreateUser;

public sealed class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, CreateUserResponse>();
    }
}