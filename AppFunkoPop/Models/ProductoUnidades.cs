using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppFunkoPop.Models
{
    public class ProductoUnidades
    {
        public int PRODUCTO_ID { get; set; }

        public string Unidades { get; set; }

        public string NOMBRE { get; set; }

        public decimal PRECIOUnidad { get; set; }

        public decimal PRECIO { get; set; }

        public string CATEGORIA { get; set; }

        public Nullable<int> UD_DISPO { get; set; }

        public string IMAGEN { get; set; }
    }
}