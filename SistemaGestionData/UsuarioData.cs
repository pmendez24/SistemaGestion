using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;
using SistemaGestionEntities.Responses;

namespace SistemaGestion
{
    public static class UsuarioData
    {
        public static UsuarioResponse CrearUsuario(Usuario usuario) 
        {
            UsuarioResponse response = new UsuarioResponse();
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = "INSERT INTO Usuario  (Nombre, Apellido, NombreUsuario, Contraseña, Mail)" +
                "VALUES(@Nombre, @Apellido, @NombreUsuario, @Contraseña, @Mail);";
            try 
            {
                using (SqlConnection conexion = new SqlConnection(connectionString)) 
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion)) 
                    {
                        comando.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre });
                        comando.Parameters.Add(new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.Apellido });
                        comando.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                        comando.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = usuario.Contraseña });
                        comando.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.Mail });

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
        public static UsuarioResponse ModificarUsuario(Usuario usuario)
        {
            UsuarioResponse response = new UsuarioResponse();
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = " UPDATE Usuario " +
                           " SET Nombre = @Nombre, Apellido = @Apellido, NombreUsuario = @NombreUsuario, Contraseña = @Contraseña, Mail = @Mail " +
                           " WHERE Id = @Id;";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = usuario.Id });
                        comando.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre });
                        comando.Parameters.Add(new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.Apellido });
                        comando.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                        comando.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = usuario.Contraseña });
                        comando.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.Mail });

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
        public static UsuarioResponse EliminarUsuario(Usuario usuario)
        {
            UsuarioResponse response = new UsuarioResponse();
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = "DELETE FROM Usuario WHERE Id = @Id ";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = usuario.Id });

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
        public static UsuarioResponse ListarUsuarios(out List<Usuario> usuarios)
        {
            UsuarioResponse response = new UsuarioResponse();
            usuarios = new List<Usuario>();
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario ";

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
                                    var usuario = new Usuario();
                                    usuario.Id = Convert.ToInt32(dr["Id"]);
                                    usuario.Nombre = dr["Nombre"].ToString();
                                    usuario.Apellido = dr["Apellido"].ToString();
                                    usuario.NombreUsuario = dr["NombreUsuario"].ToString();
                                    usuario.Contraseña = dr["Contraseña"].ToString();
                                    usuario.Mail = dr["Mail"].ToString();

                                    usuarios.Add(usuario);
                                }
                            }
                        }
                    }

                    conexion.Close();
                }
                response.Usuarios = usuarios;
                response.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return response;
        }
        public static UsuarioResponse ObtenerUsuario(int IdUsuario, out Usuario usuarioObtenido)
        {
            UsuarioResponse response = new UsuarioResponse();
            usuarioObtenido = new Usuario();
            string connectionString = @"Server=AV-AR-K4N0GR095;DataBase=SistemaGestion;Trusted_Connection=True";
            string query = " SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail " +
                           " FROM Usuario " +
                           " WHERE Id = @IdUsuario ";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        var parametro = new SqlParameter();
                        parametro.ParameterName = "IdUsuario";
                        parametro.SqlDbType = SqlDbType.Int;
                        parametro.Value = IdUsuario;

                        comando.Parameters.Add(parametro);

                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    usuarioObtenido.Id = Convert.ToInt32(dr["Id"]);
                                    usuarioObtenido.Nombre = dr["Nombre"].ToString();
                                    usuarioObtenido.Apellido = dr["Apellido"].ToString();
                                    usuarioObtenido.NombreUsuario = dr["NombreUsuario"].ToString();
                                    usuarioObtenido.Contraseña = dr["Contraseña"].ToString();
                                    usuarioObtenido.Mail = dr["Mail"].ToString();


                                }
                            }
                        }
                    }

                    conexion.Close();
                }
                response.Usuario = usuarioObtenido;
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
