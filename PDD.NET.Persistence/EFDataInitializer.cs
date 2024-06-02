using PDD.NET.Application.Repositories;

namespace PDD.NET.Persistence;

public class EFDataInitializer : IDataInitializer
{
    protected readonly DatabaseContext Context;

    public EFDataInitializer(DatabaseContext context)
    {
        Context = context;
    }

    public void InitData()
    {
        Context.Database.EnsureDeleted();

        Context.Database.EnsureCreated();

        Context.AddRange(FakeDataFactory.Users);

        Context.AddRange(FakeDataFactory.UserDetails);

        Context.AddRange(FakeDataFactory.Roles);

        Context.AddRange(FakeDataFactory.UserInRoles);
        
        Context.AddRange(FakeDataFactory.ExamHistories);

        Context.AddRange(FakeDataFactory.Questions);

        Context.AddRange(FakeDataFactory.QuestionCategories);

        Context.AddRange(FakeDataFactory.AnswerOptions);

        Context.AddRange(FakeDataFactory.UserInAnswerHistories);

        Context.SaveChanges();
    }
}