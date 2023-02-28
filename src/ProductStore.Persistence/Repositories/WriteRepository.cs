using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductStore.Application.Repositories;
using ProductStore.Domain.Common;

namespace ProductStore.Persistance.Repositories;
public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity
{
    private DbContext _context = null;
    private DbSet<TEntity> table = null;

    public WriteRepository(DbContext _context)
    {
        this._context = _context;
        table = _context.Set<TEntity>();
    }

    public async Task<bool> AddAsync(TEntity model)
    {
        EntityEntry<TEntity> entityEntry = await table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
    }
    public async Task<bool> AddRangeAsync(List<TEntity> datas)
    {
        await table.AddRangeAsync(datas);
        return true;
    }
    public bool Remove(TEntity model)
    {
        EntityEntry<TEntity> entityEntry = table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }
    public bool RemoveRange(List<TEntity> datas)
    {
        table.RemoveRange(datas);
        return true;
    }
    public async Task<bool> RemoveAsync(string id)
    {
        TEntity model = await table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        return Remove(model);
    }
    public bool Update(TEntity model)
    {
        EntityEntry entityEntry = table.Update(model);
        return entityEntry.State == EntityState.Modified;
    }
    public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();
}
