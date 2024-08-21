using MediatR;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Users.Queries.GetUserAuthInfo;

public sealed record GetUserAuthRequest(string email) : IRequest<GetUserAuthResponse>;