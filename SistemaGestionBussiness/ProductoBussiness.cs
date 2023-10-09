using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionEntities;
using SistemaGestionData;
using SistemaGestion;
using SistemaGestionEntities.Responses;

namespace SistemaGestionBussiness
{
    public static class ProductoBussiness
    {
        public static ProductoResponse CrearProducto(Producto producto)
        {
            ProductoResponse response = new ProductoResponse();
            try 
            {
                if (!string.IsNullOrEmpty(producto.Descripciones) && producto.Stock > 0 && producto.Costo > 0 && producto.PrecioVenta > 0)
                {
                    return ProductoData.CrearProducto(producto);
                }
                else
                {
                    if (string.IsNullOrEmpty(producto.Descripciones))
                    {
                        response.Mensaje = "La descripcion no debe ser vacia.";
                    }
                    else if (producto.Stock <= 0)
                    {
                        response.Mensaje = "El stock del producto debe ser mayor que 0.";
                    }
                    else if (producto.Costo <= 0)
                    {
                        response.Mensaje = "El costo del producto debe ser mayor que 0.";
                    }
                    else if (producto.PrecioVenta <= 0)
                    {
                        response.Mensaje = "El precio de venta del producto debe ser mayor que 0.";
                    }

                    return response;
                }
               
            }
            catch (Exception ex)
            {

                response.Mensaje = ex.Message;
                return response;
            }
        }
        public static ProductoResponse ModificarProducto(Producto producto)
        {
            ProductoResponse response = new ProductoResponse();
            try 
            {
                if (!string.IsNullOrEmpty(producto.Descripciones) && producto.Stock > 0 && producto.Costo > 0 && producto.PrecioVenta > 0)
                {
                    return ProductoData.ModificarProducto(producto);
                }
                else
                {
                    if (string.IsNullOrEmpty(producto.Descripciones))
                    {
                        response.Mensaje = "La descripcion no debe ser vacia.";
                    }
                    else if (producto.Stock <= 0)
                    {
                        response.Mensaje = "El stock del producto debe ser mayor que 0.";
                    }
                    else if (producto.Costo <= 0)
                    {
                        response.Mensaje = "El costo del producto debe ser mayor que 0.";
                    }
                    else if (producto.PrecioVenta <= 0)
                    {
                        response.Mensaje = "El precio de venta del producto debe ser mayor que 0.";
                    }

                    return response;
                }
            }
            catch (Exception ex)
            {

                response.Mensaje = ex.Message;
                return response;
            }

        }
        public static ProductoResponse EliminarProducto(Producto producto)
        {
            return ProductoData.EliminarProducto(producto);
        }
        public static ProductoResponse ListaProductos()
        {
            List<Producto> productos;
            return ProductoData.ListaProductos(out productos);
        }
        public static ProductoResponse  ObtenerProducto(int IdProducto)
        {
            Producto producto;
            return ProductoData.ObtenerProducto(IdProducto, out producto);
        }
    }
}
