using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Refaccionaria_DB.ViewModel
{
    public class Register
    {
        [Required]
        [Display(Name = "apellidoPaterno")]
        public string apellidoPaterno { get; set; }

        [Required]
        [Display(Name = "apellidoMaterno")]
        public string apellidoMaterno { get; set; }

        //Required attribute implements validation on Model item that this fields is mandatory for user
        [Required]
        //We are also implementing Regular expression to check if email is valid like a1@test.com
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string clave { get; set; }

    }
}