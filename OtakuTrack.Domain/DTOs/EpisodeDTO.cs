using OtakuTrack.Domain.Entities;

namespace OtakuTrack.Domain.DTOs
{
    public class EpisodeDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EpisodeNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AnimeId { get; set; }
    }

    public class CreateEpisodeDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int EpisodeNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AnimeId { get; set; }
    }

    public class UpdateEpisodeDTO
    {        
        public string Title { get; set; }
        public string Description { get; set; }
        public int EpisodeNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AnimeId { get; set; }
    }
}
