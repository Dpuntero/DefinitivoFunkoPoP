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
        //Método para ver la pa´gina de detalles del producto
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

        //Método que manda a la vista con el formulario para añadir un nuevo producto
        public ActionResult NuevoProducto()
        {
            return View();
        }

        //Método que recoge los datos introducidos en al formulario y añade un nuevo producto a la tabla
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