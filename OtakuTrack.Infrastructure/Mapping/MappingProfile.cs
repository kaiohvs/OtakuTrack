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
            //CreateMap<Review, ReviewDTO>()
            //    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username));
            CreateMap<CreateAnimeDTO, Anime>();
            CreateMap<UpdateAnimeDTO, Anime>();
        }
    }
}
