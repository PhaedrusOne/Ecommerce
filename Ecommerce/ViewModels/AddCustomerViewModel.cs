using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels
{
    public class AddCustomerViewModel
    {
        [Required(ErrorMessage = "You must give a first name")]
        [Display(Name = " First Name")]
        public string FName { get; set; }

        [Required(ErrorMessage = "You must give a last name")]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Required(ErrorMessage = "You must give a email address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter correct password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        public string Verify { get; set; }
    }
}
