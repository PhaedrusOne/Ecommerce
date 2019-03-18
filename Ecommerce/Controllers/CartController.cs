    using System;
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
    
    public class CartController : Controller
    {

        private readonly ApplicationDbContext context;

        public CartController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        


        readonly List<ItemLine> item = new List<ItemLine>();
        public ActionResult Index()
        {

            
            var cart = SessionHelper.GetObjectFromJson<List<ItemLine>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View();
        }

        //Add item or quanity to the cart for that product
        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            
            if (SessionHelper.GetObjectFromJson<List<ItemLine>>(HttpContext.Session, "cart") == null)
            {
                var cart = new List<ItemLine>();
                cart.Add(new ItemLine() { Product = context.Products.Find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<ItemLine> cart = SessionHelper.GetObjectFromJson<List<ItemLine>>(HttpContext.Session, "cart");
                int index = IsExist(cart, id);
                if (index == -1)
                {
                    cart.Add(new ItemLine { Product = context.Products.Find(id), Quantity = 1 }); 
                }
                else
                {
                    cart[index].Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }


        //Remove the item for that product
        [Route("Remove/{id}")]
        public IActionResult Remove(int id)
        {
                       
            List<ItemLine> cart = SessionHelper.GetObjectFromJson<List<ItemLine>>(HttpContext.Session, "cart");
            int index = IsExist(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart); 
            return RedirectToAction("Index");
        }
      

        private int IsExist(List<ItemLine> cart, int id)
        {
           
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ID.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        
    }
    
    
}