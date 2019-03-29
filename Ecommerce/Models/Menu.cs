using System.Collections.Generic;

namespace Ecommerce.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public IList<ProductMenu> ProductMenus { get; set; } = new List<ProductMenu>();
    }
}
