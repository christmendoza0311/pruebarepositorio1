using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4._0Comunes;
using _4._1Seguridad;
using _5._1Seguridad;

namespace _3._1Seguridad{
    public class logUsuario
    {
        #region singleton
        private static readonly logUsuario _instancia = new logUsuario();
        public static logUsuario Instancia{
            get { return logUsuario._instancia; }
        }
        #endregion singleton

        #region metodos
        public entUsuario VerificarAcceso(String Usuario, String Password) {
            try{
                return daoUsuario.Instancia.VerificarAcceso(Usuario, Password);
            }catch (Exception e){                
                throw e;
            }
        }
        #endregion metodos
    }
}