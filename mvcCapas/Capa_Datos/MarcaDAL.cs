using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using Capa_Entidad;

namespace Capa_Datos
{
   public class MarcaDAL:CadenaDAL
    {
        public List<MarcaCLS> ListarMarca() {
            List<MarcaCLS> listaMarca = null;
            using (SqlConnection cn = new SqlConnection(cadena)) {
                try {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarMarca", cn)) { 
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null) {
                            listaMarca = new List<MarcaCLS>();
                            MarcaCLS oMarcaCLS;

                            int posIdMarca = drd.GetOrdinal("IIDMARCA");
                            int posNombre = drd.GetOrdinal("NOMBREMARCA");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while(drd.Read()){
                                oMarcaCLS = new MarcaCLS();
                                oMarcaCLS.idMarca = drd.IsDBNull(posIdMarca) ? 0
                                    : drd.GetInt32(posIdMarca);
                                oMarcaCLS.nombre = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oMarcaCLS.descripcion = drd.IsDBNull(posDescripcion) ? ""
                                    : drd.GetString(posDescripcion);

                                listaMarca.Add(oMarcaCLS);
                            }
                        
                        }
                    }

                    cn.Close();

                }
                catch (Exception ex) {
                    cn.Close();
                }
            }

                return listaMarca;
        }
        public List<MarcaCLS> FiltrarMarca(string marca)
        {
            List<MarcaCLS> listaMarca = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarMarca", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", marca);
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            listaMarca = new List<MarcaCLS>();
                            MarcaCLS oMarcaCLS;

                            int posIdMarca = drd.GetOrdinal("IIDMARCA");
                            int posNombre = drd.GetOrdinal("NOMBREMARCA");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oMarcaCLS = new MarcaCLS();
                                oMarcaCLS.idMarca = drd.IsDBNull(posIdMarca) ? 0
                                    : drd.GetInt32(posIdMarca);
                                oMarcaCLS.nombre = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oMarcaCLS.descripcion = drd.IsDBNull(posDescripcion) ? ""
                                    : drd.GetString(posDescripcion);

                                listaMarca.Add(oMarcaCLS);
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

            return listaMarca;
        }
    }
}
