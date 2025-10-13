using IOManagement.Application.Contracts.Identity;
using IOManagement.Infrastructure.Persistence.DesignTime;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IOManagement.Infrastructure.Persistence.DbContext;
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        // Bu fabrika, 'dotnet ef' komut satırı aracından çağrıldığı için,
        // appsettings.json'a Presentation.Api projesinden ulaşmamız gerekir.
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../IOManagement.API"))
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(connectionString);

        // ITenantProvider için sahte bir implementasyon sağlıyoruz.
        ITenantProvider tenantProvider = new DummyTenantProvider();

        return new ApplicationDbContext(optionsBuilder.Options, tenantProvider);
    }
}

/*
 * **Bu kod ne yapıyor?**

*   `IDesignTimeDbContextFactory<ApplicationDbContext>` arayüzünü implemente ediyor. `dotnet ef` aracı bu arayüzü arar.
*   `appsettings.json` dosyasını `Presentation.Api` klasöründen bularak veritabanı bağlantı dizgesini (connection string) okur.
*   `DbContextOptionsBuilder` ile veritabanı ayarlarını yapar.
*   En önemlisi, `ApplicationDbContext`'i oluştururken ikinci parametre olarak sahte `DummyTenantProvider`'ı verir.

**3. Migration Komutunu Tekrar Çalıştırın**

Şimdi her şey hazır. Terminalde, solution'ın ana dizinindeyken komutu tekrar çalıştırın:
 */
