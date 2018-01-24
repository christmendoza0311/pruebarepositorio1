using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _5._0Comunes{
    public class Conexion
    {
        #region singleton
        private static readonly Conexion _instancia = new Conexion();
        public static Conexion Instancia {
            get { return Conexion._instancia; }
        }
        #endregion singleton

        #region metodos
        public SqlConnection conectar() {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=.; Initial Catalog = BDDIARS;" +
                                   //"User ID=sa; Password=123" 
                                   "Integrated Security=true";
            return cn;
        }
        #endregion metodos
    }
}
