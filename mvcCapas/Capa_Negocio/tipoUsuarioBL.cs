using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class tipoUsuarioBL
    {
        public List<tipoUsuairoCLS> listarTipoUsuario(){
            tipoUsuarioDAL oTipoUsuarioDAL = new tipoUsuarioDAL();
            return oTipoUsuarioDAL.listarTipoUsuario();
        }
        public List<tipoUsuairoCLS> FiltrarTipoUsuario(string tipoUsuario) {
            tipoUsuarioDAL oTipoUsuarioDAL = new tipoUsuarioDAL();
            return oTipoUsuarioDAL.FiltrarTipoUsuario(tipoUsuario);
        }
    }
}
