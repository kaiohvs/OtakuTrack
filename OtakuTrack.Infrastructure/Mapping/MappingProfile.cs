using AutoMapper;
using OtakuTrack.Domain.DTOs;
using OtakuTrack.Domain.Entities;

namespace OtakuTrack.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Anime, AnimeDTO>()
                 .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId));           
            CreateMap<CreateAnimeDTO, Anime>();
            CreateMap<UpdateAnimeDTO, Anime>();

            // Episode mappings
            CreateMap<Episode, EpisodeDTO>();
            CreateMap<CreateEpisodeDTO, Episode>();
            CreateMap<UpdateEpisodeDTO, Episode>();

            // User mappings
            CreateMap<User, UserDTO>();
            CreateMap<CreateUserDTO, User>();
            CreateMap<UpdateUserDTO, User>();
        }
    }
}
