using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductStore.Domain.Common;
using ProductStore.Domain.Entities;
using ProductStore.Domain.Entities.Identity;

namespace ProductStore.Persistence.Context;

public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
{

    DbSet<Category> Categories { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<ProductCollection> ProductCollections { get; set; }
    DbSet<Notification> Notifications { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
            {
                entityType.AddSoftDeleteQueryFilter();
            }
        }
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<TEntity> Set<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>();
    }

    public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
    {
        return base.Entry<TEntity>(entity);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var insertedEntries = this.ChangeTracker.Entries().Where(x => x.State == EntityState.Added).Select(x => x.Entity);
        foreach (var insertedEntity in insertedEntries)
        {
            var entity = insertedEntity as AuditableEntity;
            if (entity != null)
            {
                entity.CreatorId = string.IsNullOrEmpty(entity.CreatorId) ? "" : entity.CreatorId;
                entity.CreateDate = DateTime.Now;
            }
        }

        var modifiedEntries = this.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).Select(x => x.Entity);
        foreach (var modifiedEntity in modifiedEntries)
        {
            var entity = modifiedEntity as AuditableEntity;
            if (entity != null)
            {
                entity.ModifyDate = DateTime.Now;
            }
        }

        return base.SaveChangesAsync();
    }
}