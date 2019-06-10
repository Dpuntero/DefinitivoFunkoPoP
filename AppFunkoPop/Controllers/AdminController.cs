using AppFunkoPop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoDawFunko.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult PanelDeControlAdmin()
        {
            return View();
        }

        public ActionResult NuevoProducto()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        //METODOS PARA GESTION DE PRODUCTOS
        // GET: PRODUCTOes
        public ActionResult GestionProductos()
        {
            Database1Entities1 db = new Database1Entities1();
            ViewBag.Productos = db.PRODUCTOes.ToList();
            return View();
        }

        // GET: PRODUCTOes/EditarProducto/5

        public ActionResult EditarProducto(int? id)
        {
            Database1Entities1 db = new Database1Entities1();
            PRODUCTO productoAEditar = db.PRODUCTOes.Find(id);

            return View("EditandoProducto", productoAEditar);
        }
       

        [HttpPost]
        public ActionResult EditandoProducto(PRODUCTO productoModificado)
        {           
            using (Database1Entities1 db = new Database1Entities1())
            {
                PRODUCTO productoOriginal = db.PRODUCTOes.Where(c => c.PRODUCTO_ID == productoModificado.PRODUCTO_ID).First();
                productoOriginal.NOMBREP = productoModificado.NOMBREP;
                productoOriginal.CATEGORIA = productoModificado.CATEGORIA;
                productoOriginal.DESCRIP = productoModificado.DESCRIP;
                productoOriginal.UD_DISPO = productoModificado.UD_DISPO;
                productoOriginal.PRECIO = productoModificado.PRECIO;
                productoOriginal.PROVEEDOR_ID = productoModificado.PROVEEDOR_ID;
                productoOriginal.IMAGEN = productoModificado.IMAGEN2;
                db.SaveChanges();
                return RedirectToAction("GestionProductos");
            }
        }

        [HttpPost]
        //Metodo para eliminar productos por su id
        public ActionResult EliminarProductos(int[] borrados)
        {

            using (Database1Entities1 db = new Database1Entities1())
            {
                foreach (var id in borrados)
                {
                    if (id != 0)
                    {
                        System.Diagnostics.Debug.WriteLine(id);
                        PRODUCTO aEliminar = db.PRODUCTOes.Find(id);
                        db.PRODUCTOes.Remove(aEliminar);

                    }
                }
                db.SaveChanges();
                return RedirectToAction("GestionProductos");
            }
        }

        //FIN METODOS PRODUCTOS

        //METODOS PARA GESTION DE PEDIDOS
        public ActionResult GestionPedidos()
        {
            using (Database1Entities1 db = new Database1Entities1())
            {
                List<PEDIDO> pedidos = new List<PEDIDO>();
                pedidos = db.PEDIDOes.ToList();

                ViewBag.listaEstados = new List<ESTADO_ENVIO>(db.ESTADO_ENVIO.ToList());
                return View(pedidos);

            }
        }

        [HttpPost]
        //public ActionResult CambiarEstado(PEDIDO pedidoModificado)
        public ActionResult CambiarEstado(int pedidoId, int estadoId)
        {
            using (Database1Entities1 db = new Database1Entities1())
            {
                PEDIDO pedidoOriginal = db.PEDIDOes.Where(c => c.PEDIDO_ID == pedidoId).First();

                pedidoOriginal.ESTADO_ENVIO = estadoId;

                db.SaveChanges();
                return RedirectToAction("GestionPedidos");
            }
        }

        //METODOS GESTION DE USUARIOS

        public ActionResult GestionUsuarios()
        {
            Database1Entities1 db = new Database1Entities1();
            ViewBag.Usuarios = db.USUARIOs.ToList();
            return View();
        }

        // GET: USUARIOs/EditarUsuario/

        public ActionResult EditarUsuario(int? id)
        {
            Database1Entities1 db = new Database1Entities1();
            USUARIO usuarioAEditar = db.USUARIOs.Find(id);
            ViewBag.Roles = db.ROLs.ToList();

            return View("EditandoUsuario", usuarioAEditar);
        }


        [HttpPost]
        public ActionResult EditandoUsuario(USUARIO usuarioModificado)
        {
            using (Database1Entities1 db = new Database1Entities1())
            {
                
                USUARIO usuarioOriginal = db.USUARIOs.Where(c => c.USUARIO_ID == usuarioModificado.USUARIO_ID).First();
                usuarioOriginal.NOMBRE = usuarioModificado.NOMBRE;
                usuarioOriginal.APELLIDOS = usuarioModificado.APELLIDOS;
                usuarioOriginal.EMAIL = usuarioModificado.EMAIL;
                usuarioOriginal.PASSWD = usuarioOriginal.PASSWD; //Para no tener que tocar la pass
                usuarioOriginal.TLFN = usuarioModificado.TLFN;
                usuarioOriginal.DIRECCION = usuarioModificado.DIRECCION;
                usuarioOriginal.CIUDAD = usuarioModificado.CIUDAD;
                usuarioOriginal.PAIS = usuarioModificado.PAIS;
                usuarioOriginal.CP = usuarioModificado.CP;
                usuarioOriginal.ID_ROL = usuarioModificado.ID_ROL;
                db.SaveChanges();
                return RedirectToAction("GestionUsuarios");
            }
        }

        [HttpPost]
        //Metodo para eliminar productos por su id
        public ActionResult EliminarUsuarios(int[] borrados)
        {

            using (Database1Entities1 db = new Database1Entities1())
            {
                foreach (var id in borrados)
                {
                    if (id != 0)
                    {
                        System.Diagnostics.Debug.WriteLine(id);
                        USUARIO aEliminar = db.USUARIOs.Find(id);
                        db.USUARIOs.Remove(aEliminar);

                    }
                }
                db.SaveChanges();
                return RedirectToAction("GestionUsuarios");
            }
        }

        public ActionResult CambiarRoles(int usuarioId, int rolId)
        {
            using (Database1Entities1 db = new Database1Entities1())
            {
                USUARIO usuarioOriginal = db.USUARIOs.Where(c => c.USUARIO_ID == usuarioId).First();

                usuarioOriginal.ROL.ID_ROL = rolId;

                db.SaveChanges();
                return RedirectToAction("GestionUsuarios");
            }
        }
    }
}