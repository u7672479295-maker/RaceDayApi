using System.ComponentModel.DataAnnotations;

namespace RaceDayWeb.Models
{
    public class CreateResultViewModel
    {
        [Required]
        public int EnrolmentId { get; set; }

        public int EventId { get; set; }

        [Required(ErrorMessage = "Finish time is required (e.g. 02:45:12).")]
        [StringLength(50)]
        public string FinishTime { get; set; } = string.Empty;

        [Required]
        [Range(1, 10000, ErrorMessage = "Finishing position must be greater than 0.")]
        public int FinishingPosition { get; set; }

        public bool IsDisqualified { get; set; } = false;

        public string? Notes { get; set; }
    }

    public class LeaderboardResultViewModel
    {
        public int ResultId { get; set; }
        public int FinishingPosition { get; set; }
        public string FinishTime { get; set; } = string.Empty;
        public bool IsDisqualified { get; set; }
        public string? Notes { get; set; }
        public string ParticipantName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
    }
}

