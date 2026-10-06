using System.ComponentModel.DataAnnotations;
namespace RaceDayApi.Models
{ 
    public class EmergencyContact 
    {
        public int EmergencyContactId { get; set; }
        public int ParticipantUserId { get; set; } 
        [Required, StringLength(200)] 
        public string ContactName { get; set; } = string.Empty; 
        [Required, StringLength(20)] 
        public string ContactNumber { get; set; } = string.Empty; 
        [Required, StringLength(100)] 
        public string Relationship { get; set; } = string.Empty;
        [StringLength(100)]
        public string? MedicalAidName { get; set; }
        [StringLength(50)] 
        public string? MedicalAidNumber { get; set; } 
        public User? ParticipantUser { get; set; } 
    }
}