using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Ecommerce.Controllers
//{
   // public class CartController : Controller
   // {

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


//            CookieOptions options = new CookieOptions();
  //          options.Secure = true;
    //        options.MaxAge = TimeSpan.FromDays(365);
    //
            //Serialize ALL the products into a string
      //      string data =
        //        JsonConvert.SerializeObject(products);

            //Store it in cookie
       //     HttpContext.Response.Cookies
         //       .Append(CartCookie, data, options);

            //Thank user and display product info
    //        return View(p);
      //  }
  //  }   
    
//}
