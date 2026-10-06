using RaceDayApi.Models;
using System.ComponentModel.DataAnnotations;
    
namespace RaceDayApi.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        public int  Enrolment { get; set;  }

        [Required, StringLength(50)]
        public string FinishTime { get; set; }
        = string.Empty; //Format: "HH: MM: SS"

        public int FinishingPosition { get; set; }
        public bool IsDisqualified { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }
        public Enrolment? Enrolment { get; set; }

    }
}
