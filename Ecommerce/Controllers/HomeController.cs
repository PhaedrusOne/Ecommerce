using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.ViewModels;
using System.Security.Policy;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        public static string Loggedin;
        public static string Modelvalid;
        public static Customer currentuser = new Customer(); //("email", "password", "Hash")

        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }


        public IActionResult Index()
        {
            int currentstate = currentuser.State(Loggedin, "");

            if (currentstate == 1)
            {
                ViewBag.session = "true";

            }

            else
            {
                ViewBag.session = "false";

            }
            return View();
           
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                List<Customer> matches1 = context.Customers.Where(c => c.Email == loginViewModel.Email).ToList();

                //string passobj = loginViewModel.Password;

                //Hashobject newhash = new Hashobject(passobj);
                //string Hash = newhash.Hashedstring(passobj);

                List<Customer> matches2 = context.Customers.Where(c => c.Password == loginViewModel.Password).ToList();

                if (matches2.Count == 1)
                {
                    Customer loguser = matches1.Single(c => c.Password == loginViewModel.Password);
                    currentuser = loguser;
                    Loggedin = "true";
                    return Redirect("/Home");
                }

                else
                {
                    ViewBag.error = "No such user found in database. Feel free to register.";
                    return View();
                }


            }

            else
            {

                return View();

            }

        }

        public IActionResult LoggedIn()
        {
            return View();
        }


        public IActionResult Registered()
        {
            return View();
        }

        public IActionResult Logout()
        {
            Loggedin = "";
            return Redirect("/");
        }



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
