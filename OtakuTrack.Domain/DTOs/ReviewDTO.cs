using OtakuTrack.Domain.Entities;

namespace OtakuTrack.Domain.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }         
        public string Content { get; set; }
        public int Rating { get; set; }
        public int AnimeId { get; set; }
        public int UserId { get; set; }
    }

    public class CreateReviewDTO
    {
        public string Content { get; set; }
        public int Rating { get; set; }
        public int AnimeId { get; set; }
        public int UserId { get; set; }
    }

    public class UpdateReviewDTO
    {
        public string Content { get; set; }
        public int Rating { get; set; }
        public int AnimeId { get; set; }
        public int UserId { get; set; }
    }
}
