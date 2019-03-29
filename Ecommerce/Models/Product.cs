using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ecommerce.Controllers;

namespace Ecommerce.Models
{
    public class Product
    {
       internal object productId;

       public int ID { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       [Required]
       [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
       public float Price { get; set; }
       public int Stock { get; set; }
       public string Photo { get; set; }
       //public string ImageThumbnailUrl { get; set; }

         
       public int CategoryID { get; set; }
       public ProductCategory Category { get; set; }

        internal static Product GetProduct(CommerceContext context, int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductMenu> ProductMenus { get; set; }

        public List<ProductOrder> ProductOrders { get; set; }
        
        
    }
}
