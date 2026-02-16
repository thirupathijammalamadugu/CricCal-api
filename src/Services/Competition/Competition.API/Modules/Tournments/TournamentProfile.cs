using AutoMapper;
using Competition.API.Modules.Tournments;

namespace Competition.API.Modules.Tournments
{
    public class TournamentProfile : Profile
    {
        public TournamentProfile()
        {
            CreateMap<TournamentCreateRequest, Tournament>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "Draft"))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Tournament, TournamentResponse>();
        }
    }
}