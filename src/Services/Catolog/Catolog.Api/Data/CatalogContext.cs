using Catolog.Api.Configurations.Interfaces;
using Catolog.Api.Data.Interfaces;
using Catolog.Api.Entities;
using MongoDB.Driver;

namespace Catolog.Api.Data;

public class CatalogContext : ICatalogContext
{
    public CatalogContext(IMongoDatabase mongoDatabase, IMongoDbConfiguration mongoDbConfiguration)
    {
        Products = mongoDatabase.GetCollection<Product>(mongoDbConfiguration.Collection);
        Products.SeedData();
    }

    public IMongoCollection<Product> Products { get; }
}