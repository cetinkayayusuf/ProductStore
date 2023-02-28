using ProductStore.Application.Repositories;
using ProductStore.Domain.Entities;
using ProductStore.Persistence.Context;
using ProductStore.Persistance.Repositories;

namespace ProductStore.Infrastructure.Persistance;
public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
{
    public ProductWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
