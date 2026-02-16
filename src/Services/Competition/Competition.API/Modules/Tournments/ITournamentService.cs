using System.Security.Claims;

namespace Competition.API.Modules.Tournments
{
    public interface ITournamentService
    {
        Task<Guid> CreateTournamentAsync(TournamentCreateRequest request);
        Task<IEnumerable<TournamentResponse>> GetAllTournamentsAsync(ClaimsPrincipal user);
        Task<TournamentResponse> GetTournamentByIdAsync(Guid tournamentId);
    }   
}