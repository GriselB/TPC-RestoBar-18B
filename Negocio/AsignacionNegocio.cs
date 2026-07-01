using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class AsignacionNegocio
    {
        public List<Asignacion> listarVigentes()
        {
            List<Asignacion> lista = new List<Asignacion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"SELECT M.Id AS IdMesa, M.Numero, M.Descripcion,
                                              A.Id AS IdAsignacion, A.IdUsuario,
                                              U.Nombre, U.Apellido
                                       FROM MESAS M
                                       LEFT JOIN ASIGNACIONES A ON A.IdMesa = M.Id 
                                            AND A.FechaCierre IS NULL 
                                            AND A.Activo = 1
                                       LEFT JOIN USUARIOS U ON U.Id = A.IdUsuario
                                       WHERE M.Activo = 1");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Asignacion aux = new Asignacion();

                    aux.Mesa = new Mesa();
                    aux.Mesa.Id = (int)datos.Lector["IdMesa"];
                    aux.Mesa.Numero = (int)datos.Lector["Numero"];
                    aux.Mesa.Descripcion = datos.Lector["Descripcion"] is DBNull ? "" : (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["IdAsignacion"] is DBNull))
                    {
                        aux.Id = (int)datos.Lector["IdAsignacion"];
                        aux.Usuario = new Usuario();
                        aux.Usuario.Id = (int)datos.Lector["IdUsuario"];
                        aux.Usuario.Nombre = (string)datos.Lector["Nombre"];
                        aux.Usuario.Apellido = (string)datos.Lector["Apellido"];
                    }

                    lista.Add(aux);
                }
                return lista;
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

        public void asignar(int idMesa, int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"UPDATE ASIGNACIONES SET FechaCierre = @FechaCierre, Activo = 0
                                       WHERE IdMesa = @IdMesa 
                                       AND FechaCierre IS NULL 
                                       AND Activo = 1");

                datos.setearParametro("@FechaCierre", DateTime.Now);
                datos.setearParametro("@IdMesa", idMesa);
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

            AccesoDatos datos2 = new AccesoDatos();

            try
            {
                datos2.setearConsulta(@"INSERT INTO ASIGNACIONES (IdMesa, IdUsuario, FechaAsignacion, Activo)
                                        VALUES (@IdMesa, @IdUsuario, @FechaAsignacion, 1)");

                datos2.setearParametro("@IdMesa", idMesa);
                datos2.setearParametro("@IdUsuario", idUsuario);
                datos2.setearParametro("@FechaAsignacion", DateTime.Now);
                datos2.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos2.cerrarConexion();
            }
        }

        public void QuitarAsignacion(int idMesa)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"UPDATE ASIGNACIONES SET FechaCierre = @FechaCierre, Activo = 0
                               WHERE IdMesa = @IdMesa 
                               AND FechaCierre IS NULL 
                               AND Activo = 1");

                datos.setearParametro("@FechaCierre", DateTime.Now);
                datos.setearParametro("@IdMesa", idMesa);
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
    }
}