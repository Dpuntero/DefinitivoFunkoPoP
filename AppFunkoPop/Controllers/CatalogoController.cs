using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppFunkoPop.Models;

namespace ProyectoDawFunko.Controllers
{
    public class CatalogoController : Controller
    {
        // GET: Catalogo
        public ActionResult Catalogo()
        {
            Database1Entities db = new Database1Entities();

            return View(db.PRODUCTOes.ToList());
        }

        public ActionResult MostrarProductos()
        {

            
            return View();
        }
    }
}