using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }

        public string NombreUsuario { get; set; }

        public string Pass { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public Rol Rol { get; set; }

        public  bool Activo { get; set; }
    }
}
