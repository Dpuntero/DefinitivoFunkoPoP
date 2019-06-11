using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppFunkoPop.Controllers
{
    public class OtrosController : Controller
    {
        // GET: Otros
        public ActionResult AvisoLegal()
        {
            return View();
        }

        public ActionResult Contacto()
        {
            return View();
        }

        public ActionResult PoliticaPrivacidad()
        {
            return View();
        }

        public ActionResult SobreNosotros()
        {
            return View();
        }
    }
}