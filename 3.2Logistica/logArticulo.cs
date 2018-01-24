using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5._2Logistica;
using _4._2Logistica;
namespace _3._2Logistica{
    public class logArticulo{        
        #region singleton
        private static readonly logArticulo _instancia = new logArticulo();
        public static logArticulo Instancia{
            get { return logArticulo._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<entArticulo> ListarArticulos(Int16 idTipo)
        {
            try{
                return daoArticulo.Instancia.ListarArticulos(idTipo);
            }catch (Exception e){                
                throw e;
            }
        }

        public Int16 InsertarArticulo(entArticulo a) {
            try
            {
                return daoArticulo.Instancia.InsertarArticulo(a);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion metodos
    }
}
