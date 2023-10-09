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
    public static class ProductoVendidoBussiness
    {
        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            ProductoVendidoData.CrearProductoVendido(productoVendido);
        }
        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            ProductoVendidoData.ModificarProductoVendido(productoVendido);
        }
        public static void EliminarProductoVendido(ProductoVendido productoVendido)
        {
            ProductoVendidoData.EliminarProductoVendido(productoVendido);
        }

        public static List<ProductoVendido> ListarProductoVendidos()
        {
            return ProductoVendidoData.ListaProductosVendiidos();
        }
        public static ProductoVendido ObtenerProductoVendido(int IdProductoVendido)
        {
            return ProductoVendidoData.ObtenerProductoVendido(IdProductoVendido);
        }
    }
}
