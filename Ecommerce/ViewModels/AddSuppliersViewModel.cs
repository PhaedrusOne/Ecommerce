using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels
{
    public class AddSuppliersViewModel
    {
        [Required]
        [Display(Name = "Suppliers Name")]
        public string SName { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone must be 10 digits")]
        [Display(Name = "Suppliers Phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "You must give your email address")]
        [Display(Name = "Suppliers Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must give your address")]
        [Display(Name = "Suppliers address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "You must give your State")]
        public string State { get; set; }

        [Required(ErrorMessage = "You must give your postcode")]
        public int Postcode { get; set; }


    }
}
