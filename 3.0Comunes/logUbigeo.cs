using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4._0Comunes;
using _5._0Comunes;

namespace _3._0Comunes
{
    public class logUbigeo
    {
        //HOLAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        //dfsgfdgfdgdfgfd
        #region singleton
        private static readonly logUbigeo _instancia = new logUbigeo();
        public static logUbigeo Instancia {
            get { return logUbigeo._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<entUbigeo> ListarDepartamentos() {
            try {
                return daoUbigeo.Instancia.ListarDepartamentos();
            }
            catch (Exception e) {
                throw e;
            }
        }
        public List<entUbigeo> ListarProvincias(int idDepartamento) {
            try {
                return daoUbigeo.Instancia.ListarProvincias(idDepartamento);
            }
            catch (Exception e) {
                throw e;
            }
        }
        #endregion metodos
    }
}
