using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Capa_Negocio;
using Capa_Entidad;

namespace mvcCapas.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult listarProductos()
        {
            ProductosBL oProductosBL = new ProductosBL();
            return Json(oProductosBL.ListarProducto(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FiltrarProductos(string nombreProducto)
        {
            ProductosBL oProductosBL = new ProductosBL();
            return Json(oProductosBL.FiltrarProductos(nombreProducto), JsonRequestBehavior.AllowGet);
        }
    }
}