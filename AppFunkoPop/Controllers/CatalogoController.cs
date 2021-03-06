﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppFunkoPop.Models;

namespace ProyectoDawFunko.Controllers
{
    public class CatalogoController : Controller
    {
        // GET: Catalogo
      

            public ActionResult Catalogo()
        {
            
            List<PRODUCTO> prod = new List<PRODUCTO>();
            string Categoria = Request.Form["categoria"];
            string Subcategoria = Request.Form["subcategoria"];
            if (Categoria == null||Categoria=="todos")
            {
               
                using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
                {
                    prod = db.PRODUCTOes.ToList();

                }
            }
            else if(Categoria!=null&&Subcategoria==null)
            {
               
              
                using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
                {
                    prod = db.PRODUCTOes.Where(c => c.CATEGORIA == Categoria).ToList();

                }
            }

            return View(prod);

        }
        [HttpPost]
        public ActionResult Catalogo(FormCollection collection)
        {
            string Categoria = Convert.ToString(collection["categoria"]);
            List<PRODUCTO> prod = new List<PRODUCTO>();
            
            string Subcategoria = Convert.ToString(collection["subcategoria"]);
            if (Categoria == null || Categoria == "todos")
            {

                using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
                {
                    prod = db.PRODUCTOes.ToList();

                }
            }
            else if (Categoria != null && (Subcategoria == null|| Subcategoria == "Todos"))
            {


                using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
                {
                    prod = db.PRODUCTOes.Where(c => c.CATEGORIA == Categoria).ToList();

                }
            }
            else
            {
                using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
                {
                    prod = db.PRODUCTOes.Where(c => c.SUBCATEGORIA == Subcategoria).ToList();

                }


            }

            return View(prod);
            
        }

        public ActionResult EnvioMenu(string Categoria, string Subcategoria)
        {
            
            List<PRODUCTO> prod = new List<PRODUCTO>();

            
            if (Categoria == null || Categoria == "todos")
            {

                using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
                {
                    prod = db.PRODUCTOes.ToList();

                }
            }
            else if (Categoria != null && (Subcategoria == null || Subcategoria == "Todos"))
            {


                using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
                {
                    prod = db.PRODUCTOes.Where(c => c.CATEGORIA == Categoria).ToList();

                }
            }
            else
            {
                using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
                {
                    prod = db.PRODUCTOes.Where(c => c.SUBCATEGORIA == Subcategoria).ToList();

                }


            }

            return View("Catalogo", prod);

        }

        /*
        public ActionResult MostrarProductos()
        {


            return View();
        }
        [HttpPost]
        public ActionResult FiltrarCategorias()
        {
            string Categoria = Request.Form["categoria"];
            List<PRODUCTO> prod = new List<PRODUCTO>();
            using (Database1Entities db = new Database1Entities())
            {
                prod = db.PRODUCTOes.Where(c=> c.CATEGORIA==Categoria).ToList();

            }

            return View(prod);
        }*/
    }
}