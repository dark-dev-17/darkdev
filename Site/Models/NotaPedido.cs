using MySql.Data.MySqlClient;
using Site.Models.Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class NotaPedido
    {
        #region Propiedades
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Folio de la nota")]

        public string Folio { get; set; }
        [Required]
        [Display(Name = "Total Nota")]
        public double Total { get; set; }
        [Required]
        [Display(Name = "Pedido")]
        public int Id_Pedido { get; set; }
        public Pedido Pedido_ { get; private set; }
        public List<Producto> Producto_ { get; private set; }
        private DBMysql DBMysql_;
        #endregion

        #region Constructores
        public NotaPedido(DBMysql DBMysql_)
        {
            this.DBMysql_ = DBMysql_;
        }
        public NotaPedido()
        {

        }
        #endregion

        #region Metodos
        public int Create()
        {
            string Statement = string.Format("PedidoNota_add_upda|Id@INT={0}&Folio@VARCHAR={1}&Total@DOUBLE={2}&Id_Pedido@INT={3}",
                    0,
                 Folio,
                 Total,
                 Id_Pedido
             );
            int result;
            try
            {
                result = DBMysql_.ExecuteStoreProcedure(Statement);
                if(result != 0)
                {
                    throw new DBException(DBMysql_.MessageResponse);
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

            }
        }
        public int Update()
        {
            string Statement = string.Format("PedidoNota_add_upda|Id@INT={0}&Folio@VARCHAR={1}&Total@DOUBLE={2}&Id_Pedido@INT={3}",
                    Id,
                 Folio,
                 Total,
                 Id_Pedido
             );
            int result;
            try
            {
                result = DBMysql_.ExecuteStoreProcedure(Statement);
                if (result != 0)
                {
                    throw new DBException(DBMysql_.MessageResponse);
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

            }
        }
        public int Delete(int id)
        {
            string Statement = string.Format("PedidoNota_delete|Id@INT={0}",id);
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
            string Statement = string.Format("select * from t06_notas_notas where t06_pk01 = '{0}'", id);
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
                        Folio = data.IsDBNull(1) ? " -- " : data.GetString(1);
                        Total = data.IsDBNull(2) ? 0 : data.GetDouble(2);
                        Id_Pedido = data.IsDBNull(3) ? 0 : data.GetInt32(3);
                    }
                    data.Close();
                    Producto_ = new Producto(DBMysql_).ListByNota(Id);
                    Pedido_ = new Pedido(DBMysql_);
                    Pedido_.GetById(Id);
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
        public List<NotaPedido> List()
        {
            string Statement = string.Format("select * from t06_notas_notas");
            MySqlDataReader data = null;
            List<NotaPedido> List;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                List = new List<NotaPedido>();
                if (data.HasRows)
                {

                    while (data.Read())
                    {
                        NotaPedido NotaPedido_ = new NotaPedido();
                        NotaPedido_.Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        NotaPedido_.Folio = data.IsDBNull(1) ? " -- " : data.GetString(1);
                        NotaPedido_.Total = data.IsDBNull(2) ? 0 : data.GetDouble(2);
                        NotaPedido_.Id_Pedido = data.IsDBNull(3) ? 0 : data.GetInt32(3);
                        List.Add(NotaPedido_);
                    }
                    data.Close();
                    List.ForEach(item => {
                        item.Pedido_ = new Pedido(DBMysql_);
                        item.Pedido_.GetById(item.Id_Pedido);
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
        public List<NotaPedido> ListByPedido(int id_pedido)
        {
            string Statement = string.Format("select * from t06_notas_notas where t05_pk01l = {0}",id_pedido);
            MySqlDataReader data = null;
            List<NotaPedido> List;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                List = new List<NotaPedido>();
                if (data.HasRows)
                {

                    while (data.Read())
                    {
                        NotaPedido NotaPedido_ = new NotaPedido();
                        NotaPedido_.Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        NotaPedido_.Folio = data.IsDBNull(1) ? " -- " : data.GetString(1);
                        NotaPedido_.Total = data.IsDBNull(2) ? 0 : data.GetDouble(2);
                        NotaPedido_.Id_Pedido = data.IsDBNull(3) ? 0 : data.GetInt32(3);
                        List.Add(NotaPedido_);
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
