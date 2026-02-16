using AutoMapper;

namespace Competition.API.Modules.Teams
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<TeamCreateRequest, Team>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Team, TeamResponse>();
        }
    }
}
