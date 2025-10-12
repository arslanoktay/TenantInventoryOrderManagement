using IOManagement.Domain.Entities;

namespace IOManagement.Application.Contracts.Persistence
{

    public interface IProductRepository : IRepository<Product>
    {
        Task<IReadOnlyList<Product>> GetProductsByBrandAsync(string brand);
    }
}
