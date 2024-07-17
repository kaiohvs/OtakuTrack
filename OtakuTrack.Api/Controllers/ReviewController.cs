using Microsoft.AspNetCore.Mvc;
using OtakuTrack.Domain.DTOs;
using OtakuTrack.Services.Interfaces;

namespace OtakuTrack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;

        public ReviewController(IReviewService reviewService)
        {
            _service = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _service.GetAllReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var review = await _service.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDTO reviewDto)
        {
            var createdReview = await _service.AddReviewAsync(reviewDto);
            return CreatedAtAction(nameof(GetReviewById), new { id = createdReview.Id }, createdReview);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] UpdateReviewDTO reviewDto)
        {           

            var updatedReview = await _service.UpdateReviewAsync(id, reviewDto);
            if (updatedReview == null)
            {
                return NotFound();
            }
            return Ok(updatedReview);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var deleted = await _service.DeleteReviewAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
