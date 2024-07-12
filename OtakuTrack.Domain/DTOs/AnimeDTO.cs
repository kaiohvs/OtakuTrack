namespace OtakuTrack.Domain.DTOs
{
    public class AnimeDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Episodes { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
    }

    public class CreateAnimeDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Episodes { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
    }

    public class UpdateAnimeDTO
    {        
        public string Title { get; set; }
        public string Description { get; set; }
        public int Episodes { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
    }
}
