using AppFunkoPop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AppFunkoPop.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        /*
        public ActionResult CrearUsuario(USUARIO obj)
        {
            if (ModelState.IsValid)
            {
                USUARIO nuevo = new USUARIO()
                {

                    NOMBRE = Request.Form["nombre"],
                    APELLIDOS = Request.Form["apellidos"],
                    EMAIL = Request.Form["email"],
                    PASSWD = Request.Form["passwd"],
                    TLFN = Convert.ToInt32(Request.Form["telefono"]),
                    DIRECCION = Request.Form["direccion"],
                    CIUDAD = Request.Form["ciudad"],
                    PAIS = Request.Form["pais"],
                    CP = Convert.ToInt32(Request.Form["cp"]),
                    ID_ROL = 1
                };


                using (Database1Entities db = new Database1Entities())
                {
                    db.USUARIOs.Add(nuevo);
                    db.SaveChanges();
                }
                

                return View("Login");

            }
            else
            {
                return View("Register");
            }
        }

        [AllowAnonymous]
        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> IniciarSesion(USUARIO datos)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return View("Index");
            }
         }*/
        [HttpPost]
        public ActionResult Autorizar(AppFunkoPop.Models.USUARIO userModel)
        {
            using (Database1Entities db = new Database1Entities())
            {
                var userDetails = db.USUARIOs.Where(x => x.EMAIL == userModel.EMAIL && x.PASSWD == userModel.PASSWD).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Password o Email equivocado.";
                    return View("Login", userModel);

                }
                else
                {
                    Session["USUARIO_ID"] = userDetails.USUARIO_ID;
                    Session["NOMBRE"] = userDetails.NOMBRE;
                    Session["APELLIDOS"] = userDetails.APELLIDOS;
                    Session["EMAIL"] = userDetails.EMAIL;
                    Session["PASSWD"] = userDetails.PASSWD;
                    Session["TLFN"] = userDetails.TLFN;
                    Session["DIRECCION"] = userDetails.DIRECCION;
                    Session["CIUDAD"] = userDetails.CIUDAD;
                    Session["PAIS"] = userDetails.PAIS;
                    Session["CP"] = userDetails.CP;
                    Session["ID_ROL"] = userDetails.ID_ROL;
                    return RedirectToAction("Index", "Home");


                }
            }
           

        }

        [HttpPost]
        public ActionResult RegistrarUsuario(AppFunkoPop.Models.USUARIO userModel)
        {
            using (Database1Entities db = new Database1Entities())
            {
                userModel.ID_ROL = 1;
                db.USUARIOs.Add(userModel);

                db.SaveChanges();

                var userDetails = db.USUARIOs.Where(x => x.EMAIL == userModel.EMAIL && x.PASSWD == userModel.PASSWD).FirstOrDefault();
                Session["USUARIO_ID"] = userDetails.USUARIO_ID;
                Session["NOMBRE"] = userDetails.NOMBRE;
                Session["APELLIDOS"] = userDetails.APELLIDOS;
                Session["EMAIL"] = userDetails.EMAIL;
                Session["PASSWD"] = userDetails.PASSWD;
                Session["TLFN"] = userDetails.TLFN;
                Session["DIRECCION"] = userDetails.DIRECCION;
                Session["CIUDAD"] = userDetails.CIUDAD;
                Session["PAIS"] = userDetails.PAIS;
                Session["CP"] = userDetails.CP;
                Session["ID_ROL"] = userDetails.ID_ROL;
                
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult CerrarSesion()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");

        }

    }       
}