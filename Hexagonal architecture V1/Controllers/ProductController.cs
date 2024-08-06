using Core.Interfaces;
using Core.Models;
using Hexagonal_architecture_V1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Hexagonal_architecture_V1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly ILoggingService _loggingService;

    public ProductController(IProductRepository productRepository, ILoggingService loggingService)
    {
        _productRepository = productRepository;
        _loggingService = loggingService;
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

        var createdProduct = await _productRepository.GetProductByIdAsync(Guid.Parse(product.Id));
        // Write log
        await _loggingService.LogInfo($"Created: {JsonSerializer.Serialize(createdProduct)}");
        if (!created)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
    }
}
