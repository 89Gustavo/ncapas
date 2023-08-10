using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class MarcaBL
    {
        public List<MarcaCLS> ListaMarca() {
            MarcaDAL oMarDAL = new MarcaDAL();

            return oMarDAL.ListarMarca();
        }
        public List<MarcaCLS> FiltrarMarca(string marca) {
            MarcaDAL oMarDAL = new MarcaDAL();

            return oMarDAL.FiltrarMarca(marca);
        }
    }
}
