using Microsoft.EntityFrameworkCore;
using OtakuTrack.Domain.Entities;
using OtakuTrack.Infrastructure.BdContext;
using OtakuTrack.Repositories.Interfaces;

namespace OtakuTrack.Repositories.Implementations
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly OtakuContext _context;

        public EpisodeRepository(OtakuContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Episode>> GetAllAsync()
        {
            return await _context.Episodes.ToListAsync();
        }

        public async Task<Episode> GetByIdAsync(int id)
        {
            return await _context.Episodes.FindAsync(id);
        }

        public async Task AddAsync(Episode entity)
        {
            await _context.Episodes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Episode entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Episodes.FindAsync(id);
            if (entity != null)
            {
                _context.Episodes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}