using AutoMapper;
using OtakuTrack.Domain.DTOs;
using OtakuTrack.Domain.Entities;
using OtakuTrack.Repositories.Interfaces;
using OtakuTrack.Services.Interfaces;
using OtakuTrack.Services.Interfaces.LogError;

namespace OtakuTrack.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repository;
        private readonly IMapper _mapper;
        private readonly IErrorLogService _logService;

        public ReviewService(IReviewRepository repository, IMapper mapper, IErrorLogService logService)
        {
            _repository = repository;
            _mapper = mapper;
            _logService = logService;
        }

        public async Task<IEnumerable<ReviewDTO>> GetAllReviewsAsync()
        {
            var reviews = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }

        public async Task<ReviewDTO> GetReviewByIdAsync(int id)
        {
            var review = await _repository.GetByIdAsync(id);
            return review == null ? null : _mapper.Map<ReviewDTO>(review);
        }

        public async Task<ReviewDTO> AddReviewAsync(CreateReviewDTO reviewCreateDto)
        {
            try
            {
                var review = _mapper.Map<Review>(reviewCreateDto);
                await _repository.AddAsync(review);
                return _mapper.Map<ReviewDTO>(review);
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync(ex.Message, ex.StackTrace);
                throw;
            }
        }

        public async Task<ReviewDTO> UpdateReviewAsync(int id, UpdateReviewDTO reviewUpdateDto)
        {
            try
            {
                var review = await _repository.GetByIdAsync(id);

                if (review == null) { return null; }

                _mapper.Map(reviewUpdateDto, review);
                await _repository.UpdateAsync(review);

                return _mapper.Map<ReviewDTO>(review);
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync(ex.Message, ex.StackTrace);
                throw;
            }
        }

        public async Task<bool> DeleteReviewAsync(int id)
        {
            try
            {
                var review = await _repository.GetByIdAsync(id);
                if (review == null) { return false; }

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
