using ProductStore.Application.Repositories;
using ProductStore.Domain.Entities;
using ProductStore.Persistence.Context;
using ProductStore.Persistance.Repositories;

namespace ProductStore.Infrastructure.Persistance;
public class ProductCollectionReadRepository : ReadRepository<ProductCollection>, IProductCollectionReadRepository
{
    public ProductCollectionReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
