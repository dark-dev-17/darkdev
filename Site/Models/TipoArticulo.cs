using MySql.Data.MySqlClient;
using Site.Models.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class TipoArticulo
    {
        #region Propiedades
        public int Id { get; private set; }
        public string Descripcion { get; private set; }
        private DBMysql DBMysql_;
        #endregion
        #region Constructores
        public TipoArticulo(DBMysql DBMysql_)
        {
            this.DBMysql_ = DBMysql_;
        }
        public TipoArticulo()
        {

        }
        #endregion
        #region Metodos
        public bool Update()
        {
            string Statement = string.Format("" +
                "UPDATE t03_tipoarticulo SET " +
                    "t03_f001 = '{0}'" +
                "WHERE `t03_pk01` = '{1}'", Descripcion, Id);
            bool isExists = false;
            try
            {
                int result = DBMysql_.DoNonQuery(Statement);
                if(result > 0)
                {
                    isExists = true;
                }
                return isExists;
            }
            catch (DBException ex)
            {
                throw ex;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                
            }
        }
        public List<TipoArticulo> List()
        {
            string Statement = string.Format("select * from t03_tipoarticulo");
            MySqlDataReader data = null;
            List<TipoArticulo> List = null;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                if (data.HasRows)
                {
                    List = new List<TipoArticulo>();
                    while (data.Read())
                    {
                        TipoArticulo TipoArticulo_ = new TipoArticulo();
                        TipoArticulo_.Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        TipoArticulo_.Descripcion = data.IsDBNull(1) ? "" : data.GetString(1);
                        List.Add(TipoArticulo_);
                    }
                }
                return List;
            }
            catch (DBException ex)
            {
                throw ex;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                }
            }
        }
        public bool GetById(int id)
        {
            string Statement = string.Format("select * from t03_tipoarticulo where t03_pk01 = '{0}'", id);
            MySqlDataReader data = null;
            bool isExists = false;
            try
            {
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        Descripcion = data.IsDBNull(1) ? "" : data.GetString(1);
                    }
                    isExists = true;
                }
                return isExists;
            }
            catch (DBException ex)
            {
                throw ex;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                }
            }
        }
        #endregion

    }
}
