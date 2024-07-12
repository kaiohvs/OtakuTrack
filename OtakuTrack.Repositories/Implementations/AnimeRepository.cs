

using Microsoft.EntityFrameworkCore;
using OtakuTrack.Domain.Entities;
using OtakuTrack.Infrastructure.BdContext;
using OtakuTrack.Repositories.Interfaces;

namespace OtakuTrack.Repositories.Implementations
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly OtakuContext _context;

        public AnimeRepository(OtakuContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Anime>> GetAllAsync()
        {
            var list = await _context.Animes
                .Include(g => g.Genre)
                .Include(r => r.Reviews)
                .ToListAsync();

            return list;
        }
        public async Task<Anime> GetByIdAsync(int id)
        {
            return await _context.Animes
                .Include(g => g.Genre)
                .Include(r => r.Reviews)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddAsync(Anime entity)
        {
             await _context.Animes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Animes.FindAsync(id);
            if (entity != null)
            {
                _context.Animes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Anime entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
