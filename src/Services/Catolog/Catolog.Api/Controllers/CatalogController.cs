using Catolog.Api.Entities;
using Catolog.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catolog.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly IProductRepository _repository;
    private readonly ILogger<CatalogController> _logger;

    public CatalogController(IProductRepository repository,
        ILogger<CatalogController> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        var products = await _repository.GetAll();
        return Ok(products);
    }

    [HttpGet("{id:length(24)}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    public async Task<ActionResult<Product>> Get(string id)
    {
        var product = await _repository.Get(id);
    
        if (product is not null)
            return Ok(product);
    
        _logger.LogError($"Product with id: {id} not found");
        return NoContent();
    }
    
    [HttpGet("[action]/{category}", Name = "GetByCategory")]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Product>>> GetByCategory(string category)
    {
        var products = await _repository.GetByCategory(category);
        return Ok(products);
    }
    
    [HttpGet("[action]/{name}", Name = "GetByName")]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Product>>> GetByName(string name)
    {
        var products = await _repository.GetByName(name);
        return Ok(products);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Product>> Create([FromBody] Product product)
    {
        await _repository.Create(product);
        return CreatedAtRoute("Get", new {id = product.Id}, product);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] Product product)
    {
        var result = await _repository.Update(product);
        return Ok(result);
    }
    
    [HttpDelete("{id:length(24)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _repository.Delete(id);
        return Ok(result);
    }
}