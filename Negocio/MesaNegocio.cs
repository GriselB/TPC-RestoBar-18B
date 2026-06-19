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
                string consulta = "SELECT Id, Numero, Descripcion, Activo FROM MESAS WHERE Activo = 1";

                if (id > 0)
                    consulta += " AND Id = @Id";

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
    }
}
