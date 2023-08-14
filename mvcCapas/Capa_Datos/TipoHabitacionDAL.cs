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
    public class TipoHabitacionDAL:CadenaDAL
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
           // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena)) 
            {

                try
                {
                    cn.Open();
                    
                    
                    using (SqlCommand cmd = new SqlCommand("uspListarTipoHabitacion", cn)) { 
                       // buena practica indicar que prcedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        SqlDataReader drd = cmd.ExecuteReader();
                        
                       
                        if (drd != null) {
                            lista = new List<TipoHabitacionCLS>();
                            TipoHabitacionCLS oTipoHabitacionCLS;
                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read()) {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id=drd.GetInt32(posId);
                                oTipoHabitacionCLS.nombre = drd.GetString(posNombre);
                                oTipoHabitacionCLS.descripcion = drd.GetString(posDescripcion);

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

        public List<TipoHabitacionCLS> filtrarTipoHabitacion(string nombreHabitacion)
        {
            List<TipoHabitacionCLS> lista = null;
            // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {

                try
                {
                    cn.Open();


                    using (SqlCommand cmd = new SqlCommand("uspFiltarTipoHabitacion", cn))
                    {
                        // buena practica indicar que prcedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombrehabitacion", nombreHabitacion);
                        SqlDataReader drd = cmd.ExecuteReader();


                        if (drd != null)
                        {
                            lista = new List<TipoHabitacionCLS>();
                            TipoHabitacionCLS oTipoHabitacionCLS;
                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.GetInt32(posId);
                                oTipoHabitacionCLS.nombre = drd.GetString(posNombre);
                                oTipoHabitacionCLS.descripcion = drd.GetString(posDescripcion);

                                lista.Add(oTipoHabitacionCLS);
                            }
                        }
                    }


                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }

            return lista;
        }
        public int guardarTipoHabitacion(TipoHabitacionCLS oTipoHabitacion)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardarTipohabitacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", oTipoHabitacion.id);
                        cmd.Parameters.AddWithValue("@nombre", oTipoHabitacion.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oTipoHabitacion.descripcion);
                        
                        rpta = cmd.ExecuteNonQuery();
                        cn.Close();

                    }
                    
                }
                catch (Exception ex)
                {
                    rpta = 0;
                    cn.Close();
                }
                return rpta;
            }
        }
        public TipoHabitacionCLS recuperarTipoHabitacion(int id)
        {
            TipoHabitacionCLS oTipoHabitacionCLS = null;
            // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {

                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspRecuperarTipoHabitacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                           
                            
                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.GetInt32(posId);
                                oTipoHabitacionCLS.nombre = drd.GetString(posNombre);
                                oTipoHabitacionCLS.descripcion = drd.GetString(posDescripcion);

                                
                            }
                        }
                    }


                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }

            return oTipoHabitacionCLS;
        }

        public int eliminarTipoHabitacion(int idTipoHabitacion )
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarTipoHabitacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", idTipoHabitacion);
                      

                        rpta = cmd.ExecuteNonQuery();
                        cn.Close();

                    }

                }
                catch (Exception ex)
                {
                    rpta = 0;
                    cn.Close();
                }
                return rpta;
            }
        }
    }
}
