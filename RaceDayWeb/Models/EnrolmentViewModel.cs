using System.ComponentModel.DataAnnotations;

namespace RaceDayWeb.Models
{
    public class CreateEnrolmentViewModel
    {
        [Required]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Please select a race category.")]
        public int CategoryId { get; set; }

        public string EventName { get; set; } = string.Empty;
        public List<CategoryViewModel> AvailableCategories { get; set; } = new();
    }

    public class ParticipantEnrolmentViewModel
    {
        public int EnrolmentId { get; set; }
        public DateTime EnrolmentDate { get; set; }
        public string EnrolmentStatus { get; set; } = string.Empty;
        public string EventName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public decimal Fee { get; set; }
    }
}