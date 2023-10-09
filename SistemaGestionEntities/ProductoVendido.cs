using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class ProductoVendido : Producto
    {
        public int IdProductoVendido { get; set; }
        public int IdVenta { get; set; }
    }
}
