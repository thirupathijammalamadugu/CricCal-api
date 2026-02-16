namespace Competition.API.Modules.Squads
{
    public class SquadPlayerCreateRequest
    {
        public string PlayerName { get; set; } = null!;
        public PlayerRole Role { get; set; }
        public int JerseyNumber { get; set; }
        public bool IsPlaying { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsViceCaptain { get; set; }
    }
}
