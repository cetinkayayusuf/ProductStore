using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProductStore.Application.Repositories;
using ProductStore.Domain.Common;

namespace ProductStore.Persistance.Repositories;
public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
{
    private DbContext _context = null;
    private DbSet<TEntity> table = null;

    public ReadRepository(DbContext _context)
    {
        this._context = _context;
        table = _context.Set<TEntity>();
    }

    public virtual IQueryable<TEntity> GetAll(bool tracking = true)
    {
        var query = table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }

    public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method, bool tracking = true)
    {
        var query = table.Where(method);
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }
    public async Task<TEntity> GetByIdAsync(string id, bool tracking = true)
    {
        var query = table.AsQueryable();
        if (!tracking)
            query = table.AsNoTracking();
        return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
    }

    public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true)
    {
        var query = table.AsQueryable();
        if (!tracking)
            query = table.AsNoTracking();
        return await query.FirstOrDefaultAsync(method);
    }
}
