using OtakuTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtakuTrack.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre> GetByIdAsync(int id);
        Task AddAsync(Genre entity);
        Task UpdateAsync(Genre entity);
        Task DeleteAsync(int id);
    }
}
