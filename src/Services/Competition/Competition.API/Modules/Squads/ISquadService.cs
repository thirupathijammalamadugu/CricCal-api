using System.Security.Claims;

namespace Competition.API.Modules.Squads
{
    public interface ISquadService
    {
        Task<Guid> CreateSquadAsync(SquadCreateRequest request);
        Task<IEnumerable<Squad>> GetSquadByTeamIdAsync(Guid teamId);
        Task<Squad> GetSquadByIdAsync(Guid squadId);
    }
}
