using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities.Responses
{
    public class VentaResponse
    {
        public List<Venta> Ventas { get; set; }
        public Venta Venta { get; set; }
        public string Mensaje { get; set; }
        public Exception Error { get; set; }
    }
}
