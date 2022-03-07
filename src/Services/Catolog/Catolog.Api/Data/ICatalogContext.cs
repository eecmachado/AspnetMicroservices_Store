using Catolog.Api.Entities;
using MongoDB.Driver;

namespace Catolog.Api.Data;

public interface ICatalogContext
{
    IMongoCollection<Product> Products { get; }
}