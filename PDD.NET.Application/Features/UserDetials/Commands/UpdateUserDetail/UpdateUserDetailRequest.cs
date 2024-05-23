using MediatR;

namespace PDD.NET.Application.Features.UserDetails.Commands.UpdateUserDetail;

public sealed record UpdateUserDetailRequest(string Name, string Surname, string Country)
    : IRequest<Unit>;

public sealed record UpdateUserDetailInternalRequest(
    string Name,
    string Surname,
    string Country,
    int UserId
) : IRequest<Unit>;
