using System.Linq;
using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext context;

        public StoreController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = context.Categories.ToList();
           return View(categories);
        }

        public IActionResult Browse(string category)
        {
            var categoryModel = context.Categories.Include("Products")
                .Single(c => c.Name == category);
            return View(categoryModel);
        }

        public IActionResult Details(int id)
        {
            Product Product = context.Products.Find(id);
            return View(Product);
        }
    }
}
