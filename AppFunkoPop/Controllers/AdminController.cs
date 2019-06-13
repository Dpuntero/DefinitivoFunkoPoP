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
        //Método para mandar al panel de control de administrador
        public ActionResult PanelDeControlAdmin()
        {
            return View();
        }
        //Método para redirigir al formulario para añadir un nuevo producto
        public ActionResult NuevoProducto()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //Método para mandar al formulario de añadir un nuevo proveedor
        public ActionResult NuevoProveedor()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //Método que recoge los datos introducidos en el formulario de creación de proveedores y los añade a la base de datos
        [HttpPost]
        public ActionResult CrearProveedor (AppFunkoPop.Models.PROVEEDOR nuevoProv)
        {                 
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
            {
                db.PROVEEDORs.Add(nuevoProv);
                db.SaveChanges();
            }
            return RedirectToAction("GestionProveedores");
        }
        //Método que manda a la vista con el listado de proveedores
        public ActionResult GestionProveedores()
        {
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
            {
                ViewBag.Proveedores = db.PROVEEDORs.ToList();
                return View();
            }
        }
        //Método que recoge el id del proveedor a editar y manda a la vista de edicion con el objeto para rellenar los campos con los datos
        public ActionResult EditarProveedor(int id)
        {
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
            {
                PROVEEDOR buscarProveedor = db.PROVEEDORs.Find(id);
           
            return View("EditandoProveedor", buscarProveedor);
            }
        }

        //Método que recoge los datos del formulario de la página de edición de proveedores y actualiza el registro en la BBDD
        [HttpPost]
        public ActionResult EditandoProveedor(PROVEEDOR proveedorEditar)
        {
            using(FunkoPopDDBBEntities db = new FunkoPopDDBBEntities()){
            PROVEEDOR buscarProveedor = db.PROVEEDORs.Find(proveedorEditar.PROVEEDOR_ID);
            buscarProveedor.NOMBRE_PROV = proveedorEditar.NOMBRE_PROV;
            buscarProveedor.EMAIL_PROV = proveedorEditar.EMAIL_PROV;
            buscarProveedor.TLFN_PROV = proveedorEditar.TLFN_PROV;
            buscarProveedor.DESCRIPCION_PROV = proveedorEditar.DESCRIPCION_PROV;
            db.SaveChanges();
            return RedirectToAction("GestionProveedores");
            }
        }

        //Método que recoge una array con los id de proveedores y elimina los registros en la BBDD
        // GET: PROVEEDORs/Delete/5
        public ActionResult BorrarProveedor(int[] borrados)
        {        
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
            {
                foreach (var id in borrados)
                {
                    if (id != 0)
                    {                       
                        PROVEEDOR aEliminar = db.PROVEEDORs.Find(id);
                        db.PROVEEDORs.Remove(aEliminar);
                    }
                }
                db.SaveChanges();
                return RedirectToAction("GestionProveedores");
            }           
        }

        //Método que manda a la vista con el listado de los productos
        // GET: PRODUCTOes
        public ActionResult GestionProductos()
        {
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
            {
                ViewBag.Productos = db.PRODUCTOes.ToList();
            }
            return View();
        }

        //Método que recoge el id del producto que se va a editar y manda los datos a la vista con el formulario de edición para rellenar con los datos
        // GET: PRODUCTOes/EditarProducto/5
        public ActionResult EditarProducto(int id)
        {
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
            {
                PRODUCTO productoAEditar = db.PRODUCTOes.Where(x => x.PRODUCTO_ID == id).FirstOrDefault();

                return View ("EditandoProducto", productoAEditar);
            }
        }

        //Método que recoge los nuevos datos del producto y actualiza el registro en la BBDD
        [HttpPost]
        public ActionResult EditandoProducto(PRODUCTO productoModificado)
        {           
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
            {
                PRODUCTO productoOriginal = db.PRODUCTOes.Where(c => c.PRODUCTO_ID == productoModificado.PRODUCTO_ID).First();
                productoOriginal.NOMBREP = productoModificado.NOMBREP;
                productoOriginal.CATEGORIA = productoModificado.CATEGORIA;
                productoOriginal.SUBCATEGORIA = productoModificado.SUBCATEGORIA;
                productoOriginal.DESCRIP = productoModificado.DESCRIP;
                productoOriginal.UD_DISPO = productoModificado.UD_DISPO;
                productoOriginal.DESTACADO = productoModificado.DESTACADO;           
                productoOriginal.PRECIO = productoModificado.PRECIO;
                productoOriginal.PROVEEDOR_ID = productoModificado.PROVEEDOR_ID;
                productoOriginal.IMAGEN = productoModificado.IMAGEN;
                productoOriginal.IMAGEN2 = productoModificado.IMAGEN2;
                db.SaveChanges();
                return RedirectToAction("GestionProductos");
            }
        }

        //Metodo que recoge de laa vista un array de id de productos y los elimina de la BBDD
        [HttpPost]
        public ActionResult EliminarProductos(int[] borrados)
        {
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
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

        //Método que manda a la lista de gestión de pedidos con la lista de estados para mostrar en el desplegable
        public ActionResult GestionPedidos()
        {
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
            {
                List<PEDIDO> pedidos = new List<PEDIDO>();
                pedidos = db.PEDIDOes.ToList();

                ViewBag.listaEstados = new List<ESTADO_ENVIO>(db.ESTADO_ENVIO.ToList());
                return View(pedidos);
            }
        }

        //Método que actualiza el estado de un pedido al correspondiente al id recogido
        [HttpPost]
        public ActionResult CambiarEstado(int pedidoId, int estadoId)
        {
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
            {
                PEDIDO pedidoOriginal = db.PEDIDOes.Where(c => c.PEDIDO_ID == pedidoId).First();

                pedidoOriginal.ESTADO_ENVIO = estadoId;

                db.SaveChanges();
                return RedirectToAction("GestionPedidos");
            }
        }

        //Método que lleva a la vista con el listado de usuarios
        public ActionResult GestionUsuarios()
        {
            FunkoPopDDBBEntities db = new FunkoPopDDBBEntities();
            ViewBag.Usuarios = db.USUARIOs.ToList();
            return View();
        }

        //Método que recoge el id del usuario a editr y manda a la vista del formulario de edición junto con el listado de roles
        public ActionResult EditarUsuario(int? id)
        {
            FunkoPopDDBBEntities db = new FunkoPopDDBBEntities();
            USUARIO usuarioAEditar = db.USUARIOs.Find(id);
            ViewBag.Roles = db.ROLs.ToList();

            return View("EditandoUsuario", usuarioAEditar);
        }

        //Método que recoge los nuevos datos de los usuarios y actualiza los registros de la BBDD
        [HttpPost]
        public ActionResult EditandoUsuario(USUARIO usuarioModificado)
        {
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
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
        //Metodo para eliminar productos recogidos de un array de ids
        public ActionResult EliminarUsuarios(int[] borrados)
        {

            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
            {
                foreach (var id in borrados)
                {
                    if (id != 0)
                    {
                        System.Diagnostics.Debug.WriteLine(id);
                        USUARIO aEliminar = db.USUARIOs.Find(id);
                        List<PEDIDO> pEliminar = db.PEDIDOes.Where(c => c.USUARIO_ID == id).ToList();
                        List<PEDIDOPRODUCTO> ppEliminar = new List<PEDIDOPRODUCTO>();
                        foreach (var x in pEliminar)
                        {
                            ppEliminar = db.PEDIDOPRODUCTOes.Where(b => b.PEDIDO_ID == x.PEDIDO_ID).ToList();
                            foreach(var y in ppEliminar)
                            {
                                db.PEDIDOPRODUCTOes.Remove(y);
                            }
                            db.PEDIDOes.Remove(x);

                        }
                        db.USUARIOs.Remove(aEliminar);

                    }
                }
                db.SaveChanges();
                return RedirectToAction("GestionUsuarios");
            }
        }

        //Método para cambiar de rol a un usuario
        public ActionResult CambiarRoles(int usuarioId, int rolId)
        {
            using (FunkoPopDDBBEntities db = new FunkoPopDDBBEntities())
            {
                USUARIO usuarioOriginal = db.USUARIOs.Where(c => c.USUARIO_ID == usuarioId).First();

                usuarioOriginal.ROL.ID_ROL = rolId;

                db.SaveChanges();
                return RedirectToAction("GestionUsuarios");
            }
        }
    }
}