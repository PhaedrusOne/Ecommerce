using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels
{
    public class ViewMenuViewModel
    {
        public IList<ProductMenu> Items { get; set; }
        public Menu Menu { get; set; }
    }
}
