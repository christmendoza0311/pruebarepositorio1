using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5._2Logistica;
using _4._2Logistica;

namespace _3._2Logistica
{
    public class logTipoArticulo
    {
        #region singleton
        private static readonly logTipoArticulo _instancia = new logTipoArticulo();
        public static logTipoArticulo Instancia
        {
            get { return logTipoArticulo._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<entTipoArticulo> ListarTipoArticulos()
        {
            try
            {
                return daoTipoArticulo.Instancia.ListarTipoArticulos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion metodos
    }
}
