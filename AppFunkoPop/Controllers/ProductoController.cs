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
                using (Database1Entities db = new Database1Entities())
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
            nuevoProd.IMAGEN = nuevoProd.NOMBREP + "1.jpg";
            nuevoProd.LINK = nuevoProd.NOMBREP + "2.jpg";
            using (Database1Entities db = new Database1Entities())
            {

                db.PRODUCTOes.Add(nuevoProd);
                db.SaveChanges();
            }
           
            return RedirectToAction("Productos","Producto", new { id= nuevoProd.PRODUCTO_ID } );
            
        }
    }
}