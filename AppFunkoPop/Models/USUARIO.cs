//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppFunkoPop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            this.CARRITOes = new HashSet<CARRITO>();
            this.PEDIDOes = new HashSet<PEDIDO>();
        }
    
        public int USUARIO_ID { get; set; }
        [Required(ErrorMessage ="Es necesario introducir un nombre")]
        public string NOMBRE { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un Apellido")]
        public string APELLIDOS { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un email")]
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CARRITO> CARRITOes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PEDIDO> PEDIDOes { get; set; }
        public virtual ROL ROL { get; set; }

        
    }
}
