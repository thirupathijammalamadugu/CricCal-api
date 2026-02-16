namespace Competition.API.Modules.Squads
{
    public class Squad
    {
        public Guid Id { get; set; }
        public Guid TeamId { get; set; }
        public SquadStatus Status { get; set; }
        public Guid? CaptainPlayerId { get; set; }
        public Guid? ViceCaptainPlayerId { get; set; }
        public ICollection<SquadPlayer> Players { get; set; } = new List<SquadPlayer>();
        public Guid CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
