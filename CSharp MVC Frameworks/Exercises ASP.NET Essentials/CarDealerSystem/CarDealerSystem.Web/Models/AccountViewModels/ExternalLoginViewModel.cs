using System.ComponentModel.DataAnnotations;

namespace CarDealerSystem.Web.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}