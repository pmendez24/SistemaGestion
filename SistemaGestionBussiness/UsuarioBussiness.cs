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
    public static class UsuarioBussiness
    {
        public static UsuarioResponse CrearUsuario(Usuario usuario)
        {
            UsuarioResponse response = new UsuarioResponse();
            try 
            {
                if (!string.IsNullOrEmpty(usuario.Nombre) && !string.IsNullOrEmpty(usuario.Apellido) &&
                    !string.IsNullOrEmpty(usuario.Mail) && !string.IsNullOrEmpty(usuario.Contraseña) &&
                    !string.IsNullOrEmpty(usuario.NombreUsuario))
                {
                   return UsuarioData.CrearUsuario(usuario);
                }
                else
                {
                    if (string.IsNullOrEmpty(usuario.Nombre))
                    {
                        response.Mensaje = "El nombre no debe ser vacio.";
                    }
                    else if (string.IsNullOrEmpty(usuario.Apellido))
                    {
                        response.Mensaje = "El apellido no debe ser vacio.";
                    }
                    else if (string.IsNullOrEmpty(usuario.Mail))
                    {
                        response.Mensaje = "El mail no debe ser vacio.";
                    }
                    else if (string.IsNullOrEmpty(usuario.Contraseña))
                    {
                        response.Mensaje = "El contraseña no debe ser vacio.";
                    }
                    else if (string.IsNullOrEmpty(usuario.NombreUsuario))
                    {
                        response.Mensaje = "El nombreUsuario no debe ser vacio.";
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
        public static UsuarioResponse ModificarUsuario(Usuario usuario)
        {
            UsuarioResponse response = new UsuarioResponse();
            try
            {
                if (!string.IsNullOrEmpty(usuario.Nombre) && !string.IsNullOrEmpty(usuario.Apellido) &&
                    !string.IsNullOrEmpty(usuario.Mail) && !string.IsNullOrEmpty(usuario.Contraseña) &&
                    !string.IsNullOrEmpty(usuario.NombreUsuario))
                {
                    return UsuarioData.ModificarUsuario(usuario);
                }
                else
                {
                    if (string.IsNullOrEmpty(usuario.Nombre))
                    {
                        response.Mensaje = "El nombre no debe ser vacio.";
                    }
                    else if (string.IsNullOrEmpty(usuario.Apellido))
                    {
                        response.Mensaje = "El apellido no debe ser vacio.";
                    }
                    else if (string.IsNullOrEmpty(usuario.Mail))
                    {
                        response.Mensaje = "El mail no debe ser vacio.";
                    }
                    else if (string.IsNullOrEmpty(usuario.Contraseña))
                    {
                        response.Mensaje = "El contraseña no debe ser vacio.";
                    }
                    else if (string.IsNullOrEmpty(usuario.NombreUsuario))
                    {
                        response.Mensaje = "El nombreUsuario no debe ser vacio.";
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
        public static UsuarioResponse EliminarUsuario(Usuario usuario)
        {
           return UsuarioData.EliminarUsuario(usuario);
        }
        public static UsuarioResponse ListarUsuarios()
        {
            List<Usuario> usuarios;
            return UsuarioData.ListarUsuarios(out usuarios);
        }
        public static UsuarioResponse ObtenerUsuario(int IdUsuario)
        {
            Usuario usuario;
            return UsuarioData.ObtenerUsuario(IdUsuario, out usuario);
        }
    }
}
