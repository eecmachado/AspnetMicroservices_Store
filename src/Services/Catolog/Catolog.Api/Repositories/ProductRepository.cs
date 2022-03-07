using Catolog.Api.Data.Interfaces;
using Catolog.Api.Entities;
using Catolog.Api.Repositories.Interfaces;
using MongoDB.Driver;

namespace Catolog.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ICatalogContext _context;

    public ProductRepository(ICatalogContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products
            .Find(p => true)
            .ToListAsync();
    }

    public async Task<Product> Get(string id)
    {
        return await _context.Products
            .Find(p => p.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetByName(string name)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Name, name);

        return await _context.Products
            .Find(filter)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetByCategory(string categoryName)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);

        return await _context.Products
            .Find(filter)
            .ToListAsync();
    }

    public async Task Create(Product product)
    {
        await _context.Products
            .InsertOneAsync(product);
    }

    public async Task<bool> Update(Product product)
    {
        var result = await _context.Products
            .ReplaceOneAsync(p => p.Id == product.Id, product);

        return result.IsAcknowledged
               && result.ModifiedCount > 0;
    }

    public async Task<bool> Delete(string id)
    {
        var result = await _context.Products
            .DeleteOneAsync(p => p.Id == id);

        return result.IsAcknowledged
               && result.DeletedCount > 0;
    }
}