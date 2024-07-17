using AutoMapper;
using OtakuTrack.Domain.DTOs;
using OtakuTrack.Domain.Entities;
using OtakuTrack.Repositories.Interfaces;
using OtakuTrack.Services.Interfaces;
using OtakuTrack.Services.Interfaces.LogError;

namespace OtakuTrack.Services.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;
        private readonly IMapper _mapper;
        private readonly IErrorLogService _logService;

        public GenreService(IGenreRepository repository, IMapper mapper, IErrorLogService logService)
        {
            _repository = repository;
            _mapper = mapper;
            _logService = logService;
        }

        public async Task<IEnumerable<GenreDTO>> GetAllGenresAsync()
        {
            var genres = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<GenreDTO>>(genres);
        }

        public async Task<GenreDTO> GetGenreByIdAsync(int id)
        {
            var genre = await _repository.GetByIdAsync(id);
            return genre == null ? null : _mapper.Map<GenreDTO>(genre);
        }

        public async Task<GenreDTO> AddGenreAsync(CreateGenreDTO genreCreateDto)
        {
            try
            {
                var genre = _mapper.Map<Genre>(genreCreateDto);
                await _repository.AddAsync(genre);
                return _mapper.Map<GenreDTO>(genre);
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync(ex.Message, ex.StackTrace);
                throw;
            }
        }

        public async Task<GenreDTO> UpdateGenreAsync(int id, UpdateGenreDTO genreUpdateDto)
        {
            try
            {
                var genre = await _repository.GetByIdAsync(id);

                if (genre == null) { return null; }

                _mapper.Map(genreUpdateDto, genre);
                await _repository.UpdateAsync(genre);

                return _mapper.Map<GenreDTO>(genre);
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync(ex.Message, ex.StackTrace);
                throw;
            }
        }

        public async Task<bool> DeleteGenreAsync(int id)
        {
            try
            {
                var genre = await _repository.GetByIdAsync(id);
                if (genre == null) { return false; }

                await _repository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync(ex.Message, ex.StackTrace);
                throw;
            }
        }
    }
}
