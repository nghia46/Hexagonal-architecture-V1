using Core.Interfaces;
using Core.Models;
using Infrastructure.Configurations;

namespace Infrastructure.Repositories;

public class LoggingRepository : ILoggingRepository
{
    private readonly AppDbContext _context;

    public LoggingRepository()
    {
        _context = new AppDbContext();
    }

    public async Task LogInfo(string message)
    {
        var log = new LogModel
        {
            Id = Guid.NewGuid().ToString(),
            Message = message,
            CreatedAt = DateTimeOffset.Now.ToUniversalTime()
        };

        await _context.Logs.AddAsync(log);
        await _context.SaveChangesAsync();
    }
}
