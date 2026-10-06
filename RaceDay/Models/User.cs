using System.ComponentModel.DataAnnotations;

namespace RaceDayApi.Models
{
    public class User
    {   //"Organiser" and "participant" details
        public int UserID { get; set; }

        [Required, EmailAddress, StringLength(256)]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(512)]
        public string PasswordHash { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Role { get; set; } = string.Empty;

        [StringLength(20)]
        public  string?ContactNumber { get; set; }

        [StringLength(1000)]
        public  string? ProfilePictureUrl{ get; set; }


        public DateTime DateRegistered { get; set; } = DateTime.UtcNow;

        //Navigation Properties
        
        public EmergencyContact? EmergencyContact { get; set; }
        public ICollection<Enrolment> Enrolments { get; set; }
        = new List<Enrolment>();

    }

}
