using MySql.Data.MySqlClient;
using Site.Models.Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class Inversionista
    {
        #region Propiedades
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Activo")]
        public bool isActive { get; set; }
        [Display(Name = "Registrado")]
        public DateTime Created { get; private set; }
        [Display(Name = "Actualizado")]
        public DateTime Updated { get; private set; }
        private DBMysql DBMysql_;
        #endregion

        #region Constructores
        public Inversionista(DBMysql DBMysql_)
        {
            this.DBMysql_ = DBMysql_;
        }
        public Inversionista()
        {

        }
        #endregion
        #region Metodos
        public int Update()
        {
            string Statement = string.Format("Invercionista_update|Id@INT={0}&Nombre@VARCHAR={1}&isActive@INT={2}",
                    Id,
                 Nombre,
                 (isActive ? 1: 0)
             );
            int result;
            try
            {
                result = DBMysql_.ExecuteProcedureInt(Statement, "Result");
                return result;
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
        public int Create()
        {
            string Statement = string.Format("Invercionista_add|Nombre@VARCHAR={0}&isActive@INT={1}",
                 Nombre,
                 (isActive ? 1 : 0)
             );
            int result;
            try
            {
                result = DBMysql_.ExecuteProcedureInt(Statement, "Result");
                return result;
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
        public bool GetById(int id)
        {
            string Statement = string.Format("select * from t07_inversionistas where t07_pk01 = '{0}'", id);
            MySqlDataReader data = null;
            bool result = false;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        Nombre = data.IsDBNull(1) ? " -- " : data.GetString(1);
                        isActive = data.IsDBNull(2) ? false : (data.GetInt32(2) == 1 ? true : false);
                        Created = data.IsDBNull(3) ? DateTime.Now : data.GetDateTime(3);
                        Updated = data.IsDBNull(4) ? DateTime.Now : data.GetDateTime(4);
                    }
                    result = true;
                }
                return result;
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
        public List<Inversionista> List()
        {
            string Statement = string.Format("select * from t07_inversionistas");
            MySqlDataReader data = null;
            List<Inversionista> List;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                List = new List<Inversionista>();
                if (data.HasRows)
                {

                    while (data.Read())
                    {
                        Inversionista Inversionista_ = new Inversionista();
                        Inversionista_.Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        Inversionista_.Nombre = data.IsDBNull(1) ? " -- " : data.GetString(1);
                        Inversionista_.isActive = data.IsDBNull(2) ? false : (data.GetInt32(2) == 1 ? true : false);
                        Inversionista_.Created = data.IsDBNull(3) ? DateTime.Now : data.GetDateTime(3);
                        Inversionista_.Updated = data.IsDBNull(4) ? DateTime.Now : data.GetDateTime(4);
                        List.Add(Inversionista_);
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
        public void SetConnection(DBMysql DBMysql_)
        {
            this.DBMysql_ = DBMysql_;
        }
        #endregion
    }
}
