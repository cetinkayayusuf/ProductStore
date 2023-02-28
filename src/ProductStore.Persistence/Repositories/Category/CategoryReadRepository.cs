using ProductStore.Application.Repositories;
using ProductStore.Domain.Entities;
using ProductStore.Persistence.Context;
using ProductStore.Persistance.Repositories;

namespace ProductStore.Infrastructure.Persistance;
public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
{
    public CategoryReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
