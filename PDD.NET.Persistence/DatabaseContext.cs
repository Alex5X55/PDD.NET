using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<UserDetail> UserDetails { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserInRole> UserInRoles { get; set; }

    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionCategory> QuestionCategories { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<User>()
            .HasOne(u => u.UserDetail)
            .WithOne(ud => ud.User)
            .HasForeignKey<UserDetail>(ud => ud.UserId);

        modelBuilder.Entity<UserInRole>().HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder
            .Entity<UserInRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserInRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder
            .Entity<UserInRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserInRoles)
            .HasForeignKey(ur => ur.RoleId);

        modelBuilder.Entity<User>().Property(x => x.Login).HasMaxLength(100);
        modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(100);

        modelBuilder.Entity<Question>()
            .HasOne<QuestionCategory>(x => x.Category)
            .WithMany(r => r.Questions)
            .HasForeignKey(x=>x.CategoryId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
}
