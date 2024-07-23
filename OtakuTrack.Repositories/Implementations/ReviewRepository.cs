using Microsoft.EntityFrameworkCore;
using OtakuTrack.Domain.Entities;
using OtakuTrack.Infrastructure.BdContext;
using OtakuTrack.Repositories.Interfaces;

namespace OtakuTrack.Repositories.Implementations
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly OtakuContext _context;

        public ReviewRepository(OtakuContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _context.Reviews
                .Include(r => r.Anime)
                .Include(r => r.User)
                .ToListAsync();
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            return await _context.Reviews
                .Include(r => r.Anime)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(Review entity)
        {
            await _context.Reviews.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Review entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Reviews.FindAsync(id);
            if (entity != null)
            {
                _context.Reviews.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}