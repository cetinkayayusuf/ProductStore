using ProductStore.Domain.Common;

namespace ProductStore.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}