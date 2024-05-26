using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Repositories;

public interface IAnswerRepository : IBaseRepository<AnswerOption>
{
    public Task<AnswerOption> GetUserFullInfo(int id, CancellationToken cancellationToken);
}