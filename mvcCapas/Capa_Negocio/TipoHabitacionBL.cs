﻿using System;
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
    }
}