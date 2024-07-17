using OtakuTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtakuTrack.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllAsync();
        Task<Review> GetByIdAsync(int id);
        Task AddAsync(Review entity);
        Task UpdateAsync(Review entity);
        Task DeleteAsync(int id);
    }
}
