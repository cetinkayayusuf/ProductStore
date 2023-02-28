// using System.Linq.Expressions;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.ChangeTracking;
// using Microsoft.EntityFrameworkCore.Metadata.Internal;
// using ProductStore.Application.Repositories;
// using ProductStore.Domain.Common;

// namespace ProductStore.Persistance.Repositories;
// public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
// {
//     private DbContext _context = null;
//     private DbSet<TEntity> table = null;

//     public GenericRepository(DbContext _context)
//     {
//         this._context = _context;
//         table = _context.Set<TEntity>();
//     }

//     public virtual IQueryable<TEntity> GetAll(bool tracking = true)
//     {
//         var query = table.AsQueryable();
//         if (!tracking)
//             query = query.AsNoTracking();
//         return query;
//     }

//     public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method, bool tracking = true)
//     {
//         var query = table.Where(method);
//         if (!tracking)
//             query = query.AsNoTracking();
//         return query;
//     }
//     public async Task<TEntity> GetByIdAsync(string id, bool tracking = true)
//     {
//         var query = table.AsQueryable();
//         if (!tracking)
//             query = table.AsNoTracking();
//         return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
//     }

//     public async Task<bool> AddAsync(TEntity model)
//     {
//         EntityEntry<TEntity> entityEntry = await table.AddAsync(model);
//         return entityEntry.State == EntityState.Added;
//     }
//     public async Task<bool> AddRangeAsync(List<TEntity> datas)
//     {
//         await table.AddRangeAsync(datas);
//         return true;
//     }
//     public bool Remove(TEntity model)
//     {
//         EntityEntry<TEntity> entityEntry = table.Remove(model);
//         return entityEntry.State == EntityState.Deleted;
//     }
//     public bool RemoveRange(List<TEntity> datas)
//     {
//         table.RemoveRange(datas);
//         return true;
//     }
//     public async Task<bool> RemoveAsync(string id)
//     {
//         T model = await table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
//         return Remove(model);
//     }
//     public bool Update(TEntity model)
//     {
//         EntityEntry entityEntry = table.Update(model);
//         return entityEntry.State == EntityState.Modified;
//     }
//     public async Task<int> SaveAsync()
//         => await _context.SaveChangesAsync();

//     // public virtual async Task<IEnumerable<TEntity>> GetAsync(
//     //     Expression<Func<TEntity, bool>> filter = null,
//     //     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
//     //     string includeProperties = "")
//     // {
//     //     IQueryable<TEntity> query = table;

//     //     if (filter != null)
//     //     {
//     //         query = query.Where(filter);
//     //     }

//     //     foreach (var includeProperty in includeProperties.Split
//     //         (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
//     //     {
//     //         query = query.Include(includeProperty);
//     //     }

//     //     if (orderBy != null)
//     //     {
//     //         return await orderBy(query).ToListAsync();
//     //     }
//     //     else
//     //     {
//     //         return await query.ToListAsync();
//     //     }
//     // }

//     // public virtual async Task<TEntity> GetByIdAsync(object id) => await table.FindAsync(id);

//     // public virtual async Task InsertAsync(TEntity obj) => await table.AddAsync(obj);

//     // public virtual async Task UpdateAsync(TEntity obj)
//     // {
//     //     table.Attach(obj);
//     //     _context.Entry(obj).State = EntityState.Modified;
//     // }

//     // public virtual async Task DeleteAsync(object id)
//     // {
//     //     TEntity existing = await table.FindAsync(id);
//     //     if (existing != default)
//     //     {
//     //         if (existing is ISoftDelete softDelete)
//     //         {
//     //             softDelete.Deleted = true;
//     //             table.Attach(existing);
//     //             _context.Entry(existing).State = EntityState.Modified;
//     //         }
//     //         else
//     //             table.Remove(existing);
//     //     }
//     // }

//     // public virtual async Task SaveAsync() => await _context.SaveChangesAsync();
// }
