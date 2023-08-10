using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Entidad;
using Capa_Negocio;


namespace mvcCapas.Controllers
{
    public class CamaController : Controller
    {
        // GET: Cama
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listarCama() {
            CamaBL oCamaBL = new CamaBL();
            return Json(oCamaBL.listarCama(), JsonRequestBehavior.AllowGet);
        }
        //simular
        /*  public string busqueda(string nombreCama) {
              return nombreCama;
          }*/

        public JsonResult filtrarCama(string nombreCama)
        {
            CamaBL oCamaBL = new CamaBL();
            return Json(oCamaBL.FiltrarCamas(nombreCama), JsonRequestBehavior.AllowGet);
        }
    }
}