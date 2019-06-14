using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppFunkoPop.Controllers
{
    public class OtrosController : Controller
    {
        //Método para la redirección al aviso legal
        // GET: Otros
        public ActionResult AvisoLegal()
        {
            return View();
        }
        //Método para la redirección al aviso legal
        public ActionResult Contacto()
        {
            return View();
        }
        //Método para la redirección a la política de privacidad
        public ActionResult PoliticaPrivacidad()
        {
            return View();
        }
        //Método para la redirección a la página de información sobre nosotros
        public ActionResult SobreNosotros()
        {
            return View();
        }
    }
}