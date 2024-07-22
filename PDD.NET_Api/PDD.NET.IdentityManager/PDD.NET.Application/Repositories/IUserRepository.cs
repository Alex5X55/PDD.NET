using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    public Task<User> GetUserFullInfo(int id, CancellationToken cancellationToken);

    public Task<User>  GetUserAuthInfo(string email, CancellationToken cancellationToken);
}