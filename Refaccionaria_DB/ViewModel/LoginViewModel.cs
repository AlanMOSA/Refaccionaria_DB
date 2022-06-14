﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Refaccionaria_DB.ViewModel
{
    public class LoginViewModel
    {
          [Required]
            [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
            public string correo { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string clave { get; set; }

        
    }
}