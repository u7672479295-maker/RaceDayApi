using System.ComponentModel.DataAnnotations;
namespace RaceDayApi.DataTransferObjects
{
    public class CreateCategoryDto
    {
        [Required]
        public int EventID {  get; set; }

        [Required]
        public string Name { get; set; }=  string.Empty;
        //Name of event, e.g Soweto Marathon

        [Required]
        public decimal DistanceKm { get; set; }

        [Required]
        public decimal RegistrationFee { get; set; }

        [Required]
        public int MaxCapacity { get; set; }
    }
}
