using MediatR;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Repositories;

public interface IUserInRoleRepository : IBaseRepository<UserInRole>
{
    public Task<UserInRole> GetUserInRole(int userId, int roleId, CancellationToken cancellationToken);

    public void DeleteUserInRole(UserInRole userInRole);
}