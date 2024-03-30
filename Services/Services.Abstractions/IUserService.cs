using Services.Contracts.User;

namespace Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllAsync();

        Task<UserDTO> GetByIdAsync(int id);

        Task<int> CreateAsync(CreatingUserDTO creatingUserDTO);

        Task UpdateAsync(int id, UpdatingUserDTO updatingUserDTO);

        Task DeleteAsync(int id);
    }
}