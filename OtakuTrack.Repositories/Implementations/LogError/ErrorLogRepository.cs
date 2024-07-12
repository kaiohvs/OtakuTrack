using OtakuTrack.Domain.Entities.LogError;
using OtakuTrack.Infrastructure.BdContext;
using OtakuTrack.Repositories.Interfaces.LogError;

namespace OtakuTrack.Repositories.Implementations.LogError
{
    public class ErrorLogRepository : IErrorLogRepository
    {
        private readonly OtakuContext _context;

        public ErrorLogRepository(OtakuContext context)
        {
            _context = context;
        }

        public async Task AddErrorLogAsync(ErrorLog errorLog)
        {
            await _context.ErrorLogs.AddAsync(errorLog);
            await _context.SaveChangesAsync();
        }
    }
}
