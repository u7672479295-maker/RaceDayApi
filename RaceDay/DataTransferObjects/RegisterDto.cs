using System.ComponentModel.DataAnnotations;

namespace RaceDayApi.DataTransferObjects
{
    public class RegisterDto
    {

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "First name is required")]
        public string FisrtName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        public string LasttName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Rosle is required")]
        public string Role { get; set; } = "Participant"; //"organiser" or participant"

        public string? ContactNumber {  get; set; } 



    }

}
