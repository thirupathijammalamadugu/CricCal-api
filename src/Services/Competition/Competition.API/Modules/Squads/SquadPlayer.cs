namespace Competition.API.Modules.Squads
{
    public class SquadPlayer
    {
        public Guid Id { get; set; }
        public Guid SquadId { get; set; }
        public string PlayerName { get; set; } = null!;
        public PlayerRole Role { get; set; }
        public int JerseyNumber { get; set; }
        public bool IsPlaying { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UpdatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
