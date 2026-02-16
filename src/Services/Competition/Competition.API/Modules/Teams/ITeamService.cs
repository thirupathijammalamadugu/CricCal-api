using System.Security.Claims;

namespace Competition.API.Modules.Teams
{
    public interface ITeamService
    {
        Task<Guid> CreateTeamAsync(TeamCreateRequest request);
        Task<IEnumerable<TeamResponse>> GetAllTeamsAsync(Guid tournamentId);
        Task<TeamResponse> GetTeamByIdAsync(Guid teamId);
    }
}
