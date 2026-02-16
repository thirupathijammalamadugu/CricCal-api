namespace Competition.API.Modules.Teams
{
    public class TeamCreateRequest
    {
        public string Name { get; set; } = null!;
        public string? ShortName { get; set; }
        public Guid TournamentId { get; set; }
        public int NumberOfPlayers { get; set; }
        public string? LogoUrl { get; set; }
        public Guid CreatedByUserId { get; set; }
    }
}
