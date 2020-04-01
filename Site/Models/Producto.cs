using MySql.Data.MySqlClient;
using Site.Models.Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class Producto
    {
        #region Propiedades
        [Display(Name = "Id Producto")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tipo Producto")]
        public int IdTipoProducto { get; set; }
        [Display(Name = "Pagina")]
        [Required]
        public int Pagina { get; set; }
        [Display(Name = "Clave")]
        [Required]
        public string Codigo { get; set; }
        [Display(Name = "Descripción")]
        [Required]
        public string Descripcion { get; set; }
        [Display(Name = "Precio cotizacion")]
        public double PrecioCotizacion { get; set; }
        [Display(Name = "Precio compra")]
        public double PrecioCompra { get; set; }
        [Display(Name = "Precio venta")]
        public double PrecioVenta { get; set; }
        [Display(Name = "Ganancia")]
        public double Ganacia { get { return PrecioVenta - PrecioCompra; }}
        [Display(Name = "Porcentaje Ganancia")]
        public double GanaciaPorcent { get { return (PrecioVenta - PrecioCompra)/(PrecioCompra /100); }}
        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }
        [Display(Name = "Nota")]
        public int IdNota { get; set; }
        public NotaPedido NotaPedido_ { get; private set; }
        [Display(Name = "Cliente")]
        public Cliente Cliente_ { get; set; }
        [Display(Name = "Cotizacion")]
        public DateTime Cotizacion { get; set; }
        [Display(Name = "Fecha compra")]
        public DateTime Compra { get; set; }
        [Display(Name = "Fecha venta")]
        public DateTime Venta { get; set; }
        public int Paso { get; set; }
        [Display(Name = "registrado")]
        public DateTime Created { get; private set; }
        [Display(Name = "Actualizado")]
        public DateTime Updated { get; private set; }
        
        private DBMysql DBMysql_;
        #endregion

        #region Construtores
        public Producto(DBMysql DBMysql_)
        {
            this.DBMysql_ = DBMysql_;
        }
        public Producto()
        {

        }
        #endregion

        #region Metodos
        public int Update()
        {
            string Statement = string.Format("Productos_add_upd|Id@INT={0}&IdTipoProducto@INT={1}&Pagina@VARCHAR={2}&Codigo@VARCHAR={3}&Descripcion@VARCHAR={4}&IdCliente@INT={5}&id_nota@INT={6}&PrecioCotizacion@DOUBLE={7}",
                 Id,
                  IdTipoProducto,
                  Pagina,
                  Codigo,
                  Descripcion,
                  IdCliente,
                  IdNota,
                  PrecioCotizacion
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
            string Statement = string.Format("Productos_add_upd|Id@INT={0}&IdTipoProducto@INT={1}&Pagina@VARCHAR={2}&Codigo@VARCHAR={3}&Descripcion@VARCHAR={4}&IdCliente@INT={5}&id_nota@INT={6}&PrecioCotizacion@DOUBLE={7}",
                 0,
                  IdTipoProducto,
                  Pagina,
                  Codigo,
                  Descripcion,
                  IdCliente,
                  IdNota,
                  PrecioCotizacion
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
            string Statement = string.Format("select * from t10_productos where t10_pk01 = '{0}'", id);
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
                        IdTipoProducto = data.IsDBNull(1) ? 0 : data.GetInt32(1);
                        Pagina = data.IsDBNull(2) ? 0 : data.GetInt32(2);
                        Codigo = data.IsDBNull(3) ? " -- " : data.GetString(3);
                        Descripcion = data.IsDBNull(4) ? " -- " : data.GetString(4);
                        PrecioCotizacion = data.IsDBNull(5) ? 0 : data.GetDouble(5);
                        PrecioCompra = data.IsDBNull(6) ? 0 : data.GetDouble(6);
                        PrecioVenta = data.IsDBNull(7) ? 0 : data.GetDouble(7);
                        IdCliente = data.IsDBNull(8) ? 0 : data.GetInt32(8);
                        Cotizacion = data.IsDBNull(9) ? DateTime.Now : data.GetDateTime(9);
                        Compra = data.IsDBNull(10) ? DateTime.Now : data.GetDateTime(10);
                        Venta = data.IsDBNull(11) ? DateTime.Now : data.GetDateTime(11);
                        Created = data.IsDBNull(12) ? DateTime.Now : data.GetDateTime(12);
                        Updated = data.IsDBNull(13) ? DateTime.Now : data.GetDateTime(13);
                        IdNota = data.IsDBNull(16) ? 0 : data.GetInt32(16);
                    }
                    data.Close();
                    Cliente_ = new Cliente(DBMysql_);
                    Cliente_.GetById(IdCliente);
                    NotaPedido_ = new NotaPedido(DBMysql_);
                    NotaPedido_.GetById(IdNota);
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
        public List<Producto> ListByCliente(int id)
        {
            string Statement = string.Format("select * from t10_productos where t04_pk01 = {0}", id);
            MySqlDataReader data = null;
            List<Producto> List;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                List = new List<Producto>();
                if (data.HasRows)
                {

                    while (data.Read())
                    {
                        Producto Producto_ = new Producto();
                        Producto_.Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        Producto_.IdTipoProducto = data.IsDBNull(1) ? 0 : data.GetInt32(1);
                        Producto_.Pagina = data.IsDBNull(2) ? 0 : data.GetInt32(2);
                        Producto_.Codigo = data.IsDBNull(3) ? " -- " : data.GetString(3);
                        Producto_.Descripcion = data.IsDBNull(4) ? " -- " : data.GetString(4);
                        Producto_.PrecioCotizacion = data.IsDBNull(5) ? 0 : data.GetDouble(5);
                        Producto_.PrecioCompra = data.IsDBNull(6) ? 0 : data.GetDouble(6);
                        Producto_.PrecioVenta = data.IsDBNull(7) ? 0 : data.GetDouble(7);
                        Producto_.IdCliente = data.IsDBNull(8) ? 0 : data.GetInt32(8);
                        Producto_.Cotizacion = data.IsDBNull(9) ? DateTime.Now : data.GetDateTime(9);
                        Producto_.Compra = data.IsDBNull(10) ? DateTime.Now : data.GetDateTime(10);
                        Producto_.Venta = data.IsDBNull(11) ? DateTime.Now : data.GetDateTime(11);
                        Producto_.Created = data.IsDBNull(12) ? DateTime.Now : data.GetDateTime(12);
                        Producto_.Updated = data.IsDBNull(13) ? DateTime.Now : data.GetDateTime(13);
                        Producto_.IdNota = data.IsDBNull(14) ? 0 : data.GetInt32(14);
                        List.Add(Producto_);
                    }
                    data.Close();
                    List.ForEach(item=> {
                        item.NotaPedido_ = new NotaPedido(DBMysql_);
                        item.NotaPedido_.GetById(item.IdNota);
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
        public List<Producto> ListByPedido(int id)
        {
            string Statement = string.Format("select * from ProductosPedido where t05_pk01 = {0}", id);
            MySqlDataReader data = null;
            List<Producto> List;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                List = new List<Producto>();
                if (data.HasRows)
                {

                    while (data.Read())
                    {
                        Producto Producto_ = new Producto();
                        Producto_.Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        Producto_.IdTipoProducto = data.IsDBNull(1) ? 0 : data.GetInt32(1);
                        Producto_.Pagina = data.IsDBNull(2) ? 0 : data.GetInt32(2);
                        Producto_.Codigo = data.IsDBNull(3) ? " -- " : data.GetString(3);
                        Producto_.Descripcion = data.IsDBNull(4) ? " -- " : data.GetString(4);
                        Producto_.PrecioCotizacion = data.IsDBNull(5) ? 0 : data.GetDouble(5);
                        Producto_.PrecioCompra = data.IsDBNull(6) ? 0 : data.GetDouble(6);
                        Producto_.PrecioVenta = data.IsDBNull(7) ? 0 : data.GetDouble(7);
                        Producto_.IdCliente = data.IsDBNull(8) ? 0 : data.GetInt32(8);
                        Producto_.Cotizacion = data.IsDBNull(9) ? DateTime.Now : data.GetDateTime(9);
                        Producto_.Compra = data.IsDBNull(10) ? DateTime.Now : data.GetDateTime(10);
                        Producto_.Venta = data.IsDBNull(11) ? DateTime.Now : data.GetDateTime(11);
                        Producto_.Created = data.IsDBNull(12) ? DateTime.Now : data.GetDateTime(12);
                        Producto_.Updated = data.IsDBNull(13) ? DateTime.Now : data.GetDateTime(13);
                        Producto_.IdNota = data.IsDBNull(16) ? 0 : data.GetInt32(16);
                        List.Add(Producto_);
                    }
                    data.Close();
                    List.ForEach(item => {
                        item.NotaPedido_ = new NotaPedido(DBMysql_);
                        item.NotaPedido_.GetById(item.IdNota);
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
        public List<Producto> ListByNota(int id)
        {
            string Statement = string.Format("select * from ProductosPedido where t06_pk01 = {0}", id);
            MySqlDataReader data = null;
            List<Producto> List;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                List = new List<Producto>();
                if (data.HasRows)
                {

                    while (data.Read())
                    {
                        Producto Producto_ = new Producto();
                        Producto_.Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        Producto_.IdTipoProducto = data.IsDBNull(1) ? 0 : data.GetInt32(1);
                        Producto_.Pagina = data.IsDBNull(2) ? 0 : data.GetInt32(2);
                        Producto_.Codigo = data.IsDBNull(3) ? " -- " : data.GetString(3);
                        Producto_.Descripcion = data.IsDBNull(4) ? " -- " : data.GetString(4);
                        Producto_.PrecioCotizacion = data.IsDBNull(5) ? 0 : data.GetDouble(5);
                        Producto_.PrecioCompra = data.IsDBNull(6) ? 0 : data.GetDouble(6);
                        Producto_.PrecioVenta = data.IsDBNull(7) ? 0 : data.GetDouble(7);
                        Producto_.IdCliente = data.IsDBNull(8) ? 0 : data.GetInt32(8);
                        Producto_.Cotizacion = data.IsDBNull(9) ? DateTime.Now : data.GetDateTime(9);
                        Producto_.Compra = data.IsDBNull(10) ? DateTime.Now : data.GetDateTime(10);
                        Producto_.Venta = data.IsDBNull(11) ? DateTime.Now : data.GetDateTime(11);
                        Producto_.Created = data.IsDBNull(12) ? DateTime.Now : data.GetDateTime(12);
                        Producto_.Updated = data.IsDBNull(13) ? DateTime.Now : data.GetDateTime(13);
                        Producto_.IdNota = data.IsDBNull(16) ? 0 : data.GetInt32(16);
                        List.Add(Producto_);
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
        public List<Producto> List()
        {
            string Statement = string.Format("select * from t10_productos");
            MySqlDataReader data = null;
            List<Producto> List;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                List = new List<Producto>();
                if (data.HasRows)
                {

                    while (data.Read())
                    {
                        Producto Producto_ = new Producto();
                        Producto_.Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        Producto_.IdTipoProducto = data.IsDBNull(1) ? 0 : data.GetInt32(1);
                        Producto_.Pagina = data.IsDBNull(2) ? 0 : data.GetInt32(2);
                        Producto_.Codigo = data.IsDBNull(3) ? " -- " : data.GetString(3);
                        Producto_.Descripcion = data.IsDBNull(4) ? " -- " : data.GetString(4);
                        Producto_.PrecioCotizacion = data.IsDBNull(5) ? 0 : data.GetDouble(5);
                        Producto_.PrecioCompra = data.IsDBNull(6) ? 0 : data.GetDouble(6);
                        Producto_.PrecioVenta = data.IsDBNull(7) ? 0 : data.GetDouble(7);
                        Producto_.IdCliente = data.IsDBNull(8) ? 0 : data.GetInt32(8);
                        Producto_.Cotizacion = data.IsDBNull(9) ? DateTime.Now : data.GetDateTime(9);
                        Producto_.Compra = data.IsDBNull(10) ? DateTime.Now : data.GetDateTime(10);
                        Producto_.Venta = data.IsDBNull(11) ? DateTime.Now : data.GetDateTime(11);
                        Producto_.Created = data.IsDBNull(12) ? DateTime.Now : data.GetDateTime(12);
                        Producto_.Updated = data.IsDBNull(13) ? DateTime.Now : data.GetDateTime(13);
                        Producto_.IdNota = data.IsDBNull(16) ? 0 : data.GetInt32(16);
                        List.Add(Producto_);
                    }
                    data.Close();
                    List.ForEach(item => {
                        item.Cliente_ = new Cliente(DBMysql_);
                        item.Cliente_.GetById(item.IdCliente);
                        item.NotaPedido_ = new NotaPedido(DBMysql_);
                        item.NotaPedido_.GetById(item.IdNota);
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
        public double GetTotalByCliente(int id)
        {
            string Statement = string.Format("SELECT sum(t10_f006) FROM site.t10_productos where t04_pk01 = '{0}';", id);
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
        public double GetTotalByPedido(int id)
        {
            string Statement = string.Format("SELECT sum(t10_f006) FROM ProductosPedido where t05_pk01 = '{0}';", id);
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
        public double GetTotalByNota(int id)
        {
            string Statement = string.Format("SELECT sum(t10_f006) FROM ProductosPedido where t06_pk01 = '{0}';", id);
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
