namespace OtakuTrack.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }

        // Chave estrangeira para Anime
        public int AnimeId { get; set; }
        public Anime Anime { get; set; }

        // Chave estrangeira para User (se houver)
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
