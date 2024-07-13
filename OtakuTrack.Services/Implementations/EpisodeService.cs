using AutoMapper;
using OtakuTrack.Domain.DTOs;
using OtakuTrack.Domain.Entities;
using OtakuTrack.Repositories.Interfaces;
using OtakuTrack.Services.Interfaces;
using OtakuTrack.Services.Interfaces.LogError;

namespace OtakuTrack.Services.Implementations
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IEpisodeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IErrorLogService _logService;

        public EpisodeService(IEpisodeRepository repository, IMapper mapper, IErrorLogService logService)
        {
            _repository = repository;
            _mapper = mapper;
            _logService = logService;
        }

        public async Task<IEnumerable<EpisodeDTO>> GetAllEpisodesAsync()
        {
            var episodes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<EpisodeDTO>>(episodes);
        }

        public async Task<EpisodeDTO> GetEpisodeByIdAsync(int id)
        {
            var episode = await _repository.GetByIdAsync(id);
            return episode == null ? null : _mapper.Map<EpisodeDTO>(episode);
        }

        public async Task<EpisodeDTO> AddEpisodeAsync(CreateEpisodeDTO episodeCreateDto)
        {
            try
            {
                var episode = _mapper.Map<Episode>(episodeCreateDto);
                await _repository.AddAsync(episode);
                return _mapper.Map<EpisodeDTO>(episode);
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync(ex.Message, ex.StackTrace);
                throw;
            }
        }

        public async Task<EpisodeDTO> UpdateEpisodeAsync(int id, UpdateEpisodeDTO episodeUpdateDto)
        {
            try
            {
                var episode = await _repository.GetByIdAsync(id);

                if (episode == null) { return null; }

                _mapper.Map(episodeUpdateDto, episode);
                await _repository.UpdateAsync(episode);

                return _mapper.Map<EpisodeDTO>(episode);
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync(ex.Message, ex.StackTrace);
                throw;
            }
        }

        public async Task<bool> DeleteEpisodeAsync(int id)
        {
            try
            {
                var episode = await _repository.GetByIdAsync(id);
                if (episode == null) { return false; }

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
