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
        // GET: Producto
        public ActionResult Productos()
        {
            /* List<PRODUCTO> listaProductos;
             using (Database1Entities db = new Database1Entities())
             {
                 listaProductos  = (from prod in db.PRODUCTOes
                              select new PRODUCTO
                              {
                                  PRODUCTO_ID = prod.PRODUCTO_ID,
                                  NOMBREP = prod.NOMBREP,
                                  PRECIO = prod.PRECIO,
                                  DESCRIP = prod.DESCRIP,
                                  CATEGORIA = prod.CATEGORIA,
                                  UD_DISPO = prod.UD_DISPO,
                                  V_ID = prod.V_ID,
                                  IMAGEN = prod.IMAGEN,
                                  LINK = prod.LINK
                              }).ToList();
             }*/
            return View();
        }

        public ActionResult NuevoProducto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NuevoProducto(AppFunkoPop.Models.PRODUCTO nuevoProd)
        {
            //try{
            //   System.Diagnostics.Debug.WriteLine("hola");
            // if (ModelState.IsValid)
            //{
            //  System.Diagnostics.Debug.WriteLine("Entra en el if");
            using (Database1Entities db = new Database1Entities())
            {

                db.PRODUCTOes.Add(nuevoProd);
                db.SaveChanges();
            }
            
            return Redirect("~/Producto/Productos");
                //}
               //return View("Productos");
            //}catch(Exception ex)
            //{
                
              //  throw new Exception(ex.Message);
            //}
        }
    }
}