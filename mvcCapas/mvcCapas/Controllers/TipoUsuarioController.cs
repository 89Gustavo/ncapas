using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Capa_Entidad;
using Capa_Negocio;

namespace mvcCapas.Controllers
{
    public class TipoUsuarioController : Controller
    {
        // GET: TipoUsuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaUsuarios()
        {

            tipoUsuarioBL obj = new tipoUsuarioBL();
            return Json(obj.listarTipoUsuario(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FiltrarUsuarios(string tipoUsuario)
        {

            tipoUsuarioBL obj = new tipoUsuarioBL();
            return Json(obj.FiltrarTipoUsuario(tipoUsuario), JsonRequestBehavior.AllowGet);
        }
    }
}