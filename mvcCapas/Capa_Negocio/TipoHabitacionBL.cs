using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class TipoHabitacionBL
    {
        public List<TipoHabitacionCLS> listarrTipoHabitacion()
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.listarrTipoHabitacion();
        }

        public List<TipoHabitacionCLS> filtraTipoHabitacionNombre(string nombreHabitacion)
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.filtrarTipoHabitacion(nombreHabitacion);
        }
        public int guardarTipoHabitacion(TipoHabitacionCLS oTipoHabitacion) {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.guardarTipoHabitacion(oTipoHabitacion);
        }

        public TipoHabitacionCLS recuperarTipoHabitacion(int id) {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.recuperarTipoHabitacion(id);

        }
        public int eliminarTipoHabitacion(int idTipoHabitacion) {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.eliminarTipoHabitacion(idTipoHabitacion);
        }
    }
}
