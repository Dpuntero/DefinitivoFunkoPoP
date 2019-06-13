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
            FunkoPopDDBBEntities db = new FunkoPopDDBBEntities();

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

            if (Session["USUARIO_ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                List<ProductoUnidades> pedidovacio = listcarrito.ToList();
                foreach (var i in listcarrito)
                {
                   
                    var ed = pedidovacio.Where(x => x.UD_DISPO == 0).FirstOrDefault();
                    pedidovacio.Remove(ed);
                }



                if (pedidovacio.Count() == 0)
                {
                    var cookie = Request.Cookies["Carrito"];
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    cookie.Value = string.Empty;
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("MisPedidos", "Pedidos");
                }
                else
                {


                    Debug.WriteLine("My debug string here");
                    FunkoPopDDBBEntities db = new FunkoPopDDBBEntities();

                    PEDIDO nuevoPedido = new PEDIDO();

                    //nuevoPedido.PEDIDO_ID = 3;
                    nuevoPedido.USUARIO_ID = Convert.ToInt32(Session["USUARIO_ID"]);
                    foreach (var i in pedidovacio)
                    {
                        nuevoPedido.PRECIO_TOTAL = nuevoPedido.PRECIO_TOTAL + Convert.ToInt32(i.PRECIOUnidad) * Convert.ToInt32(i.Unidades);
                    }

                    nuevoPedido.INFO_PAGO = "irrelevante";
                    nuevoPedido.ESTADO_ENVIO = 1;
                    db.PEDIDOes.Add(nuevoPedido);
                    db.SaveChanges();

                    foreach (var i in pedidovacio)
                    {

                        PEDIDOPRODUCTO nuevoProductoPedido = new PEDIDOPRODUCTO();
                        nuevoProductoPedido.PEDIDO_ID = nuevoPedido.PEDIDO_ID;
                        nuevoProductoPedido.P_ID = i.PRODUCTO_ID;
                        // nuevoProductoPedido.UNIDADES = i.UD_DISPO.Value;
                        nuevoProductoPedido.UNIDADES = Convert.ToInt32(i.Unidades);
                        nuevoProductoPedido.PRECIO = i.PRECIO;
                        db.PEDIDOPRODUCTOes.Add(nuevoProductoPedido);
                        var producto = db.PRODUCTOes.Where(x => x.PRODUCTO_ID == i.PRODUCTO_ID).FirstOrDefault();
                        producto.UD_DISPO = producto.UD_DISPO - Convert.ToInt32(i.Unidades);

                        db.SaveChanges();

                    }
                    var cookie = Request.Cookies["Carrito"];
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    cookie.Value = string.Empty;
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("MisPedidos", "Pedidos");
                }
            }
        }
        public ActionResult VerPedidoUnico(int id)
        {
            FunkoPopDDBBEntities db = new FunkoPopDDBBEntities();
            List<PEDIDOPRODUCTO> productos = db.PEDIDOPRODUCTOes.Where(c => c.PEDIDO_ID == id).ToList();


            return View("MiPedido2", productos);
        }


    }
}
