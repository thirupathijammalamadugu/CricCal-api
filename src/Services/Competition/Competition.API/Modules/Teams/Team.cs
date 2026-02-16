namespace Competition.API.Modules.Teams
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ShortName { get; set; }
        public Guid TournamentId { get; set; }
        public int NumberOfPlayers { get; set; }
        public string? LogoUrl { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
