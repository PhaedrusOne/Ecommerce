

namespace Ecommerce.Models
{
    public class ProductMenu
    {
        public int MenuID { get; set; }
        public Menu Menu { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
