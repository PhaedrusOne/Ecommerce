﻿using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        [Required(ErrorMessage = "You must give a Inventory")]
        public int Stock { get; set; }

        public string Photo { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AddProductViewModel(IEnumerable<ProductCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (ProductCategory category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.ID.ToString(),
                    Text = category.Name
                });
            }
        }
    
        public AddProductViewModel()
        {

        }

        private readonly List<Product> products = new List<Product>();

        public List<Product> FindAll()
        {
            return this.products;
        }

        public Product Find(int id)
        {
            return this.products.SingleOrDefault(c => c.ID.Equals(id));
        }
      
    }
}
