using System.Reflection;
using AB12.Domain.Base.Common;
using AB12.Domain.Base.Schema;
using AB12.Domain.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AB12.Domain.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ProductConfig)));
            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(OrderConfig)));
            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(OrderItemConfig)));
        }

        // Audit Trailing
        private void Trail()
        {


            ChangeTracker.DetectChanges();

            // while adding
            var adding = this.ChangeTracker.Entries()
                .Where(track => track.State == EntityState.Added)
                .Select(track => track.Entity)
                .ToArray();

            foreach (var entity in adding)
            {
                if (entity is AuditableEntity auditableEntity)
                {
                    auditableEntity.CreatedAt = DateTime.UtcNow;
                    auditableEntity.UpdatedAt = DateTime.UtcNow;
                }
            }

            // while updating
            var updating = this.ChangeTracker.Entries()
                .Where(track => track.State == EntityState.Modified)
                .Select(track => track.Entity)
                .ToArray();
            
            foreach (var entity in updating)
            {
                if (entity is AuditableEntity auditableEntity)
                {
                    auditableEntity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
