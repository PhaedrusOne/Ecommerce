using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels
{
    public class AddOrderViewModel
    {
        [Required]
        [Display(Name = "Order Name")]
        public string Name { get; set; }
    }
}
