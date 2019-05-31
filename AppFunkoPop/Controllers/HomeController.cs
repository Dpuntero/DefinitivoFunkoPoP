using AppFunkoPop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoDawFunko.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()


        {
            
           /* USUARIO nuevo = new USUARIO()
            {
                
                NOMBRE = "david",
                APELLIDOS = "puntero",
                EMAIL = "wma",
                PASSWD = "1232",
                TLFN=123,
                DIRECCION="asjkd",
                CIUDAD="asd",
                PAIS="asd",
                CP=123,
                ID_ROL = 1
            };
            
            using ( Database1Entities db= new Database1Entities())
            {
                db.USUARIOs.Add(nuevo);
                db.SaveChanges();
            }
            */
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult catalogo()
        {
            ViewBag.Message = "Your contact page. Nueva!";

            return View();
        }
    }


}