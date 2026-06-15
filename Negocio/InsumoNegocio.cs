using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class InsumoNegocio
    {
        public List<Insumo> listar()
        {
            List<Insumo> lista = new List<Insumo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"SELECT I.Id, I.Nombre, I.Descripcion, I.Precio,I.Stock, I.IdCategoria, C.Descripcion AS CategoriaDescripcion FROM INSUMOS I INNER JOIN CATEGORIAS C ON C.Id = I.IdCategoria WHERE I.Activo = 1");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Insumo aux = new Insumo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Stock = (int)datos.Lector["Stock"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["CategoriaDescripcion"];

                   

                    lista.Add(aux);
                }

                return lista;
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

        public void agregarInsumo(Insumo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                

                if (existeInsumoConNombre(nuevo.Nombre))
                    throw new Exception("Ya existe un insumo con ese nombre.");


                datos.setearConsulta(@"INSERT INTO INSUMOS (Nombre, Descripcion,Precio,Stock,IdCategoria,Activo) VALUES (@Nombre, @Descripcion, @Precio, @Stock, @IdCategoria,@Activo)");

                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@Stock", nuevo.Stock);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@Activo", true);

                datos.ejecutarAccion();
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

        public void modificarInsumo(Insumo insumo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                if (existeInsumoConNombreParaEdicion(insumo.Nombre, insumo.Id))
                    throw new Exception("Ya existe otro insumo con ese nombre.");

                datos.setearConsulta(@"UPDATE INSUMOS SET  Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, Stock = @Stock, IdCategoria = @IdCategoria WHERE Id = @Id");

                datos.setearParametro("@Id", insumo.Id);
                datos.setearParametro("@Nombre", insumo.Nombre);
                datos.setearParametro("@Descripcion", insumo.Descripcion);
                datos.setearParametro("@Precio", insumo.Precio);
                datos.setearParametro("@Stock", insumo.Stock);
                datos.setearParametro("@IdCategoria", insumo.Categoria.Id);
                

                datos.ejecutarAccion();
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

        public void eliminarInsumo(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"UPDATE INSUMOS SET Activo = 0 WHERE Id = @Id");

                datos.setearParametro("@Id", id);
                
                datos.ejecutarAccion();
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

        public bool existeInsumoConNombre(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"SELECT COUNT(*) AS Cantidad FROM INSUMOS WHERE Nombre = @Nombre AND Activo = 1 ");

                datos.setearParametro("@Nombre", nombre);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int cantidad = (int)datos.Lector["Cantidad"];
                    return cantidad > 0;
                }

                return false;
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
        public bool existeInsumoConNombreParaEdicion(string nombre, int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"SELECT COUNT(*) AS Cantidad FROM INSUMOS WHERE Nombre = @Nombre AND Activo = 1 AND Id <> @Id");

                datos.setearParametro("@Nombre", nombre);
                datos.setearParametro("@Id", id);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int cantidad = (int)datos.Lector["Cantidad"];
                    return cantidad > 0;
                }

                return false;
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
