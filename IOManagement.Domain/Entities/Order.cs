

using IOManagement.Domain.Enums;

namespace IOManagement.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string TenantId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime CreatedAt { get; set; }
    }
}
