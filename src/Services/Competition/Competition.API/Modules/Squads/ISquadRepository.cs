namespace Competition.API.Modules.Squads
{
    public interface ISquadRepository
    {
        Task<Guid> CreateSquadAsync(Squad squad);
        Task<IEnumerable<Squad>> GetSquadByTeamIdAsync(Guid teamId);
        Task<Squad> GetSquadByIdAsync(Guid squadId);
    }
}
