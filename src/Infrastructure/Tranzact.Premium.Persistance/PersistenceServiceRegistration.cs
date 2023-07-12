using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tranzact.Premium.Application.Contracts.Persistence;
using Tranzact.Premium.Persistence.DatabaseContext;
using Tranzact.Premium.Persistence.Repositories;

namespace Tranzact.Premium.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<PremiumDatabaseContext>(options => {
            options.UseInMemoryDatabase(configuration.GetConnectionString("PremiumConnectionString")!);
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICarrierRepository, CarrierRepository>();
        services.AddScoped<IPlanRepository, PlanRepository>();
        services.AddScoped<IStateRepository, StateRepository>();
        services.AddScoped<IPremiumRepository, PremiumRepository>();

        return services;
    }
}
