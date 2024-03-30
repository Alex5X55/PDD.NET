using AutoMapper;
using Services.Contracts.User;
using WebApi.Models.User;

namespace WebApi.Mapping
{
    public class UserMappingsProfileForApi : Profile
    {
        public UserMappingsProfileForApi()
        {
            CreateMap<UserDTO, UserModel>();
            CreateMap<CreatingUserModel, CreatingUserDTO>();
            CreateMap<UpdatingUserModel, UpdatingUserDTO>();
        }
    }
}