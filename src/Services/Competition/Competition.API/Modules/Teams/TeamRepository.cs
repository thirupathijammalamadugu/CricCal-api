using Microsoft.EntityFrameworkCore;

namespace Competition.API.Modules.Teams
{
    public class TeamRepository : ITeamRepository
    {
        private readonly CompetitionDbContext _context;

        public TeamRepository(CompetitionDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateTeamAsync(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return team.Id;
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync(Guid tournamentId)
        {
            return await _context.Teams
                .AsNoTracking()
                .Where(t => t.TournamentId == tournamentId)
                .OrderBy(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<Team> GetTeamByIdAsync(Guid teamId)
        {
            return await _context.Teams
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == teamId);
        }
    }
}
