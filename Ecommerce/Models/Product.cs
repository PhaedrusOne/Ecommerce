using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Product
    {
       public int ID { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public float Price { get; set; }
       public int Stock { get; set; }

       //public int SID { get; set; }
       //public Suppliers Suppliers { get; set; }
       
       public int CategoryID { get; set; }
       public ProductCategory Category { get; set; }

    }
}
