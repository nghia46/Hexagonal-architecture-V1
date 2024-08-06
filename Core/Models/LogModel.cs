using System.ComponentModel.DataAnnotations;
namespace Core.Models;

public class LogModel
{
    [MaxLength(255)]
    public required string Id { get; set; }
    [MaxLength(255)]
    public required string Message { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
