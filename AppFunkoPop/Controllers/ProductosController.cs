using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppFunkoPop.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Productos()
        {
            return View();
        }
    }
}