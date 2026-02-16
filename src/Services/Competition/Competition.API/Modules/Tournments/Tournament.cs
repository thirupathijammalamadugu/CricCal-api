namespace Competition.API.Modules.Tournments
{
    public class Tournament
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null;
        public string? Format { get; set; } = null;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int TotalTeams { get; set; }
        public int OversPerMatch { get; set; }
        public string Status { get; set; } = null!;
        public Guid CreatedByUserId { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
