using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;
using Ecommerce.ViewModels;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext context;

        public ProductController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {           
            IList<Product> products = context.Products.Include(c => c.Category).ToList();

            return View(products);
        }

        public IActionResult Add()
        {
            AddProductViewModel addProductViewModel = new AddProductViewModel(context.Categories.ToList());
            return View(addProductViewModel);
        }
        [HttpPost]
        public IActionResult Add(AddProductViewModel addProductViewModel)
            
        {
            if (ModelState.IsValid)
            {
                ProductCategory newProductCategory =
                    context.Categories.Single(c => c.ID == addProductViewModel.CategoryID);
                Product newProduct = new Product
                {
                    Name = addProductViewModel.Name,
                    Description = addProductViewModel.Description,
                    Price = addProductViewModel.Price,
                    Stock = addProductViewModel.Stock,
                    Photo = addProductViewModel.Photo,
                    Category = newProductCategory
                };

                context.Products.Add(newProduct);
                context.SaveChanges();

                return Redirect("/Product");
            }
            return View(addProductViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Products";
            ViewBag.products = context.Products.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Remove(int[] productIds)
        {
            foreach (int productId in productIds)
            {
                Product theProduct = context.Products.Single(c => c.ID == productId);
                context.Products.Remove(theProduct);
            }

            context.SaveChanges();

            return Redirect("/");

        }

        public IActionResult Category(int id)
        {
            if (id == 0)
            {
                return Redirect("/Category");
            }

            ProductCategory theCategory = context.Categories
                .Include(cat => cat.Products)
                .Single(cat => cat.ID == id);


            ViewBag.title = "Products in category: " + theCategory.Name;

            return View("Index", theCategory.Products);

        }       

    }   
    
}
