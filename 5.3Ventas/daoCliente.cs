using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4._0Comunes;
using _4._3Ventas;
using _5._0Comunes;
using System.Data.SqlClient;
using System.Data;

namespace _5._3Ventas
{
    public class daoCliente
    {
        #region singleton
        private static readonly daoCliente _instancia = new daoCliente();
        public static daoCliente Instancia
        {
            get { return daoCliente._instancia; }
        }
        #endregion singleton

        #region metodos
        public entCliente VerificarAcceso(String Usuario, String Password)
        {
            SqlCommand cmd = null;
            entCliente u = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spVerificarAccesoCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrUsuario", Usuario);
                cmd.Parameters.AddWithValue("@prmstrPassword", Password);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    u = new entCliente();
                    u.idCliente = Convert.ToInt16(dr["idCliente"]);
                    u.Usuario = dr["Usuario"].ToString();
                    u.Activo = Convert.ToBoolean(dr["Activo"]);
                        entPersona p = new entPersona();
                        p.Nombres = dr["Nombres"].ToString();
                        p.Apellidos = dr["APELLIDOs"].ToString();
                        p.DNI = dr["DNI"].ToString();
                        p.Sexo = dr["Sexo"].ToString();
                    u.Persona = p;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return u;
        }

        #endregion metodos
    }
}
