using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PedidoNegocio
    {
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

    }
}
