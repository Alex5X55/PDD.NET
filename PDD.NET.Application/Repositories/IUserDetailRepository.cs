using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Repositories;

public interface IUserDetailRepository : IBaseRepository<UserDetail>
{
    public Task<UserDetail> GetUserDetailByUserId(int userId, CancellationToken cancellationToken);
}