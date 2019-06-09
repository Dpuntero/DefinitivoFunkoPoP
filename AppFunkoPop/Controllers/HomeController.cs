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

            Database1Entities1 db = new Database1Entities1();
            
                var prod = db.PRODUCTOes.Where(x => x.DESTACADO == true).ToList().GetRange(db.PRODUCTOes.Where(x => x.DESTACADO == true).ToList().Count()-3, db.PRODUCTOes.Where(x => x.DESTACADO == true).ToList().Count()-1);
                
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