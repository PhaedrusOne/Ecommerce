using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels
{
    public class AddCategoryViewModel
    {
        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
