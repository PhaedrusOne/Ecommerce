using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels
{
    public class AddOrderItemViewModel
    {
        public Order Order { get; set; }
        public List<SelectListItem> Products { get; set; }

        public int OrderID { get; set; }
        public int ProductID { get; set; }

        public AddOrderItemViewModel() { }

        public AddOrderItemViewModel(Order order, IEnumerable<Product> products)
        {

            Products = new List<SelectListItem>();

            foreach (var product in products)
            {
                Products.Add(new SelectListItem
                {
                    Value = product.ID.ToString(),
                    Text = product.Name
                });
            }

            Order = order;
        }
    }
}
