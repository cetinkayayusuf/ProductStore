using ProductStore.Domain.Common;
using ProductStore.Domain.Entities.Enums;

namespace ProductStore.Domain.Entities
{
    public class ProductCollection : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ProductCollectionStatus Status { get; set; }

    }
}