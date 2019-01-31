using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;
using Ecommerce.ViewModels;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {

        private ApplicationDbContext context;

        public ProductController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            List<Product> products = context.Products.ToList();

            return View(products);
        }

        public IActionResult Add()
        {
            AddProductViewModel addProductViewModel = new AddProductViewModel();
            return View(addProductViewModel);
        }
        [HttpPost]
        [Route("/Product/Add")]
        public IActionResult Add(AddProductViewModel addProductViewModel)
            
        {
            if (ModelState.IsValid)
            {
                Product newProduct = new Product
                {
                    Name = addProductViewModel.Name,
                    Description = addProductViewModel.Description,
                    Price = addProductViewModel.Price,
                    Type = addProductViewModel.Type
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
    }   
    
}
