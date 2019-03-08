

using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Models
{
    public class Item
    {
        public int ID { get; set; }


        private List<ItemLine> lineCollection = new List<ItemLine>();

        //Returns all of the line items (the complete shopping cart)
        public IEnumerable<ItemLine> Lines
        {
            get { return lineCollection; }
        }


        //Adds a item or quanity to the shopping cart for a specific product
        public void AddItem(Product product, int quantity)
        {
            ItemLine line = lineCollection
                   .Where(p => p.Product.productId == product.productId)
                   .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new ItemLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }


        //Removes the entire line item for the specific product
        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.productId == product.productId);
        }

        //Returns the total value of the entire shopping cart
        public float ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        //Clears the entire shopping cart
        public void Clear()
        {
            lineCollection.Clear();
        }

    }

        public class ItemLine
        {

            public int ID { get; set; }
            public Product Product { get; set; }
            public int Quantity { get; set; }
        }
    


}
