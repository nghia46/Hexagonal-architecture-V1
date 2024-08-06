using Core.Interfaces;
using Core.Models;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository()
    {
        _context = new AppDbContext();
    }

    public async Task<bool> AddProductAsync(Product product)
    {
        _context.Products.Add(product);
        var created = await _context.SaveChangesAsync();
        return created > 0;
    }

    public async Task<IEnumerable<Product>?> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(Guid id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id.ToString());
    }
}
