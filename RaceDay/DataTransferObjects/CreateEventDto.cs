using System.ComponentModel.DataAnnotations;
namespace RaceDayApi.DataTransferObjects
{
    public class CreateEventDto
    {   
        [Required(ErrorMessage = "Event name is required.")]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; }

        [Required]
        public DateTime Date {  get; set; }

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public string EventType { get; set; } = "Run";
        //"run", "walk", "cycle"

        [Required]
        public int OrganiserUserId { get; set; }


    }
}
