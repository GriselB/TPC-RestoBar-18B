using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Menu
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public string Modulo { get; set; }
        public bool Activo { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
