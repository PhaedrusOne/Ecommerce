using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Ecommerce.ViewModels
{
    public class AddMenuItemViewModel
    {
        public Menu Menu { get; set; }
        public List<SelectListItem> Products { get; set; }

        public int MenuID { get; set; }
        public int ProductID { get; set; }

        public AddMenuItemViewModel() { }

        public AddMenuItemViewModel(Menu menu, IEnumerable<Product> products)
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

            Menu = menu;
        }

    }

}
