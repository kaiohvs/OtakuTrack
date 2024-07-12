using OtakuTrack.Domain.Entities;

namespace OtakuTrack.Repositories.Interfaces
{
    public interface IAnimeRepository
    {
        Task<IEnumerable<Anime>> GetAllAsync();
        Task<Anime> GetByIdAsync(int id);
        Task AddAsync(Anime entity);
        Task UpdateAsync(Anime entity);
        Task DeleteAsync(int id);
    }
}
