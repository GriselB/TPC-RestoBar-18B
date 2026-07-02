using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DetallePedidoNegocio
    {
        public List<DetallePedido> listarPorPedido(int idPedido)
        {
            List<DetallePedido> lista = new List<DetallePedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                    SELECT 
                        DP.Id,
                        DP.IdPedido,
                        DP.IdInsumo,
                        DP.Cantidad,
                        DP.PrecioUnitario,
                        DP.Activo,
                        I.Nombre AS NombreInsumo,
                        I.Descripcion AS DescripcionInsumo,
                        I.Precio,
                        I.Stock
                    FROM DETALLE_PEDIDOS DP
                    INNER JOIN INSUMOS I ON I.Id = DP.IdInsumo
                    WHERE DP.Activo = 1
                    AND DP.IdPedido = @idPedido
                ");

                datos.setearParametro("@idPedido", idPedido);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DetallePedido aux = new DetallePedido();

                    aux.Id = (int)datos.Lector["Id"];

                    aux.Pedido = new Pedido();
                    aux.Pedido.Id = (int)datos.Lector["IdPedido"];

                    aux.Insumo = new Insumo();
                    aux.Insumo.Id = (int)datos.Lector["IdInsumo"];
                    aux.Insumo.Nombre = (string)datos.Lector["NombreInsumo"];
                    aux.Insumo.Descripcion = datos.Lector["DescripcionInsumo"] != DBNull.Value ? (string)datos.Lector["DescripcionInsumo"] : "";
                    aux.Insumo.Precio = (decimal)datos.Lector["Precio"];
                    aux.Insumo.Stock = (int)datos.Lector["Stock"];

                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"];
                    aux.Activo = (bool)datos.Lector["Activo"];

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

        public DetallePedido buscarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                    SELECT 
                        DP.Id,
                        DP.IdPedido,
                        DP.IdInsumo,
                        DP.Cantidad,
                        DP.PrecioUnitario,
                        DP.Activo,
                        I.Nombre AS NombreInsumo,
                        I.Descripcion AS DescripcionInsumo,
                        I.Precio,
                        I.Stock
                    FROM DETALLE_PEDIDOS DP
                    INNER JOIN INSUMOS I ON I.Id = DP.IdInsumo
                    WHERE DP.Id = @id
                ");

                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    DetallePedido aux = new DetallePedido();

                    aux.Id = (int)datos.Lector["Id"];

                    aux.Pedido = new Pedido();
                    aux.Pedido.Id = (int)datos.Lector["IdPedido"];

                    aux.Insumo = new Insumo();
                    aux.Insumo.Id = (int)datos.Lector["IdInsumo"];
                    aux.Insumo.Nombre = (string)datos.Lector["NombreInsumo"];
                    aux.Insumo.Descripcion = datos.Lector["DescripcionInsumo"] != DBNull.Value ? (string)datos.Lector["DescripcionInsumo"] : "";
                    aux.Insumo.Precio = (decimal)datos.Lector["Precio"];
                    aux.Insumo.Stock = (int)datos.Lector["Stock"];

                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"];
                    aux.Activo = (bool)datos.Lector["Activo"];

                    return aux;
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
        public void agregar(DetallePedido nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                    INSERT INTO DETALLE_PEDIDOS 
                    (
                        IdPedido, 
                        IdInsumo, 
                        Cantidad, 
                        PrecioUnitario, 
                        Activo
                    )
                    VALUES 
                    (
                        @idPedido, 
                        @idInsumo, 
                        @cantidad, 
                        @precioUnitario, 
                        1
                    )
                ");

                datos.setearParametro("@idPedido", nuevo.Pedido.Id);
                datos.setearParametro("@idInsumo", nuevo.Insumo.Id);
                datos.setearParametro("@cantidad", nuevo.Cantidad);
                datos.setearParametro("@precioUnitario", nuevo.PrecioUnitario);

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

        public void eliminarInsumoDeDetalle(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                    UPDATE DETALLE_PEDIDOS
                    SET Activo = 0
                    WHERE Id = @id
                ");

                datos.setearParametro("@id", id);
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
