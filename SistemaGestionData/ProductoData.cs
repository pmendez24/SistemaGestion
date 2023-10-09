using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SistemaGestionEntities;
using SistemaGestionEntities.Responses;

namespace SistemaGestionData
{
    public static class ProductoData
    {
        public static ProductoResponse CrearProducto(Producto producto)
        {
            ProductoResponse response = new ProductoResponse();
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = "INSERT INTO Producto  (Descripciones, Costo, PrecioVenta, Stock, IdUsuario)" +
                "VALUES(@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario);";

            try
            {
                using SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripciones });
                    comando.Parameters.Add(new SqlParameter("Costo", SqlDbType.Decimal) { Value = producto.Costo });
                    comando.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Decimal) { Value = producto.PrecioVenta });
                    comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Decimal) { Value = producto.Stock });
                    comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = producto.IdUsuario });

                    comando.ExecuteNonQuery();

                }

                conexion.Close();
                response.Mensaje = "OK";
                return response; 
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
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = " UPDATE Producto " +
                           " SET Descripciones = @Descripciones, Costo = @Costo, PrecioVenta = @PrecioVenta, Stock = @Stock, IdUsuario = @IdUsuario " +
                           " WHERE Id = @Id";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = producto.Id });
                        comando.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripciones });
                        comando.Parameters.Add(new SqlParameter("Costo", SqlDbType.Decimal) { Value = producto.Costo });
                        comando.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Decimal) { Value = producto.PrecioVenta });
                        comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Decimal) { Value = producto.Stock });
                        comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = producto.IdUsuario });

                        comando.ExecuteNonQuery();

                    }

                    conexion.Close();
                    response.Mensaje = "OK";
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
            ProductoResponse response = new ProductoResponse();
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = "DELETE FROM Producto WHERE Id = @Id ";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = producto.Id });

                        comando.ExecuteNonQuery();

                    }

                    conexion.Close();
                    response.Mensaje = "OK";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
                return response;
            }
        }
        public static ProductoResponse ListaProductos(out List<Producto> productos)
        {
            ProductoResponse response = new ProductoResponse();
            productos  = new List<Producto>();
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto ";
            
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    var producto = new Producto();
                                    producto.Id = Convert.ToInt32(dr["Id"]);
                                    producto.Descripciones = dr["Descripciones"].ToString();
                                    producto.Costo = Convert.ToDecimal(dr["Costo"]);
                                    producto.PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]);
                                    producto.Stock = Convert.ToInt32(dr["Stock"]);
                                    producto.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);

                                    productos.Add(producto);
                                }
                            }
                        }
                    }

                    conexion.Close();
                }
                response.Productos = productos;
                response.Mensaje = "OK";
                
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
               
            }
            return response;
        }
        public static ProductoResponse ObtenerProducto(int IdProducto, out Producto productoObtenido) 
        {
            ProductoResponse response = new ProductoResponse();
            productoObtenido = new Producto();
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = " SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario " +
                           " FROM Producto " +
                           " WHERE Id = @IdProducto ";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        var parametro = new SqlParameter();
                        parametro.ParameterName = "IdProducto";
                        parametro.SqlDbType = SqlDbType.Int;
                        parametro.Value = IdProducto;

                        comando.Parameters.Add(parametro);

                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    productoObtenido.Id = Convert.ToInt32(dr["Id"]);
                                    productoObtenido.Descripciones = dr["Descripciones"].ToString();
                                    productoObtenido.Costo = Convert.ToDecimal(dr["Costo"]);
                                    productoObtenido.PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]);
                                    productoObtenido.Stock = Convert.ToInt32(dr["Stock"]);
                                    productoObtenido.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);


                                }
                            }
                        }
                    }

                    conexion.Close();
                }
                response.Producto = productoObtenido;
                response.Mensaje = "OK";
              
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }

            return response;
        }
    }
}
