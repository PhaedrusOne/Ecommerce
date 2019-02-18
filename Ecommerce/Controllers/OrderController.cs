using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;

        public  OrderController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }


        public IActionResult Index()
        {
            List<Order> Orders = context.Orders.ToList();
        
            return View(Orders);
        }
    }
}
