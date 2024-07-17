using OtakuTrack.Domain.DTOs;

namespace OtakuTrack.Services.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDTO>> GetAllReviewsAsync();
        Task<ReviewDTO> GetReviewByIdAsync(int id);
        Task<ReviewDTO> AddReviewAsync(CreateReviewDTO createReviewDto);
        Task<ReviewDTO> UpdateReviewAsync(int id, UpdateReviewDTO updateReviewDto);
        Task<bool> DeleteReviewAsync(int id);
    }
}
