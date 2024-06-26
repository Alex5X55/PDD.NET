﻿using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.UserDetials.Commands.UpdateUserDetail;

public sealed class UpdateUserDetailMapper : Profile
{
    public UpdateUserDetailMapper()
    {
        CreateMap<UpdateUserDetailInternalRequest, UserDetail>();
    }
}