using Core.Interfaces;
using Core.Models;
using Hexagonal_architecture_V1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hexagonal_architecture_V1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productRepository.GetAllAsync();
        if (products == null)
        {
            return NotFound();
        }

        return Ok(products);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductDto productDto)
    {
        var product = new Product
        {
            Id = Guid.NewGuid().ToString(),
            Name = productDto.Name,
            Price = productDto.Price
        };

        var created = await _productRepository.AddProductAsync(product);
        if (!created)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
    }
}
