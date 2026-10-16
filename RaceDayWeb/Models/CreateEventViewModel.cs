using System.ComponentModel.DataAnnotations;


namespace RaceDayWeb.Models
{
    public class CreateEventViewModel
    {
        [Required(ErrorMessage = "Event Name is required.")]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }


        [Required(ErrorMessage = "event date is required.")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set;  }= DateTime.Now.AddDays(30);

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }=string.Empty;

        [Required(ErrorMessage ="Distance is required. (e.g. 10km, 42km, 109km)")]
        public string Distance { get; set; } =string.Empty;

        [Required(ErrorMessage = "select an event type.")]
        public string EventType { get; set; } = "Run";//default option is run, walk, cycle

        public int OrganiserUserId { get; set; }
    }
}
