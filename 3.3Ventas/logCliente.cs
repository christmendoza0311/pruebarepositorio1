using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4._0Comunes;
using _4._3Ventas;
using _5._3Ventas;

namespace _3._3Ventas
{
    public class logCliente
    {
        #region singleton
        private static readonly logCliente _instancia = new logCliente();
        public static logCliente Instancia
        {
            get { return logCliente._instancia; }
        }
        #endregion singleton

        #region metodos
        public entCliente VerificarAcceso(String Usuario, String Password)
        {
            try
            {
                return daoCliente.Instancia.VerificarAcceso(Usuario, Password);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion metodos
    }
}
