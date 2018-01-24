using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using _4._2Logistica;
using _5._0Comunes;

namespace _5._2Logistica
{
    public class daoTipoArticulo{
        #region singleton
        private static readonly daoTipoArticulo _instancia = new daoTipoArticulo();
        public static daoTipoArticulo Instancia
        {
            get { return daoTipoArticulo._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<entTipoArticulo> ListarTipoArticulos(){
            SqlCommand cmd = null;
            List<entTipoArticulo> lista = new List<entTipoArticulo>();
            try{
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spListarTipoArticulos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()){
                    entTipoArticulo t = new entTipoArticulo();
                    t.idTipoArticulo = Convert.ToInt16(dr["idTipoArticulo"]);
                    t.Descripcion = dr["Descripcion"].ToString();
                    t.Activo = Convert.ToBoolean(dr["Activo"]);
                    lista.Add(t);
                }
            }catch (Exception e){
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        #endregion metodos
    }
}
