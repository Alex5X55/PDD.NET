﻿using Microsoft.EntityFrameworkCore;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence.Repositories;

public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
{
    public QuestionRepository(DatabaseContext context) : base(context)
    {
    }

    public override async Task<List<Question>> GetAll(CancellationToken cancellationToken)
    {
        // return await Context.Set<Question>()
        //     .Include(q => q.Category)
        //     .Include(c => c.AnswerOptions.Where(ao => !ao.IsDeleted))
        //     .AsNoTracking()
        //     .Where(x => !x.IsDeleted && !x.Category.IsDeleted)
        //     .ToListAsync(cancellationToken);

        List<Question> questions = await Context.Set<Question>().Where(x => !x.IsDeleted).ToListAsync(cancellationToken);
        List<AnswerOption> answers = await Context.Set<AnswerOption>().Where(x => !x.IsDeleted).ToListAsync(cancellationToken);

        foreach (var question in questions)
        {
            question.AnswerOptions = answers.Where(a => a.QuestionId == question.Id);
        }

        return questions;
    }

    public override async Task<Question> Get(int id, CancellationToken cancellationToken)
    {
        var questions = await Context.Set<Question>().FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id);
        //if (questions != null)
        //    questions.AnswerOptions = await Context.Set<AnswerOption>().Where(x => !x.IsDeleted && x.QuestionId == id).ToListAsync(cancellationToken);

        return questions;
    }

    public override  void Create(Question entity)
    {
        var maxId = Context.Set<Question>().Select(x=>x.Id).Max();
        entity.Id = maxId + 1;
        base.Create(entity);
    }
    public async Task<List<Question>> GetQuestionsByCategoryId(int categoryId, CancellationToken cancellationToken)
    {
        // return await Context.Set<Question>()
        //     .Include(q => q.Category)
        //     .Include(c => c.AnswerOptions.Where(ao => !ao.IsDeleted))
        //     .AsNoTracking()
        //     .Where(x => x.CategoryId == categoryId && !x.IsDeleted)
        //     .ToListAsync(cancellationToken);

        List<Question> questions = await Context.Set<Question>().Where(x => !x.IsDeleted && x.CategoryId == categoryId).ToListAsync(cancellationToken);

        List<int> questionsId = questions.Select(x => x.Id).ToList();
        List<AnswerOption> answers = await Context.Set<AnswerOption>().Where(x => !x.IsDeleted && questionsId.Contains(x.QuestionId)).ToListAsync(cancellationToken);

        foreach (var question in questions)
        {
            question.AnswerOptions = answers.Where(a => a.QuestionId == question.Id);
        }

        return questions;
    }
}