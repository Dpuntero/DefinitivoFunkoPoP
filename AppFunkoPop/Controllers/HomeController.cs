using AppFunkoPop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoDawFunko.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            FunkoPopDDBBEntities db = new FunkoPopDDBBEntities();
            
                var prod = db.PRODUCTOes.Where(x => x.DESTACADO == true).ToList();
                
                foreach (var item in prod)
                {
                    Debug.WriteLine(item.NOMBREP);
               
                }

            
            return View(prod);
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