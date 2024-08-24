using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Users.Commands.DeleteUser;

public sealed class DeleteUserHandler : IRequestHandler<DeleteUserRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteUserHandler> _logger;

    public DeleteUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper, ILogger<DeleteUserHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.Id, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        user.IsDeleted = true;
        _userRepository.Update(user);
        await _unitOfWork.Save(cancellationToken);

        _logger.LogInformation($"User {user.Id} deleted");

        return Unit.Value;
    }
}
