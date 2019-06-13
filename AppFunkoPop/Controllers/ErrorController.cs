using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppFunkoPop.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(int error = 0)
        {
            switch (error)
            {
                case 505:
                    ViewBag.Title = "Ocurrio un error inesperado";
                    ViewBag.Description = "Error 505";
                    break;

                case 404:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "Error 404: La URL que está intentando ingresar no existe";
                    break;

                default:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "Un error desconocido nos acecha...(Error: "+error+")";
                    break;
            }

            return View("~/views/Error/_ErrorPage.cshtml");
        }
    }
}