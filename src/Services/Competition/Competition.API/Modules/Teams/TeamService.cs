using AutoMapper;
using System.Security.Claims;

namespace Competition.API.Modules.Teams
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateTeamAsync(TeamCreateRequest request)
        {
            var team = _mapper.Map<Team>(request);
            return await _teamRepository.CreateTeamAsync(team);
        }

        public async Task<IEnumerable<TeamResponse>> GetAllTeamsAsync(Guid tournamentId)
        {
            var teams = await _teamRepository.GetAllTeamsAsync(tournamentId);
            return teams.Select(t => _mapper.Map<TeamResponse>(t));
        }

        public async Task<TeamResponse> GetTeamByIdAsync(Guid teamId)
        {
            var team = await _teamRepository.GetTeamByIdAsync(teamId);
            return _mapper.Map<TeamResponse>(team);
        }
    }
}
