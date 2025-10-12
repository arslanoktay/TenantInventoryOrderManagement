namespace IOManagement.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public string? ImageUrl { get; private set; }

        public void DecreaseStock(int quantity)
        {
            if (StockQuantity < quantity)
                throw new InvalidOperationException("Insufficient stock.");
            StockQuantity -= quantity;
        }
    }
}
