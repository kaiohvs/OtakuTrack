using OtakuTrack.Domain.DTOs;

namespace OtakuTrack.Services.Interfaces
{
    public interface IEpisodeService
    {
        Task<IEnumerable<EpisodeDTO>> GetAllEpisodesAsync();
        Task<EpisodeDTO> GetEpisodeByIdAsync(int id);
        Task<EpisodeDTO> AddEpisodeAsync(CreateEpisodeDTO createEpisodeDto);
        Task<EpisodeDTO> UpdateEpisodeAsync(int id, UpdateEpisodeDTO updateEpisodeDto);
        Task<bool> DeleteEpisodeAsync(int id);
    }
}
