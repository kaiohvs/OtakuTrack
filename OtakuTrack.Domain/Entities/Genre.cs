namespace OtakuTrack.Domain.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Anime> Animes { get; set; }
    }
}
