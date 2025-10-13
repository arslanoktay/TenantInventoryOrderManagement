using IOManagement.Application.Contracts.Identity;

namespace IOManagement.Infrastructure.Persistence.DesignTime;

internal class DummyTenantProvider : ITenantProvider
{
    public string? GetTenantId()
    {
        // For migrations dummy tenant id
        return "default-tenant";
    }
}
