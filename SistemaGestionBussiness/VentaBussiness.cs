using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionEntities;
using SistemaGestionData;
using SistemaGestion;

namespace SistemaGestionBussiness
{
    public static class VentaBussiness
    {
        public static void CrearVenta(Venta venta)
        {
            VentaData.CrearVenta(venta);
        }
        public static void ModificarVenta(Venta venta)
        {
            VentaData.ModificarVenta(venta);
        }
        public static void EliminarVenta(Venta venta)
        {
            VentaData.EliminarVenta(venta);
        }

        public static List<Venta> ListarVentas()
        {
            return VentaData.ListarVentas();
        }
        public static Venta ObtenerVenta(int IdVenta)
        {
            return VentaData.ObtenerVenta(IdVenta);
        }
    }
}
