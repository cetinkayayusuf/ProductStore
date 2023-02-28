namespace ProductStore.Domain.Common
{
    public abstract class AuditableEntity : BaseEntity, ISoftDelete
    {
        public string CreatorId { get; set; } = default;
        public DateTime CreateDate { get; set; }
        public int ModifierId { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Deleted { get; set; }
    }
}