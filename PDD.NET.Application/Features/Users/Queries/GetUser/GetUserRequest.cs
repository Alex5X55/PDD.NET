using MediatR;

namespace PDD.NET.Application.Features.Users.Queries.GetUser;

public sealed record GetUserRequest(int Id) : IRequest<GetUserResponse>;