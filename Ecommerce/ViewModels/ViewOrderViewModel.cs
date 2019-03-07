using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels
{
    public class ViewOrderViewModel
    {
        public IList<ProductOrder> Items { get; set; }
        public Order Order { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliverDate { get; set; }
    }
}
