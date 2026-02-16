using Microsoft.EntityFrameworkCore;

namespace Competition.API.Modules.Squads
{
    public class SquadRepository : ISquadRepository
    {
        private readonly CompetitionDbContext _context;

        public SquadRepository(CompetitionDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateSquadAsync(Squad squad)
        {
            _context.Squads.Add(squad);
            await _context.SaveChangesAsync();
            return squad.Id;
        }

        public async Task<IEnumerable<Squad>> GetSquadByTeamIdAsync(Guid teamId)
        {
            return await _context.Squads
                .AsNoTracking()
                .Include(s => s.Players)
                .Where(s => s.TeamId == teamId)
                .ToListAsync();
        }

        public async Task<Squad> GetSquadByIdAsync(Guid squadId)
        {
            return await _context.Squads
                .AsNoTracking()
                .Include(s => s.Players)
                .FirstOrDefaultAsync(s => s.Id == squadId);
        }
    }
}
