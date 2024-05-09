using Microsoft.EntityFrameworkCore;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence.Repositories;

public class UserInRoleRepository : BaseRepository<UserInRole>, IUserInRoleRepository
{
    public UserInRoleRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<UserInRole> GetUserInRole(int userId, int roleId, CancellationToken cancellationToken)
    {
        return await Context.Set<UserInRole>()
            .FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId, cancellationToken);
    }

    public void DeleteUserInRole(UserInRole userInRole)
    {
         Context.Set<UserInRole>().Remove(userInRole);
    }
}