using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels
{
    public class AddProductViewModel
    {
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your product a description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You must give your product a price")]
        public float Price { get; set; }

        public ProductType Type { get; set; }

        public List<SelectListItem> ProductTypes { get; set; }

        public AddProductViewModel()
        {
            ProductTypes = new List<SelectListItem>();

            ProductTypes.Add(new SelectListItem
            {
                Value = ((int)ProductType.Sale).ToString(),
                Text = ProductType.Sale.ToString()
            });

            ProductTypes.Add(new SelectListItem
            {
                Value = ((int)ProductType.Clearance).ToString(),
                Text = ProductType.Clearance.ToString()
            });

            ProductTypes.Add(new SelectListItem
            {
                Value = ((int)ProductType.SoldOut).ToString(),
                Text = ProductType.SoldOut.ToString()
            });

        }
    }
}
