namespace IOManagement.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TenantId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get;  set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
