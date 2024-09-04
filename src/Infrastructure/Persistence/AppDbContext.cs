using System.Reflection;
using Application.Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

// TODO срочно через 10 лет использовать Repository шаблон
public class AppDbContext : DbContext, IApplicationDbContext
{
    public DbSet<AppUser> Users => Set<AppUser>();
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>()
            .HasMany(u => u.TodoItems)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId);

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
