using OtakuTrack.Domain.Entities;

namespace OtakuTrack.Domain.DTOs
{
    public class GenreDTO
    {
        public int Id { get; set; }         
        public string Name { get; set; }
 
    }

    public class CreateGenreDTO
    {
        public string Name { get; set; }
    }

    public class UpdateGenreDTO
    {
        public string Name { get; set; }
    }
}
