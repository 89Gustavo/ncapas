using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public  class CamaBL
    {
        public List<CamaCLS> listarCama()
        {
            CamalDAL oCamalDAL = new CamalDAL();
            return oCamalDAL.ListarCamas();
        }
        public List<CamaCLS> FiltrarCamas(string nombreCama)
        {
            CamalDAL oCamalDAL = new CamalDAL();
            return oCamalDAL.FiltrarCamas(nombreCama);
        }

    }
}
