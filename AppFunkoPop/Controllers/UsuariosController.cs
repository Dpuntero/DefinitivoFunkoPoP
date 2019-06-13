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
        //Método para mandar a la vista del panel de control
        // GET: Usuarios
        public ActionResult PanelDeControlUsuarios()
        {
            return View();
        }

        //Método para mandar al formulario de cambio de datos de tu propia cuenta con los datos rellenos
        public ActionResult GestionDatos()
        {
            USUARIO usuario = new USUARIO();
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
            {
                int idUsu = Convert.ToInt32(Session["USUARIO_ID"]);
                usuario = db.USUARIOs.Where(c => c.USUARIO_ID == idUsu).First();

            }
            return View(usuario);
        }
       

        //Método que manda a la vista con el formulario de cambio de contraseña
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

        //Método que manda a la vista con los detalles del pedido
        public ActionResult VerPedido()
        {
            USUARIO usuario = new USUARIO();
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
            {
                int idUsu = Convert.ToInt32(Session["USUARIO_ID"]);
                usuario = db.USUARIOs.Where(c => c.USUARIO_ID == idUsu).First();

            }
            return View(usuario);
        }

       






    }
}