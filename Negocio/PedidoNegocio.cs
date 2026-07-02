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

    }
}
