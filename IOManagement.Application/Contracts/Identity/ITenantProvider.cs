namespace IOManagement.Application.Contracts.Identity;

public interface ITenantProvider
{
    string? GetTenantId();  
}
