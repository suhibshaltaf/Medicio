using System.ComponentModel.DataAnnotations;

namespace Medicio.PL.ViewModels
{
    public class ResetPasswordVM
    {
        [Required(ErrorMessage = "Password is Required ..")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Password is Required ..")]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        
    }
}
