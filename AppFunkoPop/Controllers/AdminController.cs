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
            PRODUCTO pRODUCTO = db.PRODUCTOes.Find(id);

            return View("EditadoProducto", pRODUCTO);
        }
       

        [HttpPost]

        public ActionResult EditadoProducto(PRODUCTO modificado)
        {
            //ESTE METODO TODAVIA NO FUNCIONA BIEN. NO ACTUALIZAEL REGISTRO
            Database1Entities db = new Database1Entities();
            db.Entry(modificado).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("GestionProductos");

        }

        //FIN METODOS PRODUCTOS

        public ActionResult GestionPedidos()
        {
            return View();
        }

       
    }
}