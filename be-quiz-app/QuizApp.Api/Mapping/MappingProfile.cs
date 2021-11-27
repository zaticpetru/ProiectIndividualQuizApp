using AutoMapper;
using QuizApp.Api.Resources;
using QuizApp.Core.Models;
using QuizApp.Core.Models.Auth;

namespace QuizApp.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to DTO
            CreateMap<Music, MusicDTO>();
            CreateMap<Artist, ArtistDTO>();

            // DTO to Domain
            CreateMap<MusicDTO, Music>();
            CreateMap<ArtistDTO, Artist>();

            CreateMap<SaveMusicDTO, Music>();
            CreateMap<SaveArtistDTO, Artist>();

            CreateMap<UserSignUpDTO, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(ud => ud.Email));
        }
    }
}
