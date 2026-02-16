namespace Competition.API.Modules.Tournments
{
    public interface ITournamentRepository
    {
        Task<Tournament> GetTournamentByIdAsync(Guid tournamentId);
        Task<IEnumerable<Tournament>> GetAllTournamentsAsync(Guid userId);
        Task<IEnumerable<Tournament>> GetAllPublicTournamentsAsync();
        Task<Guid> CreateTournamentAsync(Tournament tournament);
        Task UpdateTournamentAsync(Tournament tournament);
        Task DeleteTournamentAsync(Guid tournamentId);
        Task<Tournament> GetTournamentByNameAndCreatedByAsync(string Name, Guid CreatedByUserId);
    }
}