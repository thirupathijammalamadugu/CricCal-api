namespace Competition.API.Modules.Squads
{
    public class SquadCreateRequest
    {
        public Guid TeamId { get; set; }
        public SquadStatus Status { get; set; }
        public List<SquadPlayerCreateRequest> Players { get; set; } = new();
        public Guid CreatedByUserId { get; set; }
    }
}
