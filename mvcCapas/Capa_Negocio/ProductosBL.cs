using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Capa_Datos;
using Capa_Entidad;


namespace Capa_Negocio
{
    public class ProductosBL
    {
        public List<ProductosCLS> ListarProducto()
        {
            ProductosDAL oProductosDAL = new ProductosDAL();

            return oProductosDAL.listarProductos();
        }
        public List<ProductosCLS> FiltrarProductos(string nombreProducto)
        {
            ProductosDAL oProductosDAL = new ProductosDAL();

            return oProductosDAL.FiltrarProductos(nombreProducto);
        }
    }
}
