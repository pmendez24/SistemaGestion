using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;
namespace SistemaGestion
{
    public class ProductoVendidoData
    {
        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = "INSERT INTO ProductoVendido  (Stock, IdProducto, IdVenta)" +
                "VALUES(@Stock, @IdProducto, @IdVenta);";

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Decimal) { Value = productoVendido.Stock });
                        comando.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt) { Value = productoVendido.Id });

                        comando.ExecuteNonQuery();

                    }

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = " UPDATE ProductoVendido " +
                           " SET Stock = @Stock, IdProducto = @IdProducto,  IdVenta = @IdVenta" +
                           " WHERE Id = @Id";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = productoVendido.IdProductoVendido });
                        comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Decimal) { Value = productoVendido.Stock });
                        comando.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt) { Value = productoVendido.Id });
                        comando.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.BigInt) { Value = productoVendido.IdVenta });

                        comando.ExecuteNonQuery();

                    }

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void EliminarProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = "DELETE FROM ProductoVendido WHERE Id = @Id ";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = productoVendido.IdProductoVendido });

                        comando.ExecuteNonQuery();

                    }

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static List<ProductoVendido> ListaProductosVendiidos()
        {
            List<ProductoVendido> lista = new List<ProductoVendido>();
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido ";

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
                                    var productoVendido = new ProductoVendido();
                                    productoVendido.IdProductoVendido = Convert.ToInt32(dr["Id"]);
                                    productoVendido.Stock = Convert.ToInt32(dr["Stock"]);
                                    productoVendido.Id = Convert.ToInt32(dr["IdProducto"]);
                                    productoVendido.IdVenta = Convert.ToInt32(dr["IdVenta"]);
                                    lista.Add(productoVendido);
                                }
                            }
                        }
                    }

                    conexion.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static ProductoVendido ObtenerProductoVendido( int IdProductoVendido) 
        {
            ProductoVendido productoVendidoObtenido = new ProductoVendido();
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = " SELECT Id, Stock, IdProducto, IdUsuario " +
                           " FROM ProductoVendido " +
                           " WHERE IdProductoVendido = @IdProductoVendido ";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        var parametro = new SqlParameter();
                        parametro.ParameterName = "IdProductoVendido";
                        parametro.SqlDbType = SqlDbType.Int;
                        parametro.Value = IdProductoVendido;

                        comando.Parameters.Add(parametro);

                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    productoVendidoObtenido.IdProductoVendido = Convert.ToInt32(dr["IdProductoVendido"]);
                                    productoVendidoObtenido.Stock = Convert.ToInt32(dr["Stock"]);
                                    productoVendidoObtenido.Id = Convert.ToInt32(dr["IdVenta"]);
                                    productoVendidoObtenido.IdVenta = Convert.ToInt32(dr["IdVenta"]);


                                }
                            }
                        }
                    }

                    conexion.Close();
                }
                return productoVendidoObtenido;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

