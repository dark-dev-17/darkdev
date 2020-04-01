using MySql.Data.MySqlClient;
using Site.Models.Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class CuentaAbono
    {
        #region Propiedades
        public int Id { get; set; }
        [Display(Name = "Cliente")]
        public int Id_cliente { get; set; }
        [Display(Name = "Total ajuste")]
        [Required]
        public double Total { get; set; }
        [Display(Name = "Concepto")]
        [Required]
        public string Concepto { get; set; }
        [Display(Name = "Tipo de movimiento")]
        [Required]
        public string TipoMovimiento { get; set; }
        public List<TipoMovimiento> TipoMovimiento_ = new List<TipoMovimiento> { new TipoMovimiento { Id = "E", Descripcion = "Egreso" }, new TipoMovimiento { Id = "I", Descripcion = "Ingreso" } };
        [Display(Name = "registrado")]
        public DateTime Created { get; private set; }
        [Display(Name = "Actualizado")]
        public DateTime Updated { get; private set; }
        public Cliente Cliente_ { get; private set; }
        private DBMysql DBMysql_;
        #endregion

        #region Constructores
        public CuentaAbono(DBMysql DBMysql_)
        {
            this.DBMysql_ = DBMysql_;
        }
        public CuentaAbono()
        {

        }
        #endregion
        #region Metodos
        public int Update()
        {
            string Statement = string.Format("AbonoCuenta_add_upd|Id@INT={0}&Id_cliente@INT={1}&Concepto@VARCHAR={2}&Total@DOUBLE={3}&TipoMovimiento@VARCHAR={4}",
                 Id,
                 Id_cliente,
                 Concepto,
                 Total,
                 TipoMovimiento
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
            string Statement = string.Format("AbonoCuenta_add_upd|Id@INT={0}&Id_cliente@INT={1}&Concepto@VARCHAR={2}&Total@DOUBLE={3}&TipoMovimiento@VARCHAR={4}",
                 0,
                  Id_cliente,
                  Concepto,
                  Total,
                  TipoMovimiento
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
                        Id_cliente = data.IsDBNull(1) ? 0 : data.GetInt32(1);
                        Total = data.IsDBNull(2) ? 0 : data.GetDouble(2);
                        Concepto = data.IsDBNull(3) ? " -- " : data.GetString(3);
                        Created = data.IsDBNull(4) ? DateTime.Now : data.GetDateTime(4);
                        Updated = data.IsDBNull(5) ? DateTime.Now : data.GetDateTime(5); ;
                        TipoMovimiento = data.IsDBNull(6) ? " -- " : data.GetString(6);
                    }
                    data.Close();
                    Cliente_ = new Cliente(DBMysql_);
                    Cliente_.GetById(Id_cliente);
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
        public List<CuentaAbono> List()
        {
            string Statement = string.Format("select * from t11_abonos_cuenta");
            MySqlDataReader data = null;
            List<CuentaAbono> List;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                List = new List<CuentaAbono>();
                if (data.HasRows)
                {

                    while (data.Read())
                    {
                        CuentaAbono CuentaAbono_ = new CuentaAbono();
                        CuentaAbono_.Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        CuentaAbono_.Id_cliente = data.IsDBNull(1) ? 0 : data.GetInt32(1);
                        CuentaAbono_.Total = data.IsDBNull(2) ? 0 : data.GetDouble(2);
                        CuentaAbono_.Concepto = data.IsDBNull(3) ? " -- " : data.GetString(3);
                        CuentaAbono_.Created = data.IsDBNull(4) ? DateTime.Now : data.GetDateTime(4);
                        CuentaAbono_.Updated = data.IsDBNull(5) ? DateTime.Now : data.GetDateTime(5);
                        CuentaAbono_.TipoMovimiento = data.IsDBNull(6) ? " -- " : data.GetString(6);
                        List.Add(CuentaAbono_);
                    }
                    data.Close();
                    List.ForEach(item =>
                    {
                        item.Cliente_ = new Cliente(DBMysql_);
                        item.Cliente_.GetById(item.Id_cliente);
                    });
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
        public List<CuentaAbono> ListByCliente(int id)
        {
            string Statement = string.Format("select * from t11_abonos_cuenta where t04_pk01 = {0}", id);
            MySqlDataReader data = null;
            List<CuentaAbono> List;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                List = new List<CuentaAbono>();
                if (data.HasRows)
                {

                    while (data.Read())
                    {
                        CuentaAbono CuentaAbono_ = new CuentaAbono();
                        CuentaAbono_.Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        CuentaAbono_.Id_cliente = data.IsDBNull(1) ? 0 : data.GetInt32(1);
                        CuentaAbono_.Total = data.IsDBNull(2) ? 0 : data.GetDouble(2);
                        CuentaAbono_.Concepto = data.IsDBNull(3) ? " -- " : data.GetString(3);
                        CuentaAbono_.Created = data.IsDBNull(4) ? DateTime.Now : data.GetDateTime(4);
                        CuentaAbono_.Updated = data.IsDBNull(5) ? DateTime.Now : data.GetDateTime(5);
                        CuentaAbono_.TipoMovimiento = data.IsDBNull(6) ? " -- " : data.GetString(6);
                        List.Add(CuentaAbono_);
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
        public double GetTotalByCliente(string typeMovimiento,int idCliente)
        {
            string Statement = string.Format("SELECT sum(t11_f001) FROM t11_abonos_cuenta where t04_pk01 = '{0}' and t11_f003 = '{1}'", idCliente, typeMovimiento);
            try
            {
                double result = DBMysql_.GetScalarDouble(Statement);
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
        public void SetConnection(DBMysql DBMysql_)
        {
            this.DBMysql_ = DBMysql_;
        }
        #endregion
    }
}
