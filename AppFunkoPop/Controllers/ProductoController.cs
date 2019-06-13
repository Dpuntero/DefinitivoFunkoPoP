using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using AppFunkoPop.Models;


namespace AppFunkoPop.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Productos
        public ActionResult Productos(int id)
        {

               
            
                PRODUCTO prod = new PRODUCTO();
                using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
                {

                    prod = db.PRODUCTOes.Find(id);



                }
            if (prod!= null)
            {
                return View(prod);

            }
            else
            {
                return RedirectToAction("Catalogo", "Catalogo");
            }
            





        }

        public ActionResult NuevoProducto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NuevoProducto(AppFunkoPop.Models.PRODUCTO nuevoProd)
        {
            nuevoProd.IMAGEN = nuevoProd.IMAGEN + ".jpg";
            nuevoProd.IMAGEN2 = nuevoProd.IMAGEN2 + ".jpg";
            
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
            {

                db.PRODUCTOes.Add(nuevoProd);
                db.SaveChanges();
            }
           
            return RedirectToAction("Productos","Producto", new { id= nuevoProd.PRODUCTO_ID } );
            
        }
    }
}