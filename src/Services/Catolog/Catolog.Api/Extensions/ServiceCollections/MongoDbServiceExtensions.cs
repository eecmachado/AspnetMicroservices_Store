using Catolog.Api.Configurations;
using Catolog.Api.Configurations.Interfaces;
using MongoDB.Driver;

namespace Microsoft.Extensions.DependencyInjection;

public static class MongoDbServiceExtensions
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services,
        IConfiguration configuration)
    {
        var mongoDbConfiguration = configuration.GetSection(MongoDbConfiguration.MongoDb)
            .Get<MongoDbConfiguration>();
        
        services.AddSingleton<IMongoDbConfiguration>(mongoDbConfiguration);
        
        services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoDbConfiguration.ConnectionString));

        services.AddScoped(sp =>
        {
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(mongoDbConfiguration.Database);
        });
        
        services.AddScoped(c => c.GetService<IMongoClient>()?.StartSession());

        return services;
    }
}