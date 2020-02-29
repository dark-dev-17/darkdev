using MySql.Data.MySqlClient;
using Site.Models.Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class PedidoAjuste
    {
        #region Propiedades
        public int Id { get; set; }
        [Display(Name = "Pedido")]
        public int Id_pedido { get; set; }
        [Display(Name = "Total ajuste")]
        [Required]
        public double Total { get; set; }
        [Display(Name = "Concepto")]
        [Required]
        public string Concepto { get; set; }
        [Display(Name = "registrado")]
        public DateTime Created { get; private set; }
        [Display(Name = "Actualizado")]
        public DateTime Updated { get; private set; }
        private DBMysql DBMysql_;
        #endregion

        #region Constructores
        public PedidoAjuste(DBMysql DBMysql_)
        {
            this.DBMysql_ = DBMysql_;
        }
        public PedidoAjuste()
        {

        }
        #endregion
        #region Metodos
        public int Update()
        {
            string Statement = string.Format("PedidoAjuste_add_upd|Id@INT={0}&Id_pedido@INT={1}&Concepto@VARCHAR={2}&Total@DOUBLE={3}",
                 Id,
                 Id_pedido,
                 Concepto,
                 Total
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
            string Statement = string.Format("PedidoAjuste_add_upd|Id@INT={0}&Id_pedido@INT={1}&Concepto@VARCHAR={2}&Total@DOUBLE={3}",
                 0,
                  Id_pedido,
                  Concepto,
                  Total
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
            string Statement = string.Format("select * from t09_notas_ajustes where t09_pk01 = '{0}'", id);
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
                        Id_pedido = data.IsDBNull(1) ? 0 : data.GetInt32(1);
                        Total = data.IsDBNull(2) ? 0 : data.GetDouble(2);
                        Concepto = data.IsDBNull(3) ? " -- " : data.GetString(3);
                        Created = data.IsDBNull(4) ? DateTime.Now : data.GetDateTime(4);
                        Updated = data.IsDBNull(5) ? DateTime.Now : data.GetDateTime(5); ;
                    }
                    data.Close();
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
        public List<PedidoAjuste> List()
        {
            string Statement = string.Format("select * from t09_notas_ajustes");
            MySqlDataReader data = null;
            List<PedidoAjuste> List;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                List = new List<PedidoAjuste>();
                if (data.HasRows)
                {

                    while (data.Read())
                    {
                        PedidoAjuste PedidoAjuste_ = new PedidoAjuste();
                        PedidoAjuste_.Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        PedidoAjuste_.Id_pedido = data.IsDBNull(1) ? 0 : data.GetInt32(1);
                        PedidoAjuste_.Total = data.IsDBNull(2) ? 0 : data.GetDouble(2);
                        PedidoAjuste_.Concepto = data.IsDBNull(3) ? " -- " : data.GetString(3);
                        PedidoAjuste_.Created = data.IsDBNull(4) ? DateTime.Now : data.GetDateTime(4);
                        PedidoAjuste_.Updated = data.IsDBNull(5) ? DateTime.Now : data.GetDateTime(5);
                        List.Add(PedidoAjuste_);
                    }
                    data.Close();
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
        public List<PedidoAjuste> ListByPedido(int id)
        {
            string Statement = string.Format("select * from t09_notas_ajustes where t05_pk01 = {0}", id);
            MySqlDataReader data = null;
            List<PedidoAjuste> List;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                List = new List<PedidoAjuste>();
                if (data.HasRows)
                {

                    while (data.Read())
                    {
                        PedidoAjuste PedidoAjuste_ = new PedidoAjuste();
                        PedidoAjuste_.Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        PedidoAjuste_.Id_pedido = data.IsDBNull(1) ? 0 : data.GetInt32(1);
                        PedidoAjuste_.Total = data.IsDBNull(2) ? 0 : data.GetDouble(2);
                        PedidoAjuste_.Concepto = data.IsDBNull(3) ? " -- " : data.GetString(3);
                        PedidoAjuste_.Created = data.IsDBNull(4) ? DateTime.Now : data.GetDateTime(4);
                        PedidoAjuste_.Updated = data.IsDBNull(5) ? DateTime.Now : data.GetDateTime(5);
                        List.Add(PedidoAjuste_);
                    }
                    data.Close();
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
