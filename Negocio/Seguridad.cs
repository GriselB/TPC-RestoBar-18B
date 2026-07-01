using Dominio;
using static Dominio.Rol;

namespace Negocio
{
    public class Seguridad
    {
        public static bool sessionActiva(object usuario)
        {
            Usuario user = usuario != null ? (Usuario)usuario : null;
            if (user != null && user.Id != 0)
                return true;
            return false;
        }

        public static bool esGerente(object usuario)
        {
            Usuario user = usuario != null ? (Usuario)usuario : null;
            if (user != null && user.Id != 0 && user.Rol != null && user.Rol.Id == (int)RolEnum.Gerente)
                return true;
            return false;
        }

        public static bool esMesero(object usuario)
        {
            Usuario user = usuario != null ? (Usuario)usuario : null;
            if (user != null && user.Id != 0 && user.Rol != null && user.Rol.Id == (int)RolEnum.Mesero)
                return true;
            return false;
        }
    }
}