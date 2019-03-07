using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Models
{
    public class ProductModel
    {
        private readonly List<Product> products;

        public ProductModel()
        {
            this.products = new List<Product>() {
                new Product {
                    ID = 4012,
                    Name = "Elixir 001",
                    Description = "25% Energy / 25% Strength",
                    Price = 30,
                    Stock = 11,
                    Photo = "Elixer.jpg"
                },
                new Product {
                    ID = 4015,
                    Name = "Elixer Red",
                    Description = "50% Health Regeneration",
                    Price = 30,
                    Stock = 20,
                    Photo = "NULL"
                },
                new Product {
                    ID = 4016,
                    Name = "Elixer Blue",
                    Description = "50% Energy",
                    Price = 30,
                    Stock = 14,
                    Photo = "NULL"
                }
            };


        }

        public List<Product> FindAll()
        {
            return this.products;
        }

        public Product Find(string id)
        {
            return this.products.Single(p => p.ID.Equals(id));
        }

    }
}

