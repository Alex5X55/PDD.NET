using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence.Repositories;

public class UserDetailRepository : BaseRepository<UserDetail>, IUserDetailRepository
{
    public UserDetailRepository(DatabaseContext context) : base(context)
    {
    }
}
