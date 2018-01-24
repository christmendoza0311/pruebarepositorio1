using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4._0Comunes;

namespace _4._3Ventas
{
    public class entCliente
    {
        public int idCliente { get; set; }
        public entPersona Persona { get; set; }
        public String Usuario { get; set; }
        public String Password { get; set; }
        public Boolean Activo { get; set; }
    }
}
