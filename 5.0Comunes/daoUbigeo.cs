using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using _4._0Comunes;

namespace _5._0Comunes {
    public class daoUbigeo {
        #region singleton
        private static readonly daoUbigeo _instancia = new daoUbigeo();
        public static daoUbigeo Instancia {
            get { return daoUbigeo._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<entUbigeo> ListarDepartamentos() {
            SqlCommand cmd = null;
            List<entUbigeo> lista = new List<entUbigeo>();
            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spListarDepartamento", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    entUbigeo u = new entUbigeo();
                    u.idUbigeo = Convert.ToInt16(dr["Ubigeo"]);
                    u.Nombre = dr["Descripcion"].ToString();
                    lista.Add(u);
                }
            }
            catch (Exception e) {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public List<entUbigeo> ListarProvincias(int idDepartamento) {
            SqlCommand cmd = null;
            List<entUbigeo> lista = new List<entUbigeo>();
            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spListarProvincia", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintDepartamento",idDepartamento);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    entUbigeo u = new entUbigeo();
                    u.idUbigeo = Convert.ToInt16(dr["Ubigeo"]);
                    u.Nombre = dr["Descripcion"].ToString();
                    lista.Add(u);
                }
            }
            catch (Exception e) {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }
        #endregion metodos
    }
}
