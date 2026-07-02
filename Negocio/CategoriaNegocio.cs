using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM CATEGORIAS where Activo = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

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

        public void agregarCategoria(Categoria nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (existeCategoria(nueva.Descripcion))
                    throw new Exception("Ya existe una categoría con esa descripción.");
                datos.setearConsulta("INSERT INTO CATEGORIAS (Descripcion) VALUES (@Descripcion)");

                datos.setearParametro("@Descripcion", nueva.Descripcion);

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
        public void modificarCategoria(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (existeCategoriaParaEdicion(categoria.Descripcion, categoria.Id))
                    throw new Exception("Ya existe otra categoría con esa descripción.");

                datos.setearConsulta(@"UPDATE CATEGORIAS SET Descripcion = @Descripcion WHERE Id = @Id");

                datos.setearParametro("@Id", categoria.Id);
                datos.setearParametro("@Descripcion", categoria.Descripcion);

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
        public void EliminarCategoria(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                

                datos.setearConsulta(@"UPDATE CATEGORIAS SET Activo = 0 WHERE Id = @Id");

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

        public bool existeCategoria(string descripcion)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"SELECT COUNT(*) AS Cantidad FROM CATEGORIAS WHERE Descripcion = @Descripcion and Activo = 1");

                datos.setearParametro("@Descripcion", descripcion);
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
        public bool existeCategoriaParaEdicion(string descripcion, int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT COUNT(*) AS Cantidad
            FROM CATEGORIAS
            WHERE UPPER(LTRIM(RTRIM(Descripcion))) = UPPER(LTRIM(RTRIM(@Descripcion)))
            AND Id <> @Id
             and Activo = 1
        ");

                datos.setearParametro("@Descripcion", descripcion);
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
