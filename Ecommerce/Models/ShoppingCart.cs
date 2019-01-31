using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class ShoppingCart
    {
        public int ShopOrderID { get; set; }
        public int ProductID { get; set; }
        public string PName { get; set; }
        public float SPrice { get; set; }
        public int Quantity { get; set; }
    }
}