using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "You must give a email address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter correct password")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
