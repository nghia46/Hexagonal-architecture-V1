using System.ComponentModel.DataAnnotations;
namespace Core.Models;
public class Product
{
    [MaxLength(255)]
    public required string Id { get; set; }
    [MaxLength(255)]
    public string? Name { get; set; }
    public decimal Price { get; set; }
}
