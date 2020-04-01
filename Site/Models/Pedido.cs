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
        [Display(Name = "Estatus del pedio")]
        public int StatusPedido { get; set; }
        [Required]
        [Display(Name = "Fecha del pedido")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [Required]
        [Display(Name = "Total del pedido")]
        public double Total { get; set; }
        [Required]
        [Display(Name = "Tipo de pedido")]
        public int TipoPedido { get; set; }
        [Display(Name = "Total aportes")]
        public double TotalAportes { get; private set; }
        [Display(Name = "Total ajustes(E) ")]
        public double TotalAjustesE { get; private set; }
        [Display(Name = "Total ajustes(I) ")]
        public double TotalAjustesI { get; private set; }
        [Display(Name = "Total real")]
        public double TotalReal { get { return (Total + TotalAjustesE - TotalAjustesI) - TotalAportes; } }
        public string Clave { get { return string.Format("{0}-{1}",(TipoPedido == 1 ? "Oro":"Plata"), Fecha.ToString("MM/dd/yyyy h:mm tt")); } }
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
            string Statement = string.Format("Pedido_update|Id@INT={0}&Fecha@DATETIME={1}&Total@DOUBLE={2}&TipoPedido@INT={3}&StatusPedido@INT={4}",
                    Id,
                 Fecha.ToString("yyyy-MM-dd HH:mm:ss"),
                 Total,
                 TipoPedido,
                 StatusPedido
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
            string Statement = string.Format("Pedido_add|Fecha@DATETIME={0}&Total@DOUBLE={1}&TipoPedido@INT={2}&StatusPedido@INT={3}",
                 Fecha.ToString("yyyy-MM-dd HH:mm:ss"),
                 Total,
                 TipoPedido,
                 StatusPedido
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
                        TipoPedido = data.IsDBNull(3) ? 0 : data.GetInt32(3);
                        StatusPedido = data.IsDBNull(4) ? 0 : data.GetInt32(4);
                    }
                    data.Close();
                    if (Id != 0)
                    {
                        Notas = new NotaPedido(DBMysql_).ListByPedido(Id);
                        PedidoAbono_ = new PedidoAbono(DBMysql_).ListByPedido(Id);
                        PedidoAjuste_ = new PedidoAjuste(DBMysql_).ListByPedido(Id);
                        TotalAportes =  new PedidoAbono(DBMysql_).GetTotalByPedido(Id);
                        TotalAjustesE =  new PedidoAjuste(DBMysql_).GetTotalByPedido("E",Id);
                        TotalAjustesI =  new PedidoAjuste(DBMysql_).GetTotalByPedido("I",Id);
                        Producto_ =  new Producto(DBMysql_).ListByPedido(Id);
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
                        Pedido_.TipoPedido = data.IsDBNull(3) ? 0 : data.GetInt32(3);
                        Pedido_.StatusPedido = data.IsDBNull(4) ? 0 : data.GetInt32(4);
                        List.Add(Pedido_);
                    }
                    data.Close();
                    List.ForEach(item => {
                        item.Notas = new NotaPedido(DBMysql_).ListByPedido(item.Id);
                        item.PedidoAbono_ = new PedidoAbono(DBMysql_).ListByPedido(item.Id);
                        item.PedidoAjuste_ = new PedidoAjuste(DBMysql_).ListByPedido(item.Id);
                        item.TotalAportes = new PedidoAbono(DBMysql_).GetTotalByPedido(item.Id);
                        item.TotalAjustesE = new PedidoAjuste(DBMysql_).GetTotalByPedido("E", item.Id);
                        item.TotalAjustesI = new PedidoAjuste(DBMysql_).GetTotalByPedido("I", item.Id);
                        item.Producto_ = new Producto(DBMysql_).ListByPedido(item.Id);
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
        public void SetConnection(DBMysql DBMysql_)
        {
            this.DBMysql_ = DBMysql_;
        }
        #endregion
    }
}
