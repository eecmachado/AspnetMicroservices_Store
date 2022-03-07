using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();
        services.AddCorrelationId(configuration);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",new OpenApiInfo{Title = "Catalog.Api", Version = "v1"});
        });
        services.AddDependecyInjection();
        services.AddMongoDb(configuration);
        
        return services;
    }
}