using MediatR;

namespace PDD.NET.Application.Features.Users.Queries.GetUserFullInfo;

public sealed record GetUserFullInfoRequest(int id) : IRequest<GetUserFullInfoResponse>;