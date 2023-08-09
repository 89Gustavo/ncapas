using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Capa_Entidad;
using Capa_Negocio;

namespace mvcCapas.Controllers
{
    public class TipoHabitacionController : Controller
    {
        // GET: TipoHabitacion
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult VistaPruebaInicio()
        {
            return View();
        }

        //[{"id":1,"nombre":"Simple","descripcion":"Solo para uno"},{"id":2,"nombre":"Doble","descripcion":"Solo para casados"}]
        public ActionResult Lista() {

            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.listarrTipoHabitacion(),JsonRequestBehavior.AllowGet);
        }
    }
}