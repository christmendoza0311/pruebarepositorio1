using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data; 
using _4._2Logistica;
using _5._0Comunes;

namespace _5._2Logistica{
    public class daoArticulo
    {
        #region singleton
        private static readonly daoArticulo _instancia = new daoArticulo();
        public static daoArticulo Instancia
        {
            get { return daoArticulo._instancia; }
        }
        #endregion singleton

        #region metodos

        public List<entArticulo> ListarArticulos(Int16 idTipo){
            SqlCommand cmd = null;
            List<entArticulo> lista = new List<entArticulo>();
            try{
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spListarArticulos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintTipoArticulo", idTipo);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read()){
                    entArticulo a = new entArticulo();
                    a.idArticulo = Convert.ToInt16(dr["idArticulo"]);
                    a.Nombre = dr["Nombre"].ToString();
                    a.Detalle = dr["Detalle"].ToString();
                    a.Imagen = dr["Imagen"].ToString();
                    a.DImagen = dr["DImagen"].ToString();                    
                    a.Activo = Convert.ToBoolean(dr["Activo"]);
                        entTipoArticulo t = new entTipoArticulo();
                        t.idTipoArticulo = Convert.ToInt16(dr["idTipoArticulo"]);
                        t.Descripcion = dr["Descripcion"].ToString();
                    a.TipoArticulo = t;
                    a.Stock = Convert.ToDouble(dr["Stock"]);
                    a.Precio = Convert.ToDouble(dr["Precio"]);
                    lista.Add(a);
                }
            }catch (Exception e){
                throw e;
            }finally { cmd.Connection.Close(); }
            return lista;
        }

        public Int16 InsertarArticulo(entArticulo a) {
            SqlCommand cmd = null;
            Int16 PKCreado = 0;
            try{
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spInsertarArticulo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombre", a.Nombre);
                cmd.Parameters.AddWithValue("@prmstrDetalle", a.Detalle);
                cmd.Parameters.AddWithValue("@prmstrImagen", a.Imagen);
                cmd.Parameters.AddWithValue("@prmstrDImagen", a.DImagen);
                cmd.Parameters.AddWithValue("@prmintTipoArticulo", a.TipoArticulo.idTipoArticulo);
                cmd.Parameters.AddWithValue("@prmdblStock", a.Stock);
                cmd.Parameters.AddWithValue("@prmdblPrecio", a.Precio);
                cmd.Parameters.AddWithValue("@prmbitActivo", a.Activo);

                //creamos variable de retorno
                SqlParameter p = new SqlParameter("@retorno", DbType.Int16);
                p.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(p);

                cn.Open();
                cmd.ExecuteNonQuery();
                PKCreado = Convert.ToInt16(cmd.Parameters["@retorno"].Value);
 
            }catch (Exception e){throw e;
            }finally { cmd.Connection.Close(); }
            return PKCreado;
        }

        #endregion metodos
    }
}
