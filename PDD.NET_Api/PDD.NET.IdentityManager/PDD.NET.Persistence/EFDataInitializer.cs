﻿using Microsoft.Extensions.Logging;
using PDD.NET.Application.Repositories;
using PDD.NET.Persistence.Services;

namespace PDD.NET.Persistence;

public class EFDataInitializer : IDataInitializer
{
    protected readonly DatabaseContext Context;
    protected readonly AuthDbContext ContextAuth;
    private ILogger<EFDataInitializer> _logger;

    public EFDataInitializer(DatabaseContext context, AuthDbContext contextAuth, ILogger<EFDataInitializer> logger)
    {
        Context = context;
        ContextAuth = contextAuth;
        _logger = logger;
    }

    public void InitData()
    {
        Context.Database.EnsureDeleted();

        Context.Database.EnsureCreated();

        ContextAuth.Database.EnsureDeleted();

        ContextAuth.Database.EnsureCreated();


        Context.AddRange(FakeDataFactory.Users);

        Context.AddRange(FakeDataFactory.UserDetails);

        Context.AddRange(FakeDataFactory.Roles);

        Context.AddRange(FakeDataFactory.UserInRoles);
        
        //Context.AddRange(FakeDataFactory.ExamHistories);

        //Context.AddRange(FakeDataFactory.Questions);

        //Context.AddRange(FakeDataFactory.QuestionCategories);

        //Context.AddRange(FakeDataFactory.AnswerOptions);

        //Context.AddRange(FakeDataFactory.UserInAnswerHistories);

        Context.SaveChanges();
        ContextAuth.SaveChanges();
        _logger.LogInformation("Database updated");
    }
}