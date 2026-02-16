using AutoMapper;

namespace Competition.API.Modules.Squads
{
    public class SquadProfile : Profile
    {
        public SquadProfile()
        {
            CreateMap<SquadCreateRequest, Squad>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<SquadPlayerCreateRequest, SquadPlayer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
