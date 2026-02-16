using AutoMapper;

namespace Competition.API.Modules.Squads
{
    public class SquadService : ISquadService
    {
        private readonly ISquadRepository _squadRepository;
        private readonly IMapper _mapper;

        public SquadService(ISquadRepository squadRepository, IMapper mapper)
        {
            _squadRepository = squadRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateSquadAsync(SquadCreateRequest request)
        {
            var captains = request.Players.Where(p => p.IsCaptain).ToList();
            if (captains.Count > 1)
            {
                throw new InvalidOperationException("Only one captain is allowed per squad.");
            }

            var viceCaptains = request.Players.Where(p => p.IsViceCaptain).ToList();
            if (viceCaptains.Count > 1)
            {
                throw new InvalidOperationException("Only one vice-captain is allowed per squad.");
            }

            var squad = _mapper.Map<Squad>(request);
            squad.CaptainPlayerId = captains.FirstOrDefault()?.PlayerId;
            squad.ViceCaptainPlayerId = viceCaptains.FirstOrDefault()?.PlayerId;
            
            // Map players and add to squad
            squad.Players = request.Players.Select(p => _mapper.Map<SquadPlayer>(p)).ToList();
            
            return await _squadRepository.CreateSquadAsync(squad);
        }

        public async Task<IEnumerable<Squad>> GetSquadByTeamIdAsync(Guid teamId)
        {
            return await _squadRepository.GetSquadByTeamIdAsync(teamId);
        }

        public async Task<Squad> GetSquadByIdAsync(Guid squadId)
        {
            return await _squadRepository.GetSquadByIdAsync(squadId);
        }
    }
}
