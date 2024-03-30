using AutoMapper;
using Domain.Entities;
using Services.Abstractions;
using Services.Contracts.User;
using Services.Repositories.Abstractions;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            return _mapper.Map<List<UserDTO>>(await _userRepository.GetAllAsync());
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<User, UserDTO>(await _userRepository.GetByIdAsync(id));
        }

        public async Task<int> CreateAsync(CreatingUserDTO creatingUserDTO)
        {
            var user = _mapper.Map<CreatingUserDTO, User>(creatingUserDTO);
            var createdUser = await _userRepository.CreateAsync(user);
            await _userRepository.SaveChangesAsync();

            return createdUser.Id;
        }

        public async Task UpdateAsync(int id, UpdatingUserDTO updatingUserDTO)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception($"Сущность с id = {id} не найдена");
            }

            _mapper.Map(updatingUserDTO, user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception($"Сущность с id = {id} не найдена");
            }

            await _userRepository.DeleteAsync(user);
        }
    }
}