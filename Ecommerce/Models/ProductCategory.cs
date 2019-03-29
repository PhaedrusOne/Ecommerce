using System.Collections.Generic;

namespace Ecommerce.Models
{
    public class ProductCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
      
        public IList<Product> Products { get; set; }
    }
}
