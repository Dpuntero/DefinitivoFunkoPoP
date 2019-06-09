using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppFunkoPop.Models
{
    public class UsuarioSobreVal
    {

        public string NOMBRE { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un Apellido")]
        public string APELLIDOS { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un email")]
        [EmailValidation(ErrorMessage = "Ese e-mail ya ha sido utilizado")]
        public string EMAIL { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un password")]
        [DataType(DataType.Password)]
        public string PASSWD { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un telefono")]
        public int TLFN { get; set; }
        [Required(ErrorMessage = "Es necesario introducir una direccion")]
        public string DIRECCION { get; set; }
        [Required(ErrorMessage = "Es necesario introducir una ciudad")]
        public string CIUDAD { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un pais")]
        public string PAIS { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un codigo postal")]
        public int CP { get; set; }
        public int ID_ROL { get; set; }
        public string LoginErrorMessage { get; set; }

        public class EmailValidation : ValidationAttribute
        {
            private Database1Entities1 db = new Database1Entities1();

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var email = (string)value;

                USUARIO usuario = db.USUARIOs.Where(x => x.EMAIL == email).FirstOrDefault();

                if (usuario != null)
                {
                    return new ValidationResult(ErrorMessage);
                }
                else
                {
                    return ValidationResult.Success;
                }

            }


        }
    }
}