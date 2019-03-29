using Ecommerce.Models;
using System.Collections.Generic;

namespace Ecommerce.ViewModels
{
    public class ViewMenuViewModel
    {
        public IList<ProductMenu> Items { get; set; }
        public Menu Menu { get; set; }
    }
}
