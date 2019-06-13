using AppFunkoPop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProyectoDawFunko.Controllers
{
    public class CarritoController : Controller
    {
        /*public ActionResult CreacionCarrito()
        {
            using (Database1Entities db = new Database1Entities())
            {
                CARRITO nuevoCarrito = new CARRITO();
                nuevoCarrito.FECHA_CR = DateTime.Today;
                nuevoCarrito.USUARIO_ID = Convert.ToInt32(Session["USUARIO_ID"]);
                nuevoCarrito.PRECIO_T = "1";
                db.CARRITOes.Add(nuevoCarrito);
                db.SaveChanges();
            }


                return View();
        }
  
        public ActionResult AñadirProductoACarrito()
        {
            using (Database1Entities db = new Database1Entities())
            {
                int c = Convert.ToInt32(Session["USUARIO_ID"]);
                var carritoDetails = db.CARRITOes.Where(x => x.USUARIO_ID ==c).FirstOrDefault();
                if (carritoDetails != null)
                {

                }
                else
                {
                    CreacionCarrito();
                }
            }

                return RedirectToAction("Index","Home");
        }*/
        public ActionResult InicioCarrito()
        {
            if (Convert.ToString(Request.Cookies["Carrito"]) != "")
            {


                int loop1;
                HttpCookieCollection MyCookieColl;
                HttpCookie MyCookie;

                MyCookieColl = Request.Cookies;

                // Capture all cookie names into a string array.
                String[] arr1 = MyCookieColl.AllKeys;
                var listProductos = new List<ProductoCookie>();
                var listfinal = new List<ProductoUnidades>();
                // Grab individual cookie objects by cookie name.
                for (loop1 = 0; loop1 < arr1.Length; loop1++)
                {
                    MyCookie = MyCookieColl[arr1[loop1]];
                    if (MyCookie.Name == "Carrito")
                    {
                        
                        listProductos = JsonConvert.DeserializeObject<List<ProductoCookie>>(MyCookie.Value);

                        foreach (var item in listProductos)
                        {
                            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
                            {
                                int w = Convert.ToInt32(item.producto_Id);
                                PRODUCTO añadir = db.PRODUCTOes.Where(x => x.PRODUCTO_ID ==w).FirstOrDefault();
                                ProductoUnidades prodfin = new ProductoUnidades();

                                if (añadir.UD_DISPO < Convert.ToInt32(item.unidades))
                                {
                                   
                                    prodfin.Unidades = Convert.ToString(añadir.UD_DISPO);
                                    item.unidades = prodfin.Unidades;
                                }
                                else
                                {
                                    prodfin.Unidades = item.unidades;
                                }
                                prodfin.CATEGORIA = añadir.CATEGORIA;
                                prodfin.IMAGEN = añadir.IMAGEN;
                                prodfin.NOMBRE = añadir.NOMBREP;
                                prodfin.PRECIOUnidad = añadir.PRECIO;
                                prodfin.PRECIO =añadir.PRECIO * Convert.ToInt32(item.unidades);
                                prodfin.PRODUCTO_ID = añadir.PRODUCTO_ID;
                                prodfin.UD_DISPO = añadir.UD_DISPO;
                                listfinal.Add(prodfin);

                            }
                        }
                        return View(listfinal);


                    }
                               
                }
                return View(listfinal);
            }
            else
            {
                return RedirectToAction("CarritoVacio","Carrito");
            }


               
        }

        public ActionResult VaciarCarrito()
        {
            var cookie = Request.Cookies["Carrito"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            cookie.Value = string.Empty;
            Response.Cookies.Add(cookie);

            return RedirectToAction("CarritoVacio", "Carrito");
        }

        public ActionResult CarritoVacio()
        {
           

            return View();
        }
        

            public ActionResult CreacionCarrito(AppFunkoPop.Models.PRODUCTO productoModel)
        {
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
            {
                CARRITO nuevoCarrito = new CARRITO();
                nuevoCarrito.FECHA_CR = DateTime.Today;
                nuevoCarrito.USUARIO_ID = Convert.ToInt32(Session["USUARIO_ID"]);
                nuevoCarrito.PRECIO_T = 3;
                nuevoCarrito.CARRITO_ID = 1;
                db.CARRITOes.Add(nuevoCarrito);
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult CrearCookies(AppFunkoPop.Models.PRODUCTO productoModel, string unidades)
        {
            string carrito = Convert.ToString(productoModel.PRODUCTO_ID) + unidades;
            HttpCookie cookieCarrito = new HttpCookie("cookie_one", carrito);
            ControllerContext.HttpContext.Response.SetCookie(cookieCarrito);
            return View();
        }

        public ActionResult RecogerIdEnviarProducto(string id, string unidades)
        {
            FunkoPopDDBBEntities db = new FunkoPopDDBBEntities();
            int idfin = Convert.ToInt32(id);

            PRODUCTO añadir = db.PRODUCTOes.Where(x => x.PRODUCTO_ID == idfin).FirstOrDefault();
            return  AñadirProductoACarrito(añadir, unidades);
        }


            public ActionResult AñadirProductoACarrito(AppFunkoPop.Models.PRODUCTO productoModel, string unidades)
        {

            if (Convert.ToString(Request.Cookies["Carrito"])!= "")
            {
                int loop1, loop2;
                HttpCookie MyCookie;
                MyCookie = Request.Cookies["Carrito"];

                var listProductos = new List<ProductoCookie>();

                    if (MyCookie.Name == "Carrito")
                    {
                        Boolean comp = false;
                         listProductos = JsonConvert.DeserializeObject<List<ProductoCookie>>(MyCookie.Value);

                        foreach (var item in listProductos)
                        {
                            if (Convert.ToString(productoModel.PRODUCTO_ID) ==(item.producto_Id))
                            {
                                    if(productoModel.UD_DISPO< Convert.ToInt32(item.unidades) + Convert.ToInt32(unidades))
                                    {
                                item.unidades = Convert.ToString(productoModel.UD_DISPO);
                            }
                            else
                            {

                                item.unidades = Convert.ToString(Convert.ToInt32(item.unidades) + Convert.ToInt32(unidades));
                            }

                                
                                comp = true;
                            }
                        }
                        if (comp == false)
                        {
                            ProductoCookie productoAMeter = new ProductoCookie();
                            
                            productoAMeter.producto_Id = Convert.ToString(productoModel.PRODUCTO_ID);
                            productoAMeter.unidades = unidades;
                            listProductos.Add(productoAMeter);
                        }

                    var json = new JavaScriptSerializer().Serialize(listProductos);
                    MyCookie.Value = json;
                    DateTime now = DateTime.Now;
                    MyCookie.Expires = now.AddHours(1);
                    Response.Cookies.Add(MyCookie);
                }
            }
            else
            {              
                HttpCookie MyCookie = new HttpCookie("Carrito");
                DateTime now = DateTime.Now;
                ProductoCookie productoAMeter = new ProductoCookie();
                List<ProductoCookie> arrayDeCookies = new List<ProductoCookie>();
                productoAMeter.producto_Id = Convert.ToString(productoModel.PRODUCTO_ID);
                productoAMeter.unidades = unidades;
                arrayDeCookies.Add(productoAMeter);
                var json = new JavaScriptSerializer().Serialize(arrayDeCookies);
                MyCookie.Value = json ;
                MyCookie.Expires = now.AddHours(1);
                Response.Cookies.Add(MyCookie);
            }
            return RedirectToAction("InicioCarrito", "Carrito");
        }

    
        public ActionResult Eliminar1ProductoCarrito(int id)
        {
            var listProductos = new List<ProductoCookie>();
            HttpCookie MyCookie;
            MyCookie = Request.Cookies["Carrito"];
            listProductos = JsonConvert.DeserializeObject<List<ProductoCookie>>(MyCookie.Value);
            string idborrar = "";
            foreach (var item in listProductos)
            {
                if (Convert.ToInt32( item.producto_Id)== id)
                {
                    item.unidades = Convert.ToString(Convert.ToInt32(item.unidades) - 1);
                    if (Convert.ToInt32(item.unidades) <= 0)
                    {
                        idborrar = item.producto_Id;
                    }
                }
            }

            FunkoPopDDBBEntities db = new FunkoPopDDBBEntities();
            

            ProductoCookie borrar = listProductos.Where(x => x.producto_Id == idborrar).FirstOrDefault();

            listProductos.Remove(borrar);
            if (listProductos.Count() == 0)
            {


                return RedirectToAction("VaciarCarrito", "Carrito");
            }
            else
            {
                var json = new JavaScriptSerializer().Serialize(listProductos);
                MyCookie.Value = json;
                DateTime now = DateTime.Now;
                MyCookie.Expires = now.AddHours(1);
                Response.Cookies.Add(MyCookie);

                return RedirectToAction("InicioCarrito", "Carrito");
            }

            
        }

        public ActionResult Añadir1ProductoCarrito(int id)
        {
            var listProductos = new List<ProductoCookie>();
            HttpCookie MyCookie;
            MyCookie = Request.Cookies["Carrito"];
            listProductos = JsonConvert.DeserializeObject<List<ProductoCookie>>(MyCookie.Value);
        
            foreach (var item in listProductos)
            {
                if (Convert.ToInt32(item.producto_Id) == id)
                {
                    FunkoPopDDBBEntities db = new FunkoPopDDBBEntities();
                    int c = Convert.ToInt32(item.producto_Id);
                   var producto = db.PRODUCTOes.Where(x => x.PRODUCTO_ID == c).FirstOrDefault();
                    if (producto.UD_DISPO < Convert.ToInt32(item.unidades) + 1)
                    {
                        item.unidades = Convert.ToString(producto.UD_DISPO);
                    }
                    else
                    {
                        item.unidades = Convert.ToString(Convert.ToInt32(item.unidades) + 1);
                    }

                                        
                }
            }

            

                var json = new JavaScriptSerializer().Serialize(listProductos);
                MyCookie.Value = json;
                DateTime now = DateTime.Now;
                MyCookie.Expires = now.AddHours(1);
                Response.Cookies.Add(MyCookie);

                return RedirectToAction("InicioCarrito", "Carrito");

        }

        public ActionResult EliminarProductoCarrito(int id)
        {
            var listProductos = new List<ProductoCookie>();
            HttpCookie MyCookie;
            MyCookie = Request.Cookies["Carrito"];
            listProductos = JsonConvert.DeserializeObject<List<ProductoCookie>>(MyCookie.Value);
            string idborrar = "";
            foreach (var item in listProductos)
            {
                if (Convert.ToInt32(item.producto_Id) == id)
                {
                    item.unidades = "0";
                    if (item.unidades == "0")
                    {
                        idborrar = item.producto_Id;
                    }
                }
            }

          
            ProductoCookie borrar = listProductos.Where(x => x.producto_Id == idborrar).FirstOrDefault();

            listProductos.Remove(borrar);
            if (listProductos.Count() == 0)
            {


                return RedirectToAction("VaciarCarrito", "Carrito");
            }
            else
            {
                var json = new JavaScriptSerializer().Serialize(listProductos);
                MyCookie.Value = json;
                DateTime now = DateTime.Now;
                MyCookie.Expires = now.AddHours(1);
                Response.Cookies.Add(MyCookie);

                return RedirectToAction("InicioCarrito", "Carrito");
            }


        }
    }   
}