using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Product
    {
       public string Name { get; set; }
       public string Description { get; set; }
       public float Price { get; set; }
       public ProductType Type { get; set; }
       public int ID { get; set; }

    }
}
