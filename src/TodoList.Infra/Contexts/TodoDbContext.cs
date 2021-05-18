using Microsoft.EntityFrameworkCore;
using System.Linq;
using TodoList.Domain.Entities;

namespace TodoList.Infra.Contexts
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

                base.OnModelCreating(modelBuilder);
        }
    }
}
