using Microsoft.AspNetCore.Mvc;
using Ecommerce.ViewModels;
using Ecommerce.Data;
using Ecommerce.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext context;

        public CustomerController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }


        public IActionResult Index()
        {
            List<Customer> customers = context.Customers.ToList();


            return View(customers);
        }
        public IActionResult Add()
        {
            AddCustomerViewModel addCustomerViewModel = new AddCustomerViewModel();
            return View(addCustomerViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCustomerViewModel addCustomerViewModel)
        {
            if (ModelState.IsValid)
            {
                Customer newCustomer = new Customer
                {
                    FName = addCustomerViewModel.FName,
                    LName = addCustomerViewModel.LName,
                    Email = addCustomerViewModel.Email,
                    Password = addCustomerViewModel.Password
                };

                context.Customers.Add(newCustomer);
                context.SaveChanges();

                return Redirect("/Customer");
            }

            return View(addCustomerViewModel);
        }


        public IActionResult Remove()
        {
            ViewBag.title = "Remove Customer";
            ViewBag.customers = context.Customers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] customerIds)
        {
            foreach (int customerId in customerIds)
            {
                Customer theCustomer = context.Customers.Single(c => c.ID == customerId);
                context.Customers.Remove(theCustomer);
            }

            context.SaveChanges();

            return Redirect("/");

        }

    }
}
