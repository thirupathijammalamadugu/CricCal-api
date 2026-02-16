using AutoMapper;
using System.Security.Claims;

namespace Competition.API.Modules.Tournments
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;

        public TournamentService(ITournamentRepository tournamentRepository, IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }
        
        public async Task<Guid> CreateTournamentAsync(TournamentCreateRequest request)
        {
            var tournament = _mapper.Map<Tournament>(request);
            return await _tournamentRepository.CreateTournamentAsync(tournament);
        }

        public async Task<IEnumerable<TournamentResponse>> GetAllTournamentsAsync(ClaimsPrincipal user)
        {
            var userId = Guid.Empty;
            if (user.FindFirst(ClaimTypes.NameIdentifier) is not null)
            {
                userId = Guid.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? Guid.Empty.ToString());
                var tournaments = await _tournamentRepository.GetAllTournamentsAsync(userId);
                return tournaments.Select(t => _mapper.Map<TournamentResponse>(t));
            }
            else
            {
                var tournaments = await _tournamentRepository.GetAllPublicTournamentsAsync();
                return tournaments.Select(t => _mapper.Map<TournamentResponse>(t));
            } 
        }

        public async Task<TournamentResponse> GetTournamentByIdAsync(Guid tournamentId)
        {
            var tournament = await _tournamentRepository.GetTournamentByIdAsync(tournamentId);
            return _mapper.Map<TournamentResponse>(tournament);
        }
    }
}