using Microsoft.EntityFrameworkCore;

namespace Competition.API.Modules.Tournments
{
   public class TournamentRepository : ITournamentRepository
   {
    private readonly CompetitionDbContext _context;
        public TournamentRepository(CompetitionDbContext context)
        {
            _context = context;
        }
       public async Task<Tournament> GetTournamentByIdAsync(Guid tournamentId)
       {
           return await _context.Tournaments.AsNoTracking().FirstOrDefaultAsync(t => t.Id == tournamentId);
       }

       public async Task<IEnumerable<Tournament>> GetAllTournamentsAsync(Guid userId)
       {
           return await _context.Tournaments
               .AsNoTracking()
               .Where(t => t.CreatedByUserId == userId || t.IsPublic)
               .OrderBy(t => t.CreatedByUserId != userId)
               .ThenBy(t => t.CreatedAt)
               .ToListAsync();
       }

       public async Task<IEnumerable<Tournament>> GetAllPublicTournamentsAsync()
       {
           return await _context.Tournaments
               .AsNoTracking()
               .Where(t => t.IsPublic)
               .OrderBy(t => t.CreatedAt)
               .ToListAsync();
       }

       public async Task<Guid> CreateTournamentAsync(Tournament tournament)
       {
           var tournments = _context.Tournaments.Add(tournament);
           await _context.SaveChangesAsync();
           return tournament.Id;
       }

       public Task UpdateTournamentAsync(Tournament tournament)
       {
           throw new NotImplementedException();
       }

       public Task DeleteTournamentAsync(Guid tournamentId)
       {
           throw new NotImplementedException();
       }

       public async Task<Tournament> GetTournamentByNameAndCreatedByAsync(string Name, Guid CreatedByUserId)
       {
           return await _context.Tournaments
               .FirstOrDefaultAsync(t => t.Name == Name && t.CreatedByUserId == CreatedByUserId);
       }
   }
}