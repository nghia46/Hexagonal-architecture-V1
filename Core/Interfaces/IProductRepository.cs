using Core.Models;

namespace Core.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>?> GetAllAsync();   
    Task<Product?> GetProductByIdAsync(Guid id);
    Task<bool> AddProductAsync(Product product);
}
