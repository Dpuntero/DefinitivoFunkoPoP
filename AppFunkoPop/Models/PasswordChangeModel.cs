using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppFunkoPop.Models
{
   
    
   public class PasswordChangeModel
    {
        [Required(ErrorMessage = "Es necesario introducir la contraseña antigua")]
        public string contrasenaAntigua { get; set; }
        [Required(ErrorMessage = "Es necesario introducir una nueva contraseña")]
        public string contrasenaNueva { get; set; }
        [Required(ErrorMessage = "Es necesario introducir la repetición de contraseña")]
        public string contrasenaRepetida { get; set; }

        public string contrasenaErrorMessage { get; set; }

        
    }
}