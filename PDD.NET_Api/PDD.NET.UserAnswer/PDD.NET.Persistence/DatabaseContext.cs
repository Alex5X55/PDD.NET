using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<ExamHistory> ExamHistories { get; set; }

    public DbSet<AnswerOption> AnswerOptions { get; set; }

    public DbSet<UserInAnswerHistory> UserAnswerHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().Property(x => x.Login).HasMaxLength(100);
        modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(100);

        modelBuilder
            .Entity<ExamHistory>()
            .HasOne(eh => eh.User)
            .WithMany(u => u.ExamHistories)
            .HasForeignKey(ex => ex.UserId);

        modelBuilder
            .Entity<AnswerOption>()
            .HasMany<UserInAnswerHistory>(ur => ur.UserAnswersHistories)
            .WithOne(u => u.AnswerOption)
            .HasForeignKey(ur => ur.AnswerOptionId);

        modelBuilder
            .Entity<UserInAnswerHistory>()
            .HasOne<User>(ur => ur.User)
            .WithMany(u => u.UserInAnswerHistories)
            .HasForeignKey(ur => ur.UserId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
}
