using MySql.Data.MySqlClient;
using Site.Models.Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class Pedido
    {
        #region Propiedades
        [Required]
        [Display(Name = "Folio")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Fecha del pedido")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [Required]
        [Display(Name = "Total del pedido")]
        public double Total { get; set; }
        public List<NotaPedido> Notas { get; private set; }
        public List<PedidoAbono> PedidoAbono_ { get; private set; }
        public List<PedidoAjuste> PedidoAjuste_ { get; private set; }
        public List<Producto> Producto_ { get; private set; }
        private DBMysql DBMysql_;
        #endregion

        #region Constructores
        public Pedido(DBMysql DBMysql_)
        {
            this.DBMysql_ = DBMysql_;
        }
        public Pedido()
        {

        }
        #endregion

        #region Metodos
        public int Delete()
        {
            string Statement = string.Format("Pedido_delete|Id@INT={0}",
                    Id
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
        public int Update()
        {
            string Statement = string.Format("Pedido_update|Id@INT={0}&Fecha@DATETIME={1}&Total@DOUBLE={2}",
                    Id,
                 Fecha,
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
            string Statement = string.Format("Pedido_add|Fecha@DATETIME={0}&Total@DOUBLE={1}",
                 Fecha,
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
            string Statement = string.Format("select * from t05_notas where t05_pk01 = '{0}'", id);
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
                        Fecha = data.IsDBNull(1) ? DateTime.Now : data.GetDateTime(1);
                        Total = data.IsDBNull(2) ? 0 : data.GetDouble(2);
                        
                    }
                    data.Close();
                    if (Id != 0)
                    {
                        Notas = new NotaPedido(DBMysql_).ListByPedido(Id);
                        PedidoAbono_ = new PedidoAbono(DBMysql_).ListByPedido(Id);
                        PedidoAjuste_ = new PedidoAjuste(DBMysql_).ListByPedido(Id);
                        //Producto_ =  new Producto(DBMysql_).ListByPedido(Id);
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
        public List<Pedido> List()
        {
            string Statement = string.Format("select * from t05_notas");
            MySqlDataReader data = null;
            List<Pedido> List = null;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                List = new List<Pedido>();
                if (data.HasRows)
                {
                    
                    while (data.Read())
                    {
                        Pedido Pedido_ = new Pedido();
                        Pedido_.Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        Pedido_.Fecha = data.IsDBNull(1) ? DateTime.Now : data.GetDateTime(1);
                        Pedido_.Total = data.IsDBNull(2) ? 0 : data.GetDouble(2);
                        List.Add(Pedido_);
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
