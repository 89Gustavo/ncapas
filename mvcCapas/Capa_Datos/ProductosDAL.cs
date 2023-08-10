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
    public class ProductosDAL: CadenaDAL
    {
        public List<ProductosCLS> listarProductos()
        {
            List<ProductosCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {

                try
                {
                    cn.Open();


                    using (SqlCommand cmd = new SqlCommand("uspListarProductos", cn))
                    {
                        // buena practica indicar que prcedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();


                        if (drd != null)
                        {
                            lista = new List<ProductosCLS>();
                            ProductosCLS oProductosCLS;
                            int posId = drd.GetOrdinal("IIDPRODUCTO");
                            int posNombreProducto = drd.GetOrdinal("NOMBRE");
                            int posNombreMarca = drd.GetOrdinal("NOMBREMARCA");
                            int posPrecio= drd.GetOrdinal("PRECIOVENTA");
                            int posStock = drd.GetOrdinal("STOCK");
                            while (drd.Read())
                            {
                                oProductosCLS = new ProductosCLS();
                                oProductosCLS.idProducto = drd.IsDBNull(posId) ? 0 :  drd.GetInt32(posId);
                                oProductosCLS.nombreProducto = drd.IsDBNull(posNombreProducto) ? "" :  drd.GetString(posNombreProducto);
                                oProductosCLS.nombreMarca = drd.IsDBNull(posNombreMarca) ? "" : drd.GetString(posNombreMarca);
                                oProductosCLS.precioVente = drd.IsDBNull(posPrecio) ? 0 : drd.GetDecimal(posPrecio);
                                oProductosCLS.stock = drd.IsDBNull(posPrecio) ? 0 : drd.GetDecimal(posPrecio);

                                oProductosCLS.denominacion = 
                                    drd.IsDBNull(posStock) ?"":
                                    (drd.GetDecimal(posPrecio)> 50 ?"Alto":"Bajo");
                                lista.Add(oProductosCLS);
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

        public List<ProductosCLS> FiltrarProductos(string nombreProducto)
        {
            List<ProductosCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {

                try
                {
                    cn.Open();


                    using (SqlCommand cmd = new SqlCommand("uspFiltrarProductos", cn))
                    {
                        // buena practica indicar que prcedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", nombreProducto);
                        SqlDataReader drd = cmd.ExecuteReader();


                        if (drd != null)
                        {
                            lista = new List<ProductosCLS>();
                            ProductosCLS oProductosCLS;
                            int posId = drd.GetOrdinal("IIDPRODUCTO");
                            int posNombreProducto = drd.GetOrdinal("NOMBRE");
                            int posNombreMarca = drd.GetOrdinal("NOMBREMARCA");
                            int posPrecio = drd.GetOrdinal("PRECIOVENTA");
                            int posStock = drd.GetOrdinal("STOCK");
                            while (drd.Read())
                            {
                                oProductosCLS = new ProductosCLS();
                                oProductosCLS.idProducto = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oProductosCLS.nombreProducto = drd.IsDBNull(posNombreProducto) ? "" : drd.GetString(posNombreProducto);
                                oProductosCLS.nombreMarca = drd.IsDBNull(posNombreMarca) ? "" : drd.GetString(posNombreMarca);
                                oProductosCLS.precioVente = drd.IsDBNull(posPrecio) ? 0 : drd.GetDecimal(posPrecio);
                                oProductosCLS.stock = drd.IsDBNull(posPrecio) ? 0 : drd.GetDecimal(posPrecio);

                                oProductosCLS.denominacion =
                                    drd.IsDBNull(posStock) ? "" :
                                    (drd.GetDecimal(posPrecio) > 50 ? "Alto" : "Bajo");
                                lista.Add(oProductosCLS);
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
