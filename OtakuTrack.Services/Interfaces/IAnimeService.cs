using OtakuTrack.Domain.DTOs;

namespace OtakuTrack.Services.Interfaces
{
    public interface IAnimeService
    {
        Task<IEnumerable<AnimeDTO>> GetAllAnimesAsync();
        Task<AnimeDTO> GetAnimeByIdAsync(int id);
        Task<AnimeDTO> CreateAnimeAsync(CreateAnimeDTO animeCreateDto);
        Task<AnimeDTO> UpdateAnimeAsync(int id, UpdateAnimeDTO animeUpdateDto);
        Task<bool> DeleteAnimeAsync(int id);

    }
}
