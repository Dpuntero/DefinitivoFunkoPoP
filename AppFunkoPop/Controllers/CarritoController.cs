using AppFunkoPop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoDawFunko.Controllers
{
    public class CarritoController : Controller
    {
        public ActionResult CreacionCarrito()
        {
            using (Database1Entities db = new Database1Entities())
            {
                CARRITO nuevoCarrito = new CARRITO();
                nuevoCarrito.FECHA_CR = DateTime.Today;
                nuevoCarrito.USUARIO_ID = Convert.ToInt32(Session["USUARIO_ID"]);
                nuevoCarrito.PRECIO_T = "1";
                db.CARRITOes.Add(nuevoCarrito);
                db.SaveChanges();
            }


                return View();
        }
  
        public ActionResult AñadirProductoACarrito()
        {
            using (Database1Entities db = new Database1Entities())
            {
                int c = Convert.ToInt32(Session["USUARIO_ID"]);
                var carritoDetails = db.CARRITOes.Where(x => x.USUARIO_ID ==c).FirstOrDefault();
                if (carritoDetails != null)
                {

                }
                else
                {
                    CreacionCarrito();
                }
            }

                return RedirectToAction("Index","Home");
        }
    }
}