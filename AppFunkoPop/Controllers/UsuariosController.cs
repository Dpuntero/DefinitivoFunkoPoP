using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppFunkoPop.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult PanelDeControlUsuarios()
        {
            return View();
        }

        public ActionResult GestionDatos()
        {
            return View();
        }
    }
}