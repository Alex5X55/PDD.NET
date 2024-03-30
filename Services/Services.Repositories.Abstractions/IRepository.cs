using Domain.Entities;

namespace Services.Repositories.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> CreateAsync(T entity);

        Task DeleteAsync(T entity);

        Task SaveChangesAsync();
    }
}