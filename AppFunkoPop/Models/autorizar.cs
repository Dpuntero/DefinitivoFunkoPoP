using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppFunkoPop.Models
{
    public class autorizar
    {
        [Required(ErrorMessage = "Es necesario introducir un email")]
        
        public string EMAIL { get; set; }
        
        [DataType(DataType.Password)]
        public string PASSWD { get; set; }

        public string LoginErrorMessage { get; set; }

    }
}