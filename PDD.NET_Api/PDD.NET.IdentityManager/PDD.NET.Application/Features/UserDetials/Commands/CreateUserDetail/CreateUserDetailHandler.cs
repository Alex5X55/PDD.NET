using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Features.UserDetials.Commands.UpdateUserDetail;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.UserDetials.Commands.CreateUserDetail;

public sealed class CreateUserDetailHandler : IRequestHandler<CreateUserDetailInternalRequest, CreateUserDetailResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserDetailRepository _userDetailRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public CreateUserDetailHandler(IUnitOfWork unitOfWork, IUserDetailRepository userDetailRepository, IUserRepository userRepository, IMapper mapper, ILogger<CreateUserDetailHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _userDetailRepository = userDetailRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CreateUserDetailResponse> Handle(CreateUserDetailInternalRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.UserId, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        var existsUserDetail = await _userDetailRepository.GetUserDetailByUserId(request.UserId, cancellationToken);
        if (existsUserDetail != null)
        {
            throw new BadRequestException($"For userId: {request.UserId} already exists userDetail");
        }

        var userDetail = _mapper.Map<UserDetail>(request);
        _userDetailRepository.Create(userDetail);
        await _unitOfWork.Save(cancellationToken);

        _logger.LogInformation($"UserDetail {userDetail.Name} entity for {userDetail.UserId} created by API request");

        return _mapper.Map<CreateUserDetailResponse>(userDetail);
    }
}