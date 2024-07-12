using OtakuTrack.Domain.Entities.LogError;

namespace OtakuTrack.Repositories.Interfaces.LogError
{
    public interface IErrorLogRepository
    {
        Task AddErrorLogAsync(ErrorLog errorLog);
    }
}
