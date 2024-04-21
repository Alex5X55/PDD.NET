using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence.Repositories;

public class UserInRoleRepository : BaseRepository<UserInRole>, IUserInRoleRepository
{
    public UserInRoleRepository(DatabaseContext context) : base(context)
    {
    }
}