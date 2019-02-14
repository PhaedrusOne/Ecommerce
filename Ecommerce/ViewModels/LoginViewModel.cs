
using System.ComponentModel.DataAnnotations;


namespace Ecommerce.ViewModels
{
    public class LoginViewModel
    {
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
    }
}
