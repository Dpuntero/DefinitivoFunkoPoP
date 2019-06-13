using AppFunkoPop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoDawFunko.Models
{
    public class CarritoModel : Controller
    {
        // GET: Carrito
        public ActionResult Index()
        {
            return View();
        }

        public List<PRODUCTO> MostrarProductos()
        {
            var productos = new List<PRODUCTO>();
            try
            {
                using(FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
                {
                    productos = db.PRODUCTOes.ToList();


                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return productos;
        }
    }

  
}