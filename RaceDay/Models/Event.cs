using System.ComponentModel.DataAnnotations;
namespace RaceDayApi.Models
{
    public class Event
    {
        public int EventId { get; set; }
        [Required, StringLength(200)] public string Name { get; set; } = string.Empty; public string? Description { get; set; }
        public DateTime Date { get; set; }
        [Required, StringLength(200)]
        public string Location { get; set; } = string.Empty;
        [Required, StringLength(50)]

        public string EventType { get; set; } = "Run";

        // 'Run', 'Walk', 'Cycle'
        [StringLength(1000)]
        public string? BannerImageUrl { get; set; }
        public int OrganiserUserId { get; set; }
        public User? OrganiserUser { get; set; }
        public ICollection<Enrolment> Enrolments { get; set; }
        = new List<Category>();
        public ICollection<Enrolment> Enrolments { get; set; }
        = new List<Enrolment>();
    }

}

