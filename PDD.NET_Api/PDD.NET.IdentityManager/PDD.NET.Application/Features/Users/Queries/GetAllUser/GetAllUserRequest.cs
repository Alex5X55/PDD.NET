using MediatR;

namespace PDD.NET.Application.Features.Users.Queries.GetAllUser;

public sealed record GetAllUserRequest() : IRequest<IEnumerable<GetAllUserResponse>>;