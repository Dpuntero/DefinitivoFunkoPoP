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

    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
            this.CARRITOPRODUCTOes = new HashSet<CARRITOPRODUCTO>();
            this.PEDIDOPRODUCTOes = new HashSet<PEDIDOPRODUCTO>();
            this.PROVEEDORs = new HashSet<PROVEEDOR>();
        }

       /* [Required]
        [Display(Name = "ID")]*/
        public int PRODUCTO_ID { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string NOMBREP { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public decimal PRECIO { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string DESCRIP { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public string CATEGORIA { get; set; }

        [Required]
        [Display(Name = "Unidades")]
        public Nullable<int> UD_DISPO { get; set; }

        [Required]
        [Display(Name = "Proveedor")]
        public Nullable<int> V_ID { get; set; }

        [Required]
        [Display(Name = "Imagen")]
        public string IMAGEN { get; set; }

        [Required]
        [Display(Name = "link")]
        public string LINK { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CARRITOPRODUCTO> CARRITOPRODUCTOes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PEDIDOPRODUCTO> PEDIDOPRODUCTOes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROVEEDOR> PROVEEDORs { get; set; }
    }
}
