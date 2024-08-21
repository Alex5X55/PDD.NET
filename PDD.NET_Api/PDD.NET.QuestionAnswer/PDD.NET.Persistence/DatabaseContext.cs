using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }

    public DbSet<Question> Questions { get; set; }

    public DbSet<QuestionCategory> QuestionCategories { get; set; }

    public DbSet<AnswerOption> AnswerOptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Question>()
            .HasOne<QuestionCategory>(x => x.Category)
            .WithMany(r => r.Questions)
            .HasForeignKey(x=>x.CategoryId);

        modelBuilder
            .Entity<Question>()
            .HasMany<AnswerOption>(ur => ur.AnswerOptions)
            .WithOne(u => u.Question)
            .HasForeignKey(ur => ur.QuestionId);

        modelBuilder.Entity<AnswerOption>()
            .HasKey(a => a.Id); // Устанавливаем ключ

        modelBuilder.Entity<AnswerOption>()
            .Property(a => a.Id)
            .ValueGeneratedNever(); // Указываем, что значение не будет генерироваться автоматически
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

        Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;
    }
}
