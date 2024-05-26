using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Repositories;

public interface IQuestionRepository : IBaseRepository<Question>
{
    public Task<List<Question>> GetQuestionsByCategoryId(int categoryId, CancellationToken cancellationToken);
}
