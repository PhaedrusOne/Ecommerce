using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels
{
    public class AddMenuViewModel
    {       
        [Required]
        [Display(Name = "Menu Name")]
        public string Name { get; set; }
    }
}
