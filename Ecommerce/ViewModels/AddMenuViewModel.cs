﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels
{
    public class AddMenuViewModel
    {       
        [Required]
        [Display(Name = "Menu Name")]
        public string Name { get; set; }
    }
}
