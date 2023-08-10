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
    public class tipoUsuarioDAL:CadenaDAL
    {
        public List<tipoUsuairoCLS> listarTipoUsuario()
        {
            List<tipoUsuairoCLS> lista = null;
            //string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {

                try
                {
                    cn.Open();


                    using (SqlCommand cmd = new SqlCommand("uspListarTipoUsuario", cn))
                    {
                        // buena practica indicar que prcedure
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataReader drd = cmd.ExecuteReader();
                        tipoUsuairoCLS oTipoUsuairoCLS;

                        if (drd != null)
                        {
                            lista = new List<tipoUsuairoCLS>();
                            while (drd.Read())
                            {
                                oTipoUsuairoCLS = new tipoUsuairoCLS();
                                oTipoUsuairoCLS.id = drd.GetInt32(0);
                                oTipoUsuairoCLS.nombre = drd.GetString(1);
                                oTipoUsuairoCLS.descripcion = drd.GetString(2);

                                lista.Add(oTipoUsuairoCLS);
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

        public List<tipoUsuairoCLS> FiltrarTipoUsuario(string tipoUsuario)
        {
            List<tipoUsuairoCLS> lista = null;
            //string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {

                try
                {
                    cn.Open();


                    using (SqlCommand cmd = new SqlCommand("uspFiltrarTipoUsuario", cn))
                    {
                        // buena practica indicar que prcedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);
                        SqlDataReader drd = cmd.ExecuteReader();
                        tipoUsuairoCLS oTipoUsuairoCLS;

                        if (drd != null)
                        {
                            lista = new List<tipoUsuairoCLS>();
                            while (drd.Read())
                            {
                                oTipoUsuairoCLS = new tipoUsuairoCLS();
                                oTipoUsuairoCLS.id = drd.GetInt32(0);
                                oTipoUsuairoCLS.nombre = drd.GetString(1);
                                oTipoUsuairoCLS.descripcion = drd.GetString(2);

                                lista.Add(oTipoUsuairoCLS);
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
    }
}
