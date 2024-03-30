using Services.Contracts.User;

namespace Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllAsync();

        Task<UserDTO> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(CreatingUserDTO creatingUserDTO);

        Task UpdateAsync(Guid id, UpdatingUserDTO updatingUserDTO);

        Task DeleteAsync(Guid id);
    }
}