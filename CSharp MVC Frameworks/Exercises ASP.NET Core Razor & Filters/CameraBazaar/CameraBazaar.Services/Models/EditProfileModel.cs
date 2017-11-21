using CameraBazaar.Common.Validation.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CameraBazaar.Services.Models
{
    public class EditProfileModel
    {
        [Required]
        public string UserId { get; set; }

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

        [Required]
        [Display(Name = "Phone")]
        [ValidPhone(ErrorMessage = "A phone number must start with + followed by 10-12 digits.")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        public DateTime? LastLogin { get; set; }
    }
}