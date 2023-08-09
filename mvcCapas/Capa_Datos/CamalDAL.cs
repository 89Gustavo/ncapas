using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


using Capa_Entidad;


namespace Capa_Datos
{
    public class CamalDAL:CadenaDAL
    {
        public List<CamaCLS> ListarCamas()
        {
            List<CamaCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {

                try
                {
                    cn.Open();


                    using (SqlCommand cmd = new SqlCommand("uspListarCama", cn))
                    {
                        // buena practica indicar que prcedure
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataReader drd = cmd.ExecuteReader();


                        if (drd != null)
                        {
                            lista = new List<CamaCLS>();
                            CamaCLS oCamaCLS;
                            int posId = drd.GetOrdinal("IIDCAMA");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oCamaCLS = new CamaCLS();
                                oCamaCLS.idCama = drd.IsDBNull(posId) ? 0 
                                    :drd.GetInt32(posId);
                                oCamaCLS.nombre = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oCamaCLS.descripcion = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posDescripcion);

                                lista.Add(oCamaCLS);
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
