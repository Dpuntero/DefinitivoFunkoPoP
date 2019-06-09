using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppFunkoPop.Models;

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
            USUARIO usuario = new USUARIO();
            using (Database1Entities1 db = new Database1Entities1())
            {
                int idUsu = Convert.ToInt32(Session["USUARIO_ID"]);
                usuario = db.USUARIOs.Where(c => c.USUARIO_ID == idUsu).First();

            }
            return View(usuario);
        }

        public ActionResult CambiarContraseña(AppFunkoPop.Models.PasswordChangeModel passModel= null )
        {
            if (passModel == null)
            {
                return View();
            }
            else
            {
                return View(passModel);
            }

            
        }

        public ActionResult VerPedido()
        {
            USUARIO usuario = new USUARIO();
            using (Database1Entities1 db = new Database1Entities1())
            {
                int idUsu = Convert.ToInt32(Session["USUARIO_ID"]);
                usuario = db.USUARIOs.Where(c => c.USUARIO_ID == idUsu).First();

            }
            return View(usuario);
        }






    }
}