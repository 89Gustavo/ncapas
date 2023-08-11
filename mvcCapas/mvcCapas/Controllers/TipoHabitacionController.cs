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

        public ActionResult Lista() {

            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.listarrTipoHabitacion(),JsonRequestBehavior.AllowGet);
        }
        public ActionResult filtrarTipoHabicionNombre( string nombreHabitacion)
        {

            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.filtraTipoHabitacionNombre(nombreHabitacion), JsonRequestBehavior.AllowGet);
        }

        public int guardarDatos(TipoHabitacionCLS oTipoHabitacionCLS)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return obj.guardarTipoHabitacion(oTipoHabitacionCLS);
        }

        public JsonResult recuperarTipoHabitacion(int id) {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json( obj.recuperarTipoHabitacion(id), JsonRequestBehavior.AllowGet);
        }
    }
}