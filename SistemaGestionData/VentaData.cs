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
    public static class VentaData
    {
        public static void CrearVenta(Venta venta)
        {
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = "INSERT INTO Venta  (Comentarios, IdUsuario)" +
                "VALUES(@Comentarios, @IdUsuario);";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.Comentarios });
                        comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int) { Value = venta.IdUsuario });
                       
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
        public static void ModificarVenta(Venta venta)
        {
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = " UPDATE Venta " + //, 
                           " SET Comentarios = @Comentarios, IdUsuario = @IdUsuario " +
                           " WHERE Id = @Id;";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = venta.Id });
                        comando.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.Comentarios });
                        comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int) { Value = venta.IdUsuario });
                        
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
        public static void EliminarVenta(Venta venta)
        {
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = "DELETE FROM Venta WHERE Id = @Id ";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = venta.Id });

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
        public static List<Venta> ListarVentas()
        {
            List<Venta> lista = new List<Venta>();
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = "SELECT Id, Comentarios, IdUsuario FROM Venta ";

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
                                    var venta = new Venta();
                                    venta.Id = Convert.ToInt32(dr["Id"]);
                                    venta.Comentarios = dr["Comentarios"].ToString();
                                    venta.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                                  
                                    lista.Add(venta);
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
        public static Venta ObtenerVenta(int IdVenta)
        {
            Venta ventaObtenido = new Venta();
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = " SELECT Id, Comentarios, IdUsuario " +
                           " FROM Venta " +
                           " WHERE Id = @IdVenta ";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        var parametro = new SqlParameter();
                        parametro.ParameterName = "IdVenta";
                        parametro.SqlDbType = SqlDbType.Int;
                        parametro.Value = IdVenta;

                        comando.Parameters.Add(parametro);

                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {

                                    ventaObtenido.Id = Convert.ToInt32(dr["Id"]);
                                    ventaObtenido.Comentarios = dr["Comentarios"].ToString();
                                    ventaObtenido.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);

                                }
                            }
                        }
                    }

                    conexion.Close();
                }
                return ventaObtenido;
            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}
