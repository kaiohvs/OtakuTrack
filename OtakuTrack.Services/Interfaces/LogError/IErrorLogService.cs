namespace OtakuTrack.Services.Interfaces.LogError
{
    public interface IErrorLogService
    {
        Task LogErrorAsync(string message, string stackTrace);
    }
}
