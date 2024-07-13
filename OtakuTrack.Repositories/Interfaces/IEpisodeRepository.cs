using OtakuTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtakuTrack.Repositories.Interfaces
{
    public interface IEpisodeRepository
    {
        Task<IEnumerable<Episode>> GetAllAsync();
        Task<Episode> GetByIdAsync(int id);
        Task AddAsync(Episode entity);
        Task UpdateAsync(Episode entity);
        Task DeleteAsync(int id);
    }
}
