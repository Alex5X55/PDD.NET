﻿using AutoMapper;
using MediatR;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.UserDetails.Commands.UpdateUserDetail;

public sealed class UpdateUserDetailHandler : IRequestHandler<UpdateUserDetailInternalRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserDetailRepository _userDetailRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserDetailHandler(IUnitOfWork unitOfWork, IUserDetailRepository userDetailRepository, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userDetailRepository = userDetailRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateUserDetailInternalRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.UserId, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        var userDetail = _mapper.Map<UserDetail>(await _userDetailRepository.Get(request.UserId, cancellationToken));
        if (userDetail == null)
        {
            userDetail = _mapper.Map<UserDetail>(request);
            _userDetailRepository.Create(userDetail);
        }
        else
        {
            userDetail.Name = request.Name;
            userDetail.Surname = request.Surname;
            userDetail.Country = request.Country;
            _userDetailRepository.Update(userDetail);
        }
        
        await _unitOfWork.Save(cancellationToken);

        return Unit.Value;
    }
}
