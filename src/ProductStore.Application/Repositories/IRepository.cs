using Microsoft.EntityFrameworkCore;
using ProductStore.Domain.Common;

namespace ProductStore.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
}