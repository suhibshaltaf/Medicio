using System.ComponentModel.DataAnnotations;

namespace Medicio.PL.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Username is Required ..")]

        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is Required ..")]
        [MinLength(5)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required ..")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "  Confirm Password is Required ..")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
