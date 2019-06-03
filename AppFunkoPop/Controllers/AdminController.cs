using AppFunkoPop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoDawFunko.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult PanelDeControlAdmin()
        {
            return View();
        }

        public ActionResult NuevoProducto()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult GestionUsuarios()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //METODOS PARA GESTION DE PRODUCTOS
        // GET: PRODUCTOes
        public ActionResult GestionProductos()
        {
            Database1Entities db = new Database1Entities();
            ViewBag.Productos = db.PRODUCTOes.ToList();
            return View();
        }

        // GET: PRODUCTOes/EditarProducto/5

        public ActionResult EditarProducto(int? id)
        {
            Database1Entities db = new Database1Entities();
            PRODUCTO productoAEditar = db.PRODUCTOes.Find(id);

            return View("EditandoProducto", productoAEditar);
        }
       

        [HttpPost]
        public ActionResult EditandoProducto(PRODUCTO productoModificado)
        {           
            using (Database1Entities db = new Database1Entities())
            {
                PRODUCTO productoOriginal = db.PRODUCTOes.Where(c => c.PRODUCTO_ID == productoModificado.PRODUCTO_ID).First();
                productoOriginal.NOMBREP = productoModificado.NOMBREP;
                productoOriginal.CATEGORIA = productoModificado.CATEGORIA;
                productoOriginal.DESCRIP = productoModificado.DESCRIP;
                productoOriginal.UD_DISPO = productoModificado.UD_DISPO;
                productoOriginal.PRECIO = productoModificado.PRECIO;
                productoOriginal.V_ID = productoModificado.V_ID;
                productoOriginal.IMAGEN = productoModificado.LINK;
                db.SaveChanges();
                return RedirectToAction("GestionProductos");
            }
        }

        //FIN METODOS PRODUCTOS

        public ActionResult GestionPedidos()
        {
            return View();
        }

       
    }
}