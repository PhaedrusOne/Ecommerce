namespace Ecommerce.Models
{
    public class Item
    {
        public int ID { get; set; }      

    }

    public class ItemLine
    {

        public int ID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

}
