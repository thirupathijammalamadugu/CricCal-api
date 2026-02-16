using System.ComponentModel.DataAnnotations;

namespace Competition.API.Modules.Tournments
{
    public class TournamentCreateRequest
    {
        [Required(ErrorMessage = "Tournament name is required")]
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalTeams { get; set; }
        public int OversPerMatch { get; set; }
        public string Status { get; set; } = null!;
        public Guid CreatedByUserId { get; set; }
        public bool IsPublic { get; set; }
    }
}