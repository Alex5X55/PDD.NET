using Microsoft.EntityFrameworkCore;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<User> GetUserFullInfo(int id, CancellationToken cancellationToken)
    {
        return await Context.Set<User>()
            .Include(u => u.UserDetail)
            .Include(u => u.UserInRoles)
            .ThenInclude(ur => ur.Role)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken);
    }

    public async Task<User> GetUserAuthInfo(string email, CancellationToken cancellationToken)
    {
        return await Context.Set<User>()
            .Include(u => u.UserDetail)
            .Include(u => u.UserInRoles)
            .ThenInclude(ur => ur.Role)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email && !x.IsDeleted, cancellationToken);
    }
}