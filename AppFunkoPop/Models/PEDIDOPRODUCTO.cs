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
    
    public partial class PEDIDOPRODUCTO
    {
        public int PEDIDO_ID { get; set; }
        public int P_ID { get; set; }
        public string UNIDADES { get; set; }
        public string PRECIO { get; set; }
        public string DESCUENTO { get; set; }
    
        public virtual PEDIDO PEDIDO { get; set; }
        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
