using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public Mesa Mesa { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime? FechaCierre { get; set; }
        public bool Activo { get; set; }
    }
}
