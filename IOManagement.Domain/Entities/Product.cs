namespace IOManagement.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int StockQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
