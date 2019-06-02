using System;
using System.Collections.Generic;
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

        public ActionResult GestionProductos()
        {
            ViewBag.Message = "Your contact page.. Nueva!";

            return View();
        }

        public ActionResult GestionPedidos()
        {
            return View();
        }

       
    }
}