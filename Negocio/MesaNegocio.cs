using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MesaNegocio
    {
        public List<Mesa> listar(int id = 0)
        {
            List<Mesa> lista = new List<Mesa>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT Id, Numero, Descripcion, Activo FROM MESAS";

                if (id > 0)
                    consulta += " WHERE Id = @Id";

                datos.setearConsulta(consulta);

                if (id > 0)
                    datos.setearParametro("@Id", id);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mesa aux = new Mesa();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = (int)datos.Lector["Numero"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Activo = bool.Parse(datos.Lector["Activo"].ToString());
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

        public void agregarMesa(Mesa nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (existeNumeroMesa(nueva.Numero))
                    throw new Exception("Ya existe una mesa con ese número.");

                datos.setearConsulta("INSERT INTO MESAS (Numero, Descripcion, Activo) VALUES (@Numero, @Descripcion, @Activo)");
                datos.setearParametro("@Numero", nueva.Numero);
                datos.setearParametro("@Descripcion", nueva.Descripcion);
                datos.setearParametro("@Activo", true);
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

        public void modificarMesa(Mesa mesa)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (existeNumeroMesa(mesa.Numero, mesa.Id))
                    throw new Exception("Ya existe una mesa con ese número.");

                datos.setearConsulta("UPDATE MESAS SET Numero = @Numero, Descripcion = @Descripcion, Activo = @Activo WHERE Id = @Id");
                datos.setearParametro("@Numero", mesa.Numero);
                datos.setearParametro("@Descripcion", mesa.Descripcion);
                datos.setearParametro("@Activo", mesa.Activo);
                datos.setearParametro("@Id", mesa.Id);
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

        public bool existeNumeroMesa(int numero, int idExiste = 0)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT COUNT(*) AS Cantidad FROM MESAS WHERE Numero = @Numero";

                if (idExiste > 0)
                    consulta += " AND Id <> @Id";

                datos.setearConsulta(consulta);
                datos.setearParametro("@Numero", numero);

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
        public bool mesaTienePedidoActivo(int idMesa)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                SELECT COUNT(*)
                FROM PEDIDOS
                WHERE IdMesa = @idMesa
                  AND Activo = 1
                  AND FechaCierre IS NULL
            ");

                datos.setearParametro("@idMesa", idMesa);

                int cantidad = datos.ejecutarAccionScalar();

                return cantidad > 0;
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
        public List<Mesa> listarMesasPorUsuario(int idUsuario)
        {
            List<Mesa> lista = new List<Mesa>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                    SELECT DISTINCT
                        M.Id,
                        M.Numero,
                        M.Descripcion,
                        M.Activo
                    FROM MESAS M
                    INNER JOIN ASIGNACIONES A ON A.IdMesa = M.Id
                    WHERE A.IdUsuario = @idUsuario
                    AND A.Activo = 1
                    AND A.FechaCierre IS NULL
                    AND M.Activo = 1
                    ORDER BY M.Numero
                ");

                datos.setearParametro("@idUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mesa aux = new Mesa();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = (int)datos.Lector["Numero"];
                    aux.Descripcion = datos.Lector["Descripcion"] != DBNull.Value ? (string)datos.Lector["Descripcion"] : "";
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

    }
}
