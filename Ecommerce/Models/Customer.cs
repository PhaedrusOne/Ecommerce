

using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Models
{
    public class Customer //: IdentityUser
    {
        
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        

        public int State(string Loggedin, string Modelvalid)
       {
           int Stateval = 0;
           if (Loggedin == "true")
           {

                Stateval += 1;

           }

            if (Modelvalid == "true")
            {

                Stateval += 1;

            }

            return Stateval;

        }

        internal int State(Func<IActionResult> loggedIn, string v)
        {
            throw new NotImplementedException();
        }
    }
}
