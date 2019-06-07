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
            Database1Entities db = new Database1Entities();
            ViewBag.Productos = db.PRODUCTOes.ToList();
            return View();
        }

        // GET: PRODUCTOes/EditarProducto/5

        public ActionResult EditarProducto(int? id)
        {
            Database1Entities db = new Database1Entities();
            PRODUCTO productoAEditar = db.PRODUCTOes.Find(id);

            return View("EditandoProducto", productoAEditar);
        }
       

        [HttpPost]
        public ActionResult EditandoProducto(PRODUCTO productoModificado)
        {           
            using (Database1Entities db = new Database1Entities())
            {
                PRODUCTO productoOriginal = db.PRODUCTOes.Where(c => c.PRODUCTO_ID == productoModificado.PRODUCTO_ID).First();
                productoOriginal.NOMBREP = productoModificado.NOMBREP;
                productoOriginal.CATEGORIA = productoModificado.CATEGORIA;
                productoOriginal.DESCRIP = productoModificado.DESCRIP;
                productoOriginal.UD_DISPO = productoModificado.UD_DISPO;
                productoOriginal.PRECIO = productoModificado.PRECIO;
                productoOriginal.V_ID = productoModificado.V_ID;
                productoOriginal.IMAGEN = productoModificado.LINK;
                db.SaveChanges();
                return RedirectToAction("GestionProductos");
            }
        }

        [HttpPost]
        //Metodo para eliminar productos por su id
        public ActionResult EliminarProductos(int[] borrados)
        {

            using (Database1Entities db = new Database1Entities())
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
            using (Database1Entities db = new Database1Entities())
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
            using (Database1Entities db = new Database1Entities())
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
            Database1Entities db = new Database1Entities();
            ViewBag.Usuarios = db.USUARIOs.ToList();
            return View();
        }

        // GET: USUARIOs/EditarUsuario/

        public ActionResult EditarUsuario(int? id)
        {
            Database1Entities db = new Database1Entities();
            USUARIO usuarioAEditar = db.USUARIOs.Find(id);

            return View("EditandoUsuario", usuarioAEditar);
        }


        [HttpPost]
        public ActionResult EditandoUsuario(USUARIO usuarioModificado)
        {
            using (Database1Entities db = new Database1Entities())
            {
                USUARIO usuarioOriginal = db.USUARIOs.Where(c => c.USUARIO_ID == usuarioModificado.USUARIO_ID).First();
                usuarioOriginal.NOMBRE = usuarioModificado.NOMBRE;
                usuarioOriginal.APELLIDOS = usuarioModificado.APELLIDOS;
                usuarioOriginal.EMAIL = usuarioModificado.EMAIL;
                usuarioOriginal.PASSWD = usuarioModificado.PASSWD;
                usuarioOriginal.TLFN = usuarioModificado.TLFN;
                usuarioOriginal.DIRECCION = usuarioModificado.DIRECCION;
                usuarioOriginal.CIUDAD = usuarioModificado.CIUDAD;
                usuarioOriginal.PAIS = usuarioModificado.PAIS;
                usuarioOriginal.CP = usuarioModificado.CP;
                usuarioOriginal.ROL.N_ROL = usuarioModificado.ROL.N_ROL;
                db.SaveChanges();
                return RedirectToAction("GestionUsuarios");
            }
        }
    }
}