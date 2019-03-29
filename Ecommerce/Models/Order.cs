using System;
using System.Collections.Generic;

namespace Ecommerce.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliverDate  {get; set;}

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public List<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
        //public int Quantity { get; internal set; }
        //public double TotalSale { get; set; }
    }
}
