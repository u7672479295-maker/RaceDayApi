using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RaceDayApi.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int EventId { get; set; }
        [Required, StringLength(100)] public string Name { get; set; } = string.Empty; [Column(TypeName = "decimal(18,2)")] public decimal DistanceKm { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal RegistrationFee { get; set; }
        public int MaxCapacity { get; set; }
        public Event? Event { get; set; }
        public ICollection<Enrolment> Enrolments { get; set; }
        = new List<Enrolment>();
    }
}

