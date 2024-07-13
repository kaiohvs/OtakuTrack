using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtakuTrack.Domain.Entities
{
    public class Episode
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int EpisodeNumber { get; set; }
        public int AnimeId { get; set; }
        public Anime Anime { get; set; }
    }
}
