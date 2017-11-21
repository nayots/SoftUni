using CameraBazaar.Common.Validation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CameraBazaar.Web.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [LettersOnly(ErrorMessage = "Username must contain only letters.")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [ValidPhone(ErrorMessage = "A phone number must start with + followed by 10-12 digits.")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [ValidEmail]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [ValidPassword(ErrorMessage = "A password must contain only lowercase letters and digits and be 3 characters long.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}