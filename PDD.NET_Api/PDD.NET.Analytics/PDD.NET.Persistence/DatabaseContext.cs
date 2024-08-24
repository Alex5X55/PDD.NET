using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<AnalyticsData> AnalyticsData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().Property(x => x.Login).HasMaxLength(100);
        modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(100);

        modelBuilder
            .Entity<AnalyticsData>()
            .HasOne(eh => eh.User)
            .WithMany(u => u.AnalyticsDatas)
            .HasForeignKey(ex => ex.UserId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
}
