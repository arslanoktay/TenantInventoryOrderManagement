using IOManagement.Application.Contracts.Persistence;
using IOManagement.Domain.Entities;
using IOManagement.Infrastructure.Persistence.DbContext;

namespace IOManagement.Infrastructure.Persistence.Repositories;

public class ProductReposiotry : Repository<Product>, IProductRepository
{
    public ProductReposiotry(ApplicationDbContext context) : base(context)
    {
    }

    public Task<IReadOnlyList<Product>> GetProductsByBrandAsync(string brand)
    {
        // This will be added in future
        throw new NotImplementedException();
    }
}
