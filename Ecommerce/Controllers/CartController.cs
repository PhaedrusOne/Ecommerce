﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Session;
using Ecommerce.Helpers;
using Ecommerce.ViewModels;
using Ecommerce.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Controllers
{
    //[Route("cart")]
    public class CartController : Controller
    {

        private readonly ApplicationDbContext context;

        public CartController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        //public static string Session;


        readonly List<ItemLine> item = new List<ItemLine>();
        public ActionResult Index()
        {

            
            var cart = SessionHelper.GetObjectFromJson<List<ItemLine>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View();
        }



        public IActionResult Buy(int id)
        {
            AddProductViewModel productModel = new AddProductViewModel();
            if (SessionHelper.GetObjectFromJson<List<ItemLine>>(HttpContext.Session, "cart") == null)
            {
                var cart = new List<ItemLine>();
                cart.Add(new ItemLine() { Product = context.Products.Find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<ItemLine> cart = SessionHelper.GetObjectFromJson<List<ItemLine>>(HttpContext.Session, "cart");
                int index = IsExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new ItemLine { Product = context.Products.Find(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        private int IsExist(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Remove(string id)
        {
            List<ItemLine> cart = SessionHelper.GetObjectFromJson<List<ItemLine>>(HttpContext.Session, "cart");
            int index = IsExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int IsExist(string id)
        {
            List<ItemLine> cart = SessionHelper.GetObjectFromJson<List<ItemLine>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ID.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        //     private readonly CommerceContext _context;

        //     public CartController(CommerceContext context)
        //     {
        //         _context = context;
        //     }

        //    public IActionResult Add(int id)
        //    {
        //         const string CartCookie = "Cart";

        //Find product you want to add
        //        Product p = Product.GetProduct(_context, id);

        //Turn product into JSON
        //string data = JsonConvert.SerializeObject(p);

        //Get current shopping cart data
        //         string cookieData =
        //             HttpContext.Request.Cookies[CartCookie];

        //        List<Product> products;
        //        if (cookieData == null)
        //        {
        //            products = new List<Product>();
        //       }
        //       else
        //       {
        //           products =
        //              JsonConvert.DeserializeObject<List<Product>>(cookieData);
        //       }

        //      products.Add(p);


        // CookieOptions options = new CookieOptions();
        //   options.Secure = true;
        // options.MaxAge = TimeSpan.FromDays(365);

        //Serialize ALL the products into a string
        //      string data =
        //        JsonConvert.SerializeObject(products);

        //Store it in cookie
        //     HttpContext.Response.Cookies
        //       .Append(CartCookie, data, options);

        //Thank user and display product info
        //   return View(p);
        //  }
    }
    
    
}