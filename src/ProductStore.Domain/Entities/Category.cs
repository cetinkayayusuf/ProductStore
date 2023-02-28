using ProductStore.Domain.Common;

namespace ProductStore.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}