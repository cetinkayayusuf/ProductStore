using ProductStore.Application.Repositories;
using ProductStore.Domain.Entities;
using ProductStore.Persistence.Context;
using ProductStore.Persistance.Repositories;

namespace ProductStore.Infrastructure.Persistance;
public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
{
    public CategoryWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
