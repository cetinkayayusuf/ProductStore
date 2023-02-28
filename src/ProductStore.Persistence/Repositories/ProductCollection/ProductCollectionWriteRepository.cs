using ProductStore.Application.Repositories;
using ProductStore.Domain.Entities;
using ProductStore.Persistence.Context;
using ProductStore.Persistance.Repositories;

namespace ProductStore.Infrastructure.Persistance;
public class ProductCollectionWriteRepository : WriteRepository<ProductCollection>, IProductCollectionWriteRepository
{
    public ProductCollectionWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
