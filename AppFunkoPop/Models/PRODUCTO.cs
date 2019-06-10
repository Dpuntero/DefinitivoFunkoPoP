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
    
        public int PRODUCTO_ID { get; set; }
        public string NOMBREP { get; set; }

        
        public decimal PRECIO { get; set; }
        
        public string DESCRIP { get; set; }
        public string DESCRIP_INGLES { get; set; }
        public string CATEGORIA { get; set; }
        public string SUBCATEGORIA { get; set; }
        public string CATEGORIA_INGLES { get; set; }
        public string SUBCATEGORIA_INGLES { get; set; }
        public int PROVEEDOR_ID { get; set; }
        public string IMAGEN { get; set; }
        public string IMAGEN2 { get; set; }
        public Nullable<bool> DESTACADO { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
        public Nullable<int> UD_DISPO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CARRITOPRODUCTO> CARRITOPRODUCTOes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PEDIDOPRODUCTO> PEDIDOPRODUCTOes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROVEEDOR> PROVEEDORs { get; set; }
    }
}
