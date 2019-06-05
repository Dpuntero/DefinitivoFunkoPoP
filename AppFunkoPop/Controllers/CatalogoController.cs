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
            List<PRODUCTO> prod = new List<PRODUCTO>();
            using (Database1Entities db = new Database1Entities())
            {
                prod = db.PRODUCTOes.ToList();

            }


            return View(prod);

        }

        public ActionResult MostrarProductos()
        {

            
            return View();
        }
    }
}