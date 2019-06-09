using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppFunkoPop.Models;
//using Microsoft.Reporting.WebForms;

namespace ProyectoDawFunko.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Pedidos
        public ActionResult MisPedidos()
        {
            Database1Entities db = new Database1Entities();

            int idUsu = Convert.ToInt32(Session["USUARIO_ID"]);
            List<PEDIDO> aux = db.PEDIDOes.ToList();
            List<PEDIDO> aux2 = new List<PEDIDO>();

            foreach (var i in aux)
            {
                if (i.USUARIO_ID == idUsu)
                {
                    aux2.Add(i);
                }
            }
            return View(aux2);
        }
        [HttpPost]
        public ActionResult RealizarPedido(IEnumerable<AppFunkoPop.Models.ProductoUnidades> listcarrito)
        {
            Debug.WriteLine("My debug string here");
            Database1Entities db = new Database1Entities();
            
                PEDIDO nuevoPedido = new PEDIDO();
           
            nuevoPedido.PEDIDO_ID = 3;
            nuevoPedido.USUARIO_ID = Convert.ToInt32(Session["USUARIO_ID"]);
                nuevoPedido.PRECIO_TOTAL = 0;
                nuevoPedido.INFO_PAGO = "irrelevante";
                nuevoPedido.ESTADO_ENVIO = 1;
            db.PEDIDOes.Add(nuevoPedido);
            db.SaveChanges();
            
            foreach (var i in listcarrito)
            {
                
                PEDIDOPRODUCTO nuevoProductoPedido = new PEDIDOPRODUCTO();
                nuevoProductoPedido.PEDIDO_ID = nuevoPedido.PEDIDO_ID;
                nuevoProductoPedido.P_ID = i.PRODUCTO_ID;
                nuevoProductoPedido.UNIDADES = i.Unidades;
                nuevoProductoPedido.PRECIO = Convert.ToString(i.PRECIO);
                nuevoProductoPedido.DESCUENTO = "0";
                db.PEDIDOPRODUCTOes.Add(nuevoProductoPedido);
                db.SaveChanges();
                
            }

            return RedirectToAction("MisPedidos","Pedidos");
        }



    }
}
