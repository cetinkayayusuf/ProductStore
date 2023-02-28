namespace ProductStore.Domain.Common
{
    public interface ISoftDelete
    {
        bool Deleted { get; set; }
    }
}