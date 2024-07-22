using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PDD.NET.Domain.Entities;
namespace PDD.NET.Persistence.Services;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("Auth");
    }

    public DbSet<Todo> Todos { get; set; }
    public  DbSet<RefreshToken> RefreshTokens { get; set; }
}
