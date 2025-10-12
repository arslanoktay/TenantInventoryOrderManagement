namespace IOManagement.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid TenantId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Processing, Completed, Canceled
        public DateTime CreatedAt { get; set; }
    }
}
