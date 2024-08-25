using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PDD.NET.Persistence.Repositories;

public class ExamHistoryRepository : BaseRepository<ExamHistory>, IExamHistoryRepository
{
    public ExamHistoryRepository(DatabaseContext context) : base(context)
    {
    }
}