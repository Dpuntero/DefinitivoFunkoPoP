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
                            using (Database1Entities db = new Database1Entities())
                            {
                                int w = Convert.ToInt32(item.producto_Id);
                                PRODUCTO añadir = db.PRODUCTOes.Where(x => x.PRODUCTO_ID ==w).FirstOrDefault();
                                ProductoUnidades prodfin = new ProductoUnidades();
                                prodfin.Unidades = item.unidades;
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
                return View();
            }


               
        }


        public ActionResult CreacionCarrito(AppFunkoPop.Models.PRODUCTO productoModel)
        {
            using (Database1Entities db = new Database1Entities())
            {
                CARRITO nuevoCarrito = new CARRITO();
                nuevoCarrito.FECHA_CR = DateTime.Today;
                nuevoCarrito.USUARIO_ID = Convert.ToInt32(Session["USUARIO_ID"]);
                nuevoCarrito.PRECIO_T = "3";
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


        public ActionResult AñadirProductoACarrito(AppFunkoPop.Models.PRODUCTO productoModel, string unidades)
        {

            if (Convert.ToString(Request.Cookies["Carrito"])!= "")
            {

                
                int loop1, loop2;
                //HttpCookieCollection MyCookieColl;
                HttpCookie MyCookie;

                MyCookie = Request.Cookies["Carrito"];

                // Capture all cookie names into a string array.
                //String[] arr1 = MyCookieColl.AllKeys;
                var listProductos = new List<ProductoCookie>();
                // Grab individual cookie objects by cookie name.
                //for (loop1 = 0; loop1 < arr1.Length; loop1++)
                //{
                   // MyCookie = MyCookieColl[arr1[loop1]];
                    if (MyCookie.Name == "Carrito")
                    {
                        Boolean comp = false;
                         listProductos = JsonConvert.DeserializeObject<List<ProductoCookie>>(MyCookie.Value);

                        foreach (var item in listProductos)
                        {
                            if (Convert.ToString(productoModel.PRODUCTO_ID) ==(item.producto_Id))
                            {
                                item.unidades =Convert.ToString( Convert.ToInt32(item.unidades) + Convert.ToInt32(unidades));
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

                        //MyCookie.Value = MyCookie.Value + "," + " Id:"+Convert.ToString(productoModel.PRODUCTO_ID)+"-Unidades:"+unidades;
                   // }
                    var json = new JavaScriptSerializer().Serialize(listProductos);
                    MyCookie.Value = json;
                    DateTime now = DateTime.Now;

                    MyCookie.Expires = now.AddHours(1);

                    Response.Cookies.Add(MyCookie);
                    /*Response.Write("Cookie: " + MyCookie.Name + "<br>");
                    Response.Write("Secure:" + MyCookie.Secure + "<br>");

                    //Grab all values for single cookie into an object array.
                    String[] arr2 = MyCookie.Values.AllKeys;

                    //Loop through cookie Value collection and print all values.
                    for (loop2 = 0; loop2 < arr2.Length; loop2++)
                    {
                        Response.Write("Value" + loop2 + ": " + Server.HtmlEncode(arr2[loop2]) + "<br>");
                    }*/
                }


                /*HttpCookie MyCookie = new HttpCookie("Carrito");
                DateTime now = DateTime.Now;

                MyCookie.Value = MyCookie.Value+","+Convert.ToString(productoModel.PRODUCTO_ID);
                MyCookie.Expires = now.AddHours(1);
            
                Response.Cookies.Add(MyCookie);*/
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





           /* using (Database1Entities db = new Database1Entities())
            {


                int c = Convert.ToInt32(Session["USUARIO_ID"]);
                var carritoDetails = db.CARRITOes.Where(x => x.USUARIO_ID == c).FirstOrDefault();
                if (carritoDetails != null)
                {

                }
                else
                {
                    //  CreacionCarrito(productoModel);
                }
            }*/

            return RedirectToAction("Index", "Home");
        }

        

    }   
}