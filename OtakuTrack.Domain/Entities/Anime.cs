namespace OtakuTrack.Domain.Entities
{
    public class Anime
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Episodes { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        // Lista de avaliações para este anime
        public ICollection<Review> Reviews { get; set; }
    }
}
