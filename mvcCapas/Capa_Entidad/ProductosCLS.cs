using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class ProductosCLS
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public string nombreMarca { get; set; }
        public decimal precioVente { get; set; }
        public decimal stock { get; set; }
        public string denominacion { get; set; }
    }
}
