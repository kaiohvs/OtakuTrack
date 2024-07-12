using OtakuTrack.Domain.Entities.LogError;
using OtakuTrack.Repositories.Interfaces.LogError;
using OtakuTrack.Services.Interfaces.LogError;

namespace OtakuTrack.Services.Implementations.LogError
{
    public class ErrorLogService : IErrorLogService
    {
        private readonly IErrorLogRepository _repository;

        public ErrorLogService(IErrorLogRepository repository)
        {
            _repository = repository;
        }

        public async Task LogErrorAsync(string message, string stackTrace)
        {
            var errorLog = new ErrorLog
            {
                Message = message,
                StakeTrace = stackTrace,
                TimesTamp = DateTime.Now
            };

            await _repository.AddErrorLogAsync(errorLog);
        }
    }
}
