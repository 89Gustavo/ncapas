using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Capa_Entidad;
using Capa_Negocio;

namespace mvcCapas.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ListarMarca() {
            MarcaBL oMarcaBL = new MarcaBL();

            return Json(oMarcaBL.ListaMarca(), JsonRequestBehavior.AllowGet);
        
        }
    }
}