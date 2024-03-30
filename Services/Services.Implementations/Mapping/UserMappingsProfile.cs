using AutoMapper;
using Domain.Entities;
using Services.Contracts.User;

namespace Services.Implementations.Mapping
{
    public class UserMappingsProfile : Profile
    {
        public UserMappingsProfile()
        {
            CreateMap<User, UserDTO>();

            CreateMap<CreatingUserDTO, User>()
                .ForMember(d => d.Id, map => map.Ignore());

            CreateMap<UpdatingUserDTO, User>()
                .ForMember(d => d.Id, map => map.Ignore());
        }
    }
}