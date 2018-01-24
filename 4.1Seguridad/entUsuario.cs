using _4._0Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1Seguridad
{
    public class entUsuario
    {
        public int idUsuario { get; set; }
        public entPersona Persona { get; set; }
        public DateTime FechaCreacion { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public Boolean Activo { get; set; }
    }
}
