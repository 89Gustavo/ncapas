using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

using Capa_Entidad;

namespace Capa_Datos
{
    public class TipoHabitacionDAL
    {
        /*        public List<TipoHabitacionCLS> listarrTipoHabitacion(){

                    List<TipoHabitacionCLS> lista = new List<TipoHabitacionCLS>();


                    lista.Add(new TipoHabitacionCLS
                    {
                        id = 1,
                        nombre= "Simple",
                        descripcion= "Solo para uno"

                    });
                    lista.Add(new TipoHabitacionCLS
                    {
                        id = 2,
                        nombre = "Doble",
                        descripcion = "Solo para casados"

                    });


                    return lista;
                }*/

        public List<TipoHabitacionCLS> listarrTipoHabitacion()
        {
            List<TipoHabitacionCLS> lista = null;
            string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena)) 
            {

                try
                {
                    cn.Open();
                    
                    
                    using (SqlCommand cmd = new SqlCommand("uspListarTipoHabitacion", cn)) { 
                       // buena practica indicar que prcedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        SqlDataReader drd = cmd.ExecuteReader();
                        TipoHabitacionCLS oTipoHabitacionCLS;
                       
                        if (drd != null) {
                            lista = new List<TipoHabitacionCLS>();
                            while (drd.Read()) {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id=drd.GetInt32(0);
                                oTipoHabitacionCLS.nombre = drd.GetString(1);
                                oTipoHabitacionCLS.descripcion = drd.GetString(2);

                                lista.Add(oTipoHabitacionCLS);
                            }
                        }
                    }


                    cn.Close();
                }
                catch(Exception ex) {
                    cn.Close();
                }
            }

                return lista;
        }
    }
}
