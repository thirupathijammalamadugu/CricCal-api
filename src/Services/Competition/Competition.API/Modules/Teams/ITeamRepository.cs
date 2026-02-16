namespace Competition.API.Modules.Teams
{
    public interface ITeamRepository
    {
        Task<Guid> CreateTeamAsync(Team team);
        Task<IEnumerable<Team>> GetAllTeamsAsync(Guid tournamentId);
        Task<Team> GetTeamByIdAsync(Guid teamId);
    }
}
