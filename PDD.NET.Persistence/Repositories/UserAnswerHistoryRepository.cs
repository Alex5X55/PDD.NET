using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence.Repositories;

public class UserAnswerHistoryRepository : BaseRepository<UserInAnswerHistory>, IUserAnswerHistoryRepository
{
    public UserAnswerHistoryRepository(DatabaseContext context) : base(context)
    {
    }
}