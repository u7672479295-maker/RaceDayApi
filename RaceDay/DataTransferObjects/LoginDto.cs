using System.ComponentModel.DataAnnotations;

namespace RaceDayApi.DataTransferObjects
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage ="Invalid email format")]
        public string Email { get; set; }= string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }=string.Empty;
    }
}
