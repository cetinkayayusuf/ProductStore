using ProductStore.Application.Repositories;
using ProductStore.Domain.Entities;
using ProductStore.Persistence.Context;
using ProductStore.Persistance.Repositories;

namespace ProductStore.Infrastructure.Persistance;
public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
{
    public ProductReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
