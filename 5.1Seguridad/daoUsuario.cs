using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using _4._0Comunes;
using _4._1Seguridad;
using _5._0Comunes;

namespace _5._1Seguridad{
    public class daoUsuario{
        #region singleton
        private static readonly daoUsuario _instancia = new daoUsuario();
        public static daoUsuario Instancia
        {
            get { return daoUsuario._instancia; }
        }
        #endregion singleton

        #region metodos
        public entUsuario VerificarAcceso(String Usuario, String Password) {
            SqlCommand cmd = null;
            entUsuario u = null;
            try{
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spVerificarAcceso", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrUsuario", Usuario);
                cmd.Parameters.AddWithValue("@prmstrPassword", Password);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    u = new entUsuario();
                    u.idUsuario = Convert.ToInt16(dr["idUsuario"]);
                    u.FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"]);
                    u.UserName = dr["UserName"].ToString();
                    u.Activo = Convert.ToBoolean(dr["Activo"]);
                        entPersona p = new entPersona();
                        p.Nombres = dr["Nombres"].ToString();
                        p.Apellidos = dr["APELLIDOs"].ToString();
                        p.DNI = dr["DNI"].ToString();
                        p.Sexo = dr["Sexo"].ToString();
                    u.Persona = p;
                }
            }catch (Exception e){ throw e;
            }
            finally { cmd.Connection.Close(); }
            return u;
        }

        #endregion metodos
    }
}

