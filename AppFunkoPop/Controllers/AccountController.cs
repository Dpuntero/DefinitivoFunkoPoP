using AppFunkoPop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AppFunkoPop.Controllers
{
    public class AccountController : Controller
    {
        //Método para mandar al formulario de Login
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        //Método para mandar al formulario de registro
        public ActionResult Register()
        {
            return View();
        }

        //Método para crear un nuevo usuario con los datos del formulario del registro
        [HttpPost]
            public ActionResult Register(AppFunkoPop.Models.USUARIO userModel)
        {
            
            if (ModelState.IsValid)
            {
                using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
                {
                    
                    USUARIO usuario = db.USUARIOs.Where(x => x.EMAIL == userModel.EMAIL).FirstOrDefault();
                    if (usuario != null)
                    {
                        userModel.LoginErrorMessage = "Ese email ya ha sido registrado";
                        return View(userModel);
                    }
                    else
                    {

                        userModel.ID_ROL = 1;
                        userModel.FECHA_CREACION = DateTime.UtcNow;
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
                
            }
            else
            {
                return View();
            }


            
        }
  
        //Método para autorizar el acceso a un usuario cuando su email y contraseña sean correctos
        [HttpPost]
        public ActionResult Autorizar(AppFunkoPop.Models.autorizar userModel)
        {
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
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

        //Método para cerrar la sesión y devolver al index
        public ActionResult CerrarSesion()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");

        }

        //Método que recoge los nuevos datos del formulario de modificación de usuarios y actualiza el registro en la BBDD
        [HttpPost]
        public ActionResult ActualizarUsuario(AppFunkoPop.Models.USUARIO userModel)
        {
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
            {
                int idUsu = Convert.ToInt32(Session["USUARIO_ID"]);

                USUARIO usuario = db.USUARIOs.Where(c => c.USUARIO_ID == idUsu).First();

                usuario.NOMBRE = userModel.NOMBRE;
                usuario.APELLIDOS = userModel.APELLIDOS;
                usuario.EMAIL = usuario.EMAIL;

                usuario.TLFN = userModel.TLFN;
                usuario.DIRECCION = userModel.DIRECCION;
                usuario.CIUDAD = userModel.CIUDAD;
                usuario.PAIS = userModel.PAIS;
                usuario.CP = userModel.CP;  

                db.SaveChanges();

                var userDetails = db.USUARIOs.Where(x => x.USUARIO_ID == usuario.USUARIO_ID).FirstOrDefault();

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

        //Método que manda a la vista de cambiar de contraseña
        public ActionResult CambiarContraseña()
        {
            return View();
        }

        //Método que valida la nueva contraseña y la actualiza
        [HttpPost]
        public ActionResult CambiarContraseña(AppFunkoPop.Models.PasswordChangeModel passModel)
        {
            if (ModelState.IsValid)
            {
                if (passModel.contrasenaAntigua == Convert.ToString(Session["PASSWD"]))
                {


                    if (passModel.contrasenaNueva == passModel.contrasenaRepetida)
                    {
                        if (passModel.contrasenaNueva == passModel.contrasenaAntigua)
                        {
                            passModel.contrasenaErrorMessage = "La nueva contraseña no puede ser igual a la anterior.";

                            return RedirectToAction("CambiarContraseña", "Usuarios", passModel);
                        }
                        else
                        {
                            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
                            {
                                int idUsu = Convert.ToInt32(Session["USUARIO_ID"]);

                                USUARIO usuario = db.USUARIOs.Where(c => c.USUARIO_ID == idUsu).First();
                                usuario.PASSWD = passModel.contrasenaNueva;
                                db.SaveChanges();

                                var userDetails = db.USUARIOs.Where(x => x.USUARIO_ID == usuario.USUARIO_ID).FirstOrDefault();
                                Session["PASSWD"] = userDetails.PASSWD;


                            }

                            return RedirectToAction("Index", "Home");
                        }


                    }
                    else
                    {
                        passModel.contrasenaErrorMessage = "Las nueva contraseña no coincide.";

                        return RedirectToAction("CambiarContraseña", "Usuarios", passModel);


                    }
                }
                else
                {
                    passModel.contrasenaErrorMessage = "La contraseña antigua no es correcta.";

                    return RedirectToAction("CambiarContraseña", "Usuarios", passModel);

                }
            }
            else
            {
                return View();
            }

        }
    }
}