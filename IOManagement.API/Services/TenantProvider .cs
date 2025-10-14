using IOManagement.Application.Contracts.Identity;

namespace IOManagement.API.Services;

public class TenantProvider : ITenantProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TenantProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? GetTenantId()
    {
        // Gelen isteğin context'inden kullanıcı (User) bilgisini al.
        // Kullanıcının kimliği doğrulandıktan sonra, token'daki "tenant_id" claim'ini bul ve değerini döndür.
        return _httpContextAccessor.HttpContext?.User?.FindFirst("tenant_id")?.Value;
    }
}
