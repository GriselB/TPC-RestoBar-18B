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
                                     INNER JOIN ROLES R ON R.Id = U.IdRol
                                     WHERE U.Activo = 1";

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
    }
}