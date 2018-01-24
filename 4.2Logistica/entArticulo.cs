using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2Logistica{
    public class entArticulo{
        public int idArticulo { get; set; } 
        public String Nombre { get; set; } 
        public String Detalle { get; set; } 
        public Double Precio { get; set; }
        public Double Stock { get; set; } 
        public String Imagen { get; set; } 
        public String DImagen { get; set; } 
        public entTipoArticulo TipoArticulo { get; set; }
        public Boolean Activo { get; set; } 
    }
}
