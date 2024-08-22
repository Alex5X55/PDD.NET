using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Users.Commands.UpdateUser;

public sealed class UpdateUserHandler : IRequestHandler<UpdateUserInternalRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateUserHandler> _logger;   

    public UpdateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper,ILogger<UpdateUserHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateUserInternalRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(await _userRepository.Get(request.Id, cancellationToken));
        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        user.Login = request.Login;
        user.Email = request.Email;
        _userRepository.Update(user);
        await _unitOfWork.Save(cancellationToken);

        _logger.LogInformation($"User {user.Id} updated by API request");

        return Unit.Value;
    }
}
