using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppFunkoPop.Models;

namespace ProyectoDawFunko.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Pedidos
        public ActionResult MisPedidos()
        {
            Database1Entities db = new Database1Entities();


            return View(db.PEDIDOPRODUCTOes.Where(a => a.PEDIDO_ID==4));
        }
    }
}