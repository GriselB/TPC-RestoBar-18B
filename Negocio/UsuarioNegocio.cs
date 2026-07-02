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
                                     INNER JOIN ROLES R ON R.Id = U.IdRol";

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
                datos.setearParametro("@Pass", "RestoBar!1234#");
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

                datos.setearConsulta(@"UPDATE USUARIOS SET NombreUsuario = @NombreUsuario, 
                        Nombre = @Nombre, Apellido = @Apellido, IdRol = @IdRol, Activo = @Activo WHERE Id = @Id");

                datos.setearParametro("@NombreUsuario", usuario.NombreUsuario);
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@IdRol", usuario.Rol.Id);
                datos.setearParametro("@Activo", usuario.Activo);
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

        public void resetearPassword(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE USUARIOS SET Pass = @Pass WHERE Id = @Id");
                datos.setearParametro("@Pass", "RestoBar!1234#");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
                //Va a ser necesario generar el Error.aspx que nos quedó pendiente
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Usuario login(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"SELECT U.Id, U.NombreUsuario, U.Nombre, U.Apellido, U.Activo,
                                        R.Id AS IdRol, R.Descripcion AS RolDescripcion
                                 FROM USUARIOS U
                                 INNER JOIN ROLES R ON R.Id = U.IdRol
                                 WHERE U.NombreUsuario = @NombreUsuario 
                                 AND U.Pass = @Pass");

                datos.setearParametro("@NombreUsuario", usuario.NombreUsuario);
                datos.setearParametro("@Pass", usuario.Pass);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    bool activo = bool.Parse(datos.Lector["Activo"].ToString());

                    if (!activo)
                        throw new Exception("El usuario se encuentra inactivo. Comuníquese con el administrador.");

                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.Nombre = (string)datos.Lector["Nombre"];
                    usuario.Apellido = (string)datos.Lector["Apellido"];
                    usuario.Activo = activo;

                    usuario.Rol = new Rol();
                    usuario.Rol.Id = (int)datos.Lector["IdRol"];
                    usuario.Rol.Descripcion = (string)datos.Lector["RolDescripcion"];

                    return usuario;
                }
                return null;
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

        public bool usuarioTieneAsignacionesOPedidosVigentes(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT
                (SELECT COUNT(*) FROM ASIGNACIONES WHERE IdUsuario = @IdUsuario AND FechaCierre IS NULL) +
                (SELECT COUNT(*) FROM PEDIDOS WHERE IdUsuario = @IdUsuario AND FechaCierre IS NULL)
        ");

                datos.setearParametro("@IdUsuario", idUsuario);

                int cantidad = datos.ejecutarAccionScalar();

                return cantidad > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}