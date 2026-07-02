using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PedidoNegocio
    {
        public Pedido buscarPorId(int idPedido)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT Id, IdMesa, IdUsuario, FechaApertura, FechaCierre, Activo
            FROM PEDIDOS
            WHERE Id = @idPedido
        ");

                datos.setearParametro("@idPedido", idPedido);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Pedido aux = new Pedido();

                    aux.Id = (int)datos.Lector["Id"];

                    aux.Mesa = new Mesa();
                    aux.Mesa.Id = (int)datos.Lector["IdMesa"];

                    aux.Usuario = new Usuario();
                    aux.Usuario.Id = (int)datos.Lector["IdUsuario"];

                    aux.FechaApertura = (DateTime)datos.Lector["FechaApertura"];

                    if (!(datos.Lector["FechaCierre"] is DBNull))
                        aux.FechaCierre = (DateTime)datos.Lector["FechaCierre"];

                    aux.Activo = (bool)datos.Lector["Activo"];

                    return aux;
                }

                return null;
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
        public int abrirPedido(int idMesa, int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                INSERT INTO PEDIDOS 
                (
                    IdMesa, 
                    IdUsuario, 
                    FechaApertura, 
                    FechaCierre, 
                    Activo
                )
                OUTPUT INSERTED.Id
                VALUES 
                (
                    @idMesa, 
                    @idUsuario, 
                    GETDATE(), 
                    NULL, 
                    1
                )
            ");

                datos.setearParametro("@idMesa", idMesa);
                datos.setearParametro("@idUsuario", idUsuario);

                return datos.ejecutarAccionScalar();
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

        public void cerrarPedido(int idPedido)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                UPDATE PEDIDOS
                SET 
                    FechaCierre = GETDATE(),
                    Activo = 0
                WHERE Id = @idPedido
                  AND Activo = 1
            ");

                datos.setearParametro("@idPedido", idPedido);
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
        public int buscarPedidoActivoPorMesa(int idMesa)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT ISNULL((
                SELECT TOP 1 Id
                FROM PEDIDOS
                WHERE IdMesa = @idMesa
                  AND Activo = 1
                  AND FechaCierre IS NULL
                ORDER BY FechaApertura DESC, Id DESC
            ), 0)
        ");

                datos.setearParametro("@idMesa", idMesa);

                return datos.ejecutarAccionScalar();
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
        public List<Pedido> listarPedidos()
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT 
                P.Id,
                P.FechaApertura,
                P.FechaCierre,
                P.Activo,

                M.Id AS IdMesa,
                M.Numero AS NumeroMesa,

                U.Id AS IdUsuario,
                U.Nombre AS NombreUsuario,
                U.Apellido AS ApellidoUsuario
            FROM PEDIDOS P
            INNER JOIN MESAS M ON M.Id = P.IdMesa
            INNER JOIN USUARIOS U ON U.Id = P.IdUsuario
            ORDER BY P.FechaApertura DESC
        ");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pedido aux = new Pedido();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.FechaApertura = (DateTime)datos.Lector["FechaApertura"];

                    if (datos.Lector["FechaCierre"] != DBNull.Value)
                        aux.FechaCierre = (DateTime)datos.Lector["FechaCierre"];

                    aux.Activo = (bool)datos.Lector["Activo"];

                    aux.Mesa = new Mesa();
                    aux.Mesa.Id = (int)datos.Lector["IdMesa"];
                    aux.Mesa.Numero = (int)datos.Lector["NumeroMesa"];

                    aux.Usuario = new Usuario();
                    aux.Usuario.Id = (int)datos.Lector["IdUsuario"];
                    aux.Usuario.Nombre = datos.Lector["NombreUsuario"].ToString();
                    aux.Usuario.Apellido = datos.Lector["ApellidoUsuario"].ToString();

                    lista.Add(aux);
                }

                return lista;
            }
            catch
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Pedido> listarPedidos(int idMesero)
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
    SELECT 
        P.Id,
        P.IdMesa,
        M.Numero AS NumeroMesa,
        P.IdUsuario,
        U.Nombre AS NombreMesero,
        U.Apellido AS ApellidoMesero,
        P.FechaApertura,
        P.FechaCierre,
        P.Activo
    FROM PEDIDOS P
    INNER JOIN MESAS M ON M.Id = P.IdMesa
    INNER JOIN USUARIOS U ON U.Id = P.IdUsuario
    WHERE P.IdUsuario = @idUsuario
    ORDER BY P.FechaApertura DESC
");

                datos.setearParametro("@idUsuario", idMesero);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pedido aux = new Pedido();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.FechaApertura = (DateTime)datos.Lector["FechaApertura"];

                    if (datos.Lector["FechaCierre"] != DBNull.Value)
                        aux.FechaCierre = (DateTime)datos.Lector["FechaCierre"];

                    aux.Activo = (bool)datos.Lector["Activo"];

                    aux.Mesa = new Mesa();
                    aux.Mesa.Id = (int)datos.Lector["IdMesa"];
                    aux.Mesa.Numero = (int)datos.Lector["NumeroMesa"];

                    aux.Usuario = new Usuario();
                    aux.Usuario.Id = (int)datos.Lector["IdUsuario"];
                    aux.Usuario.Nombre = datos.Lector["NombreUsuario"].ToString();
                    aux.Usuario.Apellido = datos.Lector["ApellidoUsuario"].ToString();

                    lista.Add(aux);
                }

                return lista;
            }
            catch
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
