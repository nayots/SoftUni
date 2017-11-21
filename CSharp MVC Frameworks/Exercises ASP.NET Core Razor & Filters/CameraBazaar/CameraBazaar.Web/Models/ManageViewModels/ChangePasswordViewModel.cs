using CameraBazaar.Common.Validation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CameraBazaar.Web.Models.ManageViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        [ValidPassword(ErrorMessage = "A password must contain only lowercase letters and digits and be 3 characters long.")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}