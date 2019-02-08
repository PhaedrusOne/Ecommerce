

namespace Ecommerce.Models
{
   public class Order_Products
   {
      public int OrderID { get; set; }
      public Order Order { get; set; }

      public int ProductID { get; set; }
      public Product Product { get; set; }

      public int Quantity { get; set; }
      public double TotalSale { get; set; }

   }
}
