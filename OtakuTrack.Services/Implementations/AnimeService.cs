using AutoMapper;
using OtakuTrack.Domain.DTOs;
using OtakuTrack.Domain.Entities;
using OtakuTrack.Repositories.Interfaces;
using OtakuTrack.Services.Interfaces;
using OtakuTrack.Services.Interfaces.LogError;

namespace OtakuTrack.Services.Implementations
{
    public class AnimeService : IAnimeService
    {
        private readonly IAnimeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IErrorLogService _logService;

        public AnimeService(IAnimeRepository repository, IMapper mapper, IErrorLogService logService)
        {
            _repository = repository;
            _mapper = mapper;
            _logService = logService;
        }

        public async Task<AnimeDTO> CreateAnimeAsync(CreateAnimeDTO animeCreateDto)
        {
            try
            {
                var anime = _mapper.Map<Anime>(animeCreateDto);
                await _repository.AddAsync(anime);

                return _mapper.Map<AnimeDTO>(anime);
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync(ex.Message, ex.StackTrace);
                throw;
            }
        }

        public async Task<bool> DeleteAnimeAsync(int id)
        {
            try
            {
                var anime = await _repository.GetByIdAsync(id);
                if(anime == null) { return false; }

                await _repository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync(ex.Message, ex.StackTrace);
                throw;
            }
        }

        public async Task<IEnumerable<AnimeDTO>> GetAllAnimesAsync()
        {
            try
            {
                var animes = await _repository.GetAllAsync();

                return _mapper.Map<IEnumerable<AnimeDTO>>(animes);
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync(ex.Message, ex.StackTrace);
                throw;
            }
        }

        public async Task<AnimeDTO> GetAnimeByIdAsync(int id)
        {
            try
            {
                var anime = await _repository.GetByIdAsync(id);

                return _mapper.Map<AnimeDTO>(anime);
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync(ex.Message, ex.StackTrace);
                throw;
            }
        }

        public async Task<AnimeDTO> UpdateAnimeAsync(int id, UpdateAnimeDTO animeUpdateDto)
        {
            try
            {
                var anime = await _repository.GetByIdAsync(id);

                if (anime == null) { return null; }

                _mapper.Map(animeUpdateDto, anime);
                await _repository.UpdateAsync(anime);

                return _mapper.Map<AnimeDTO>(anime);


            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync(ex.Message, ex.StackTrace);
                throw;
            }
        }
    }
}
