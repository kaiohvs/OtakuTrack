using OtakuTrack.Domain.DTOs;

namespace OtakuTrack.Services.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDTO>> GetAllGenresAsync();
        Task<GenreDTO> GetGenreByIdAsync(int id);
        Task<GenreDTO> AddGenreAsync(CreateGenreDTO createGenreDto);
        Task<GenreDTO> UpdateGenreAsync(int id, UpdateGenreDTO updateGenreDto);
        Task<bool> DeleteGenreAsync(int id);
    }
}
