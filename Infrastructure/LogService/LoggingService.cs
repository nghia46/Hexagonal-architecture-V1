using Core.Interfaces;
namespace Infrastructure.Log;
public class LoggingService : ILoggingService
{
    private readonly ILoggingRepository _loggingRepository;

    public LoggingService(ILoggingRepository loggingRepository)
    {
        _loggingRepository = loggingRepository;
    }

    public async Task LogInfo(string message)
    {
        await _loggingRepository.LogInfo(message);
    }
}
