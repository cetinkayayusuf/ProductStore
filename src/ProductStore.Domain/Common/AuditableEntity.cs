namespace ProductStore.Domain.Common
{
    public abstract class AuditableEntity : BaseEntity, ISoftDelete
    {
        public int CreatorId { get; set; }
        public DateTime CreateDate { get; set; }
        public int ModifierId { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Deleted { get; set; }
    }
}