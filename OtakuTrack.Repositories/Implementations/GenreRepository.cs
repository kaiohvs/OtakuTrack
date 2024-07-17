using Microsoft.EntityFrameworkCore;
using OtakuTrack.Domain.Entities;
using OtakuTrack.Infrastructure.BdContext;
using OtakuTrack.Repositories.Interfaces;

namespace OtakuTrack.Repositories.Implementations
{
    public class GenreRepository : IGenreRepository
    {
        private readonly OtakuContext _context;

        public GenreRepository(OtakuContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task AddAsync(Genre entity)
        {
            await _context.Genres.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Genre entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Genres.FindAsync(id);
            if (entity != null)
            {
                _context.Genres.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}