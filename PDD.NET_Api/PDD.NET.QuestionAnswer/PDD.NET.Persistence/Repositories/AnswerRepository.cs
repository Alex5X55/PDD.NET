using Microsoft.EntityFrameworkCore;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence.Repositories;

public class AnswerRepository : BaseRepository<AnswerOption>, IAnswerRepository
{
    public AnswerRepository(DatabaseContext context) : base(context)
    {
    }
    
    public async Task<AnswerOption> GetAnswerFullInfo(int id, CancellationToken cancellationToken)
    {
        var answer = await Context.Set<AnswerOption>().FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id);
        answer.Question = await Context.Set<Question>().FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == answer.QuestionId);
        return answer;
    }
    
    public override void Create(AnswerOption entity)
    {
        var maxId = Context.Set<AnswerOption>().Select(x=>x.Id).Max();
        entity.Id = maxId + 1;
        base.Create(entity);
    }
}