using Catolog.Api.Data;
using Catolog.Api.Data.Interfaces;
using Catolog.Api.Repositories;
using Catolog.Api.Repositories.Interfaces;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionServiceExtensions
{
    public static IServiceCollection AddDependecyInjection(this IServiceCollection services)
    {
        services.AddScoped<ICatalogContext, CatalogContext>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}