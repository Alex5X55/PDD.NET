using MediatR;

namespace PDD.NET.Application.Features.UserDetials.Commands.CreateUserDetail;

public sealed record CreateUserDetailRequest(string Name, string Surname, string Country)
    : IRequest<CreateUserDetailResponse>;

public sealed record CreateUserDetailInternalRequest(string Name, string Surname, string Country, int UserId)
    : IRequest<CreateUserDetailResponse>;