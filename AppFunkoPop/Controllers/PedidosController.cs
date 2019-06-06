using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppFunkoPop.Models;
using Microsoft.Reporting.WebForms;

namespace ProyectoDawFunko.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Pedidos
        public ActionResult MisPedidos()
        {
            Database1Entities db = new Database1Entities();

            int idUsu = Convert.ToInt32(Session["USUARIO_ID"]);
            List<PEDIDO> aux = db.PEDIDOes.ToList();
            List<PEDIDO> aux2 = new List<PEDIDO>();

            foreach (var i in aux)
            {
                if (i.USUARIO_ID == idUsu)
                {
                    aux2.Add(i);
                }
            }
            return View(aux2);
        }
    }
}