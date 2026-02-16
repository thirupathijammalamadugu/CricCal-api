namespace Competition.API.Modules.Tournments
{
    public class TournamentResponse
    {
        public Guid TournamentId{get;set;}
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalTeams { get; set; }
        public int OversPerMatch { get; set; }
        public string Status { get; set; } = null!;

        public Guid CreatedByUserId { get; set; }

        public bool IsPublic { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}