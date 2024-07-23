using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PDD.NET.Domain.Entities;
using System.Reflection;
namespace PDD.NET.Persistence.Services;

public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//Your assembly here
/*        modelBuilder.Entity<RefreshToken>()//можно не указывать
            .HasOne<User>(s => s.User)
            .WithOne()
            .HasForeignKey<RefreshToken>(g => g.Id);*/
    }

    //public DbSet<Todo> Todos { get; set; }
    public  DbSet<RefreshToken> RefreshTokens { get; set; }

}
