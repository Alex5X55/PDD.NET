using Microsoft.EntityFrameworkCore;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence.Repositories;

public class UserDetailRepository : BaseRepository<UserDetail>, IUserDetailRepository
{
    public UserDetailRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<UserDetail> GetUserDetailByUserId(int userId, CancellationToken cancellationToken)
    {
        return await Context.Set<UserDetail>()
            .FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
    }
}
