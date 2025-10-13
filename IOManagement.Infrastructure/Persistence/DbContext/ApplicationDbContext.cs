using IOManagement.Application.Contracts.Identity;
using IOManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IOManagement.Infrastructure.Persistence.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    private readonly ITenantProvider _tenantProvider;

    public ApplicationDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext> options, ITenantProvider tenantProvider)
        : base(options)
    {
        _tenantProvider = tenantProvider;
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);

        // GLOBAL QUERY FILTERS
        // Bu filtreler, her sorguya otomatik olarak eklenir.
        // Bu sayede yanlışlıkla başka bir tenant verisini çekme veya
        // silinmiş verileri gösterme riskini ortadan kaldırırız.
        modelBuilder.Entity<Product>().HasQueryFilter(p => p.TenantId == _tenantProvider.GetTenantId() && !p.IsDeleted);
        modelBuilder.Entity<Order>().HasQueryFilter(o => o.TenantId == _tenantProvider.GetTenantId() && !o.IsDeleted);
        modelBuilder.Entity<OrderItem>().HasQueryFilter(oi => oi.TenantId == _tenantProvider.GetTenantId() && !oi.IsDeleted);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var tenantId = _tenantProvider.GetTenantId();

        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.TenantId = tenantId; // Yeni eklenen her kayda TenantId'yi otomatik ata
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
