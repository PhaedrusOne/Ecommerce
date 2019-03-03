using Microsoft.AspNetCore.Mvc.Rendering;
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
        [Display(Name = "Time")]
        public DateTime OrderDate { get; set; }

        public DateTime DeliverDate { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int CategoryID { get; set; }

        public List<SelectListItem> Customers { get; set; }


    }
}
