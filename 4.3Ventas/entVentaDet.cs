using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4._2Logistica;

namespace _4._3Ventas
{
    public class entVentaDet
    {
        public int Cantidad { get; set; }
        public Decimal Precio{ get; set; }
        public entArticulo Articulo { get; set; }
    }
}
