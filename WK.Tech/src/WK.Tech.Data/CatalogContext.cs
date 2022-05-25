using Microsoft.EntityFrameworkCore;
using WK.Tech.Core;
using WK.Tech.Domain.Entities;

namespace WK.Tech.Data
{
    public class CatalogContext : DbContext, IUnitOfWork
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataRegistration") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataRegistration").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataRegistration").IsModified = false;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}
