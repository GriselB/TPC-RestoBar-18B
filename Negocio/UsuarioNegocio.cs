using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar(int id = 0)
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = @"SELECT U.Id, U.NombreUsuario, U.Pass, U.Nombre, U.Apellido, U.Activo,
                                            R.Id AS IdRol, R.Descripcion AS RolDescripcion
                                     FROM USUARIOS U
                                     INNER JOIN ROLES R ON R.Id = U.IdRol
                                     WHERE U.Activo = 1";

                if (id > 0)
                    consulta += " AND U.Id = @Id";

                datos.setearConsulta(consulta);

                if (id > 0)
                    datos.setearParametro("@Id", id);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.NombreUsuario = (string)datos.Lector["NombreUsuario"];
                    aux.Pass = (string)datos.Lector["Pass"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Activo = bool.Parse(datos.Lector["Activo"].ToString());

                    aux.Rol = new Rol();
                    aux.Rol.Id = (int)datos.Lector["IdRol"];
                    aux.Rol.Descripcion = (string)datos.Lector["RolDescripcion"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
                //Va a ser necesario generar el Error.aspx que nos quedó pendiente, para que pueda devolver la excepción en caso de que falle
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregarUsuario(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (existeNombreUsuario(nuevo.NombreUsuario))
                    throw new Exception("Ya existe un usuario con ese nombre de usuario.");
                datos.setearConsulta(@"INSERT INTO USUARIOS (NombreUsuario, Pass, Nombre, Apellido, IdRol, Activo) 
                                VALUES (@NombreUsuario, @Pass, @Nombre, @Apellido, @IdRol, @Activo)");

                datos.setearParametro("@NombreUsuario", nuevo.NombreUsuario);
                datos.setearParametro("@Pass", nuevo.Pass);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@IdRol", nuevo.Rol.Id);
                datos.setearParametro("@Activo", true);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
                //Va a ser necesario generar el Error.aspx que nos quedó pendiente, para que pueda devolver la excepción en caso de que falle
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (existeNombreUsuario(usuario.NombreUsuario, usuario.Id))
                    throw new Exception("Ya existe otro usuario con ese nombre de usuario.");

                datos.setearConsulta(@"UPDATE USUARIOS SET NombreUsuario = @NombreUsuario, Pass = @Pass, 
                        Nombre = @Nombre, Apellido = @Apellido, IdRol = @IdRol WHERE Id = @Id");

                datos.setearParametro("@NombreUsuario", usuario.NombreUsuario);
                datos.setearParametro("@Pass", usuario.Pass);
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@IdRol", usuario.Rol.Id);
                datos.setearParametro("@Id", usuario.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool existeNombreUsuario(string nombreUsuario, int idExiste = 0)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = @"SELECT COUNT(*) AS Cantidad FROM USUARIOS WHERE NombreUsuario = @NombreUsuario AND Activo = 1";

                if (idExiste > 0)
                    consulta += " AND Id <> @Id";

                datos.setearConsulta(consulta);
                datos.setearParametro("@NombreUsuario", nombreUsuario);

                if (idExiste > 0)
                    datos.setearParametro("@Id", idExiste);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int cantidad = (int)datos.Lector["Cantidad"];
                    return cantidad > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}