using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Features.Users.Queries.GetUserFullInfo;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Users.Commands.CreateUser;

public sealed class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateUserHandler> _logger;

    public CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper, ILogger<CreateUserHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);

        var checkUser = await _userRepository.GetUserAuthInfo(user.Email, cancellationToken);
        if (checkUser != null)
        {
            throw new NotFoundException(nameof(User) + " пользователь с такой почтой уже существует");
        }
        user.PasswordHash = Generate(request.Password);
        _userRepository.Create(user);
        await _unitOfWork.Save(cancellationToken);

        _logger.LogInformation($"User {user.Id} created by API request");

        return _mapper.Map<CreateUserResponse>(user);
    }

    private string Generate(string password) => BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    //private bool Verify(string password, string hashedPassword) => BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
}