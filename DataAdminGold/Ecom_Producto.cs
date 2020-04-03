using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAdminGold
{
    public class Ecom_Producto
    {
        #region Propiedades
        [Display(Name = "Id")]
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public double PrecioCotizacion { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaVenta { get; set; }
        public int Estatus { get; set; }
        public int Pedido { get; set; }
        public int TipoProducto { get; set; }
        public int Cliente { get; set; }
        public Ecom_ProductoTipo Ecom_ProductoTipo_ { get; private set; }
        //extras
        public double PorcentVenta1 { get; set; }
        public double PorcentVenta2 { get; set; }
        public double Ganancia {
            get { return PrecioCotizacion > 0 ? (PrecioVenta - PrecioCotizacion) : (PrecioVenta - PrecioCompra); }
        }
        public double Ganancia1 { get; set; }
        public double Ganancia2 { get; set; }

        private Data_DBConnection Data_DBConnection_;
        #endregion

        #region Constructores
        ~Ecom_Producto()
        {

        }
        public Ecom_Producto()
        {

        }
        public Ecom_Producto(Data_DBConnection Data_DBConnection_)
        {
            this.Data_DBConnection_ = Data_DBConnection_;
        }
        #endregion

        #region Metodos
        public bool Add()
        {
            try
            {
                Data_DBConnection_.StartProcedure("SP_Producto");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(Clave, "Clave", "VARCHAR");
                Data_DBConnection_.AddParameter(Descripcion, "Descripcion", "VARCHAR");
                Data_DBConnection_.AddParameter(PrecioCotizacion, "PrecioCotizacion", "DOUBLE");
                Data_DBConnection_.AddParameter(PrecioCompra, "PrecioCompra", "DOUBLE");
                Data_DBConnection_.AddParameter(PrecioVenta, "PrecioVenta", "DOUBLE");
                Data_DBConnection_.AddParameter(FechaCotizacion, "FechaCotizacion", "DATETIME");
                Data_DBConnection_.AddParameter(FechaCompra, "FechaCompra", "DATETIME");
                Data_DBConnection_.AddParameter(FechaVenta, "FechaVenta", "DATETIME");
                Data_DBConnection_.AddParameter(Estatus, "Estatus", "INT");
                Data_DBConnection_.AddParameter(Pedido, "Pedido", "INT");
                Data_DBConnection_.AddParameter(TipoProducto, "TipoProducto", "INT");
                Data_DBConnection_.AddParameter(Cliente, "Cliente", "INT");
                Data_DBConnection_.AddParameter(1, "ModeProcedure", "INT");
                int result = Data_DBConnection_.ExecProcedure();
                return result == 0 ? true : false;
            }
            catch (Ecom_Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(int mode)
        {
            try
            {
                Data_DBConnection_.StartProcedure("SP_Producto");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(Clave, "Clave", "VARCHAR");
                Data_DBConnection_.AddParameter(Descripcion, "Descripcion", "VARCHAR");
                Data_DBConnection_.AddParameter(PrecioCotizacion, "PrecioCotizacion", "DOUBLE");
                Data_DBConnection_.AddParameter(PrecioCompra, "PrecioCompra", "DOUBLE");
                Data_DBConnection_.AddParameter(PrecioVenta, "PrecioVenta", "DOUBLE");
                Data_DBConnection_.AddParameter(FechaCotizacion, "FechaCotizacion", "DATETIME");
                Data_DBConnection_.AddParameter(FechaCompra, "FechaCompra", "DATETIME");
                Data_DBConnection_.AddParameter(FechaVenta, "FechaVenta", "DATETIME");
                Data_DBConnection_.AddParameter(Estatus, "Estatus", "INT");
                Data_DBConnection_.AddParameter(Pedido, "Pedido", "INT");
                Data_DBConnection_.AddParameter(TipoProducto, "TipoProducto", "INT");
                Data_DBConnection_.AddParameter(Cliente, "Cliente", "INT");
                Data_DBConnection_.AddParameter(mode, "ModeProcedure", "INT");
                int result = Data_DBConnection_.ExecProcedure();
                return result == 0 ? true : false;
            }
            catch (Ecom_Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete()
        {
            try
            {
                Data_DBConnection_.StartProcedure("SP_Producto");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(Clave, "Clave", "VARCHAR");
                Data_DBConnection_.AddParameter(Descripcion, "Descripcion", "VARCHAR");
                Data_DBConnection_.AddParameter(PrecioCotizacion, "PrecioCotizacion", "DOUBLE");
                Data_DBConnection_.AddParameter(PrecioCompra, "PrecioCompra", "DOUBLE");
                Data_DBConnection_.AddParameter(PrecioVenta, "PrecioVenta", "DOUBLE");
                Data_DBConnection_.AddParameter(FechaCotizacion, "FechaCotizacion", "DATETIME");
                Data_DBConnection_.AddParameter(FechaCompra, "FechaCompra", "DATETIME");
                Data_DBConnection_.AddParameter(FechaVenta, "FechaVenta", "DATETIME");
                Data_DBConnection_.AddParameter(Estatus, "Estatus", "INT");
                Data_DBConnection_.AddParameter(Pedido, "Pedido", "INT");
                Data_DBConnection_.AddParameter(TipoProducto, "TipoProducto", "INT");
                Data_DBConnection_.AddParameter(Cliente, "Cliente", "INT");
                Data_DBConnection_.AddParameter(3, "ModeProcedure", "INT");
                int result = Data_DBConnection_.ExecProcedure();
                return result == 0 ? true : false;
            }
            catch (Ecom_Exception ex)
            {
                throw ex;
            }
        }
        public bool Get(int id)
        {
            try
            {
                List<Ecom_Producto> List = ReadDatReader(string.Format("SELECT * FROM t07_producto where t07_pk01 = '{0}'", id));
                if (List.Count == 1)
                {
                    List.ForEach(item => {
                        Id = item.Id;
                        Clave = item.Clave;
                        Descripcion = item.Descripcion;
                        PrecioCotizacion = item.PrecioCotizacion;
                        PrecioCompra = item.PrecioCompra;
                        PrecioVenta = item.PrecioVenta;
                        FechaCotizacion = item.FechaCotizacion;
                        FechaCompra = item.FechaCompra;
                        FechaVenta = item.FechaVenta;
                        Estatus = item.Estatus;
                        Pedido = item.Pedido;
                        TipoProducto = item.TipoProducto;
                        Cliente = item.Cliente;
                        Ecom_ProductoTipo_ = item.Ecom_ProductoTipo_;
                    });
                    return true;
                }
                else
                {
                    Data_DBConnection_.Message = string.Format("No se ha podido encontrar el registro seleccionado");
                    return false;
                }
            }
            catch (Ecom_Exception ex)
            {
                throw ex;
            }
        }
        public List<Ecom_Producto> Get()
        {
            return ReadDatReader("select * from t07_producto");
        }
        public List<Ecom_Producto> GetByPedido(int idPEdido)
        {
            return ReadDatReader(string.Format("select * from t07_producto where t04_pk01 = {0}", idPEdido));
        }
        public List<Ecom_Producto> GetByCliente(int idPEdido)
        {
            return ReadDatReader(string.Format("select * from t07_producto where t02_pk01 = {0}", idPEdido));
        }
        private List<Ecom_Producto> ReadDatReader(string Statement)
        {
            List<Ecom_Producto> List = null;
            MySqlDataReader Data = null;
            try
            {
                Ecom_Tools.ValidDBobject(Data_DBConnection_);
                Data = Data_DBConnection_.DoQuery(Statement);
                List = new List<Ecom_Producto>();
                if (Data.HasRows)
                {
                    while (Data.Read())
                    {
                        List.Add(new Ecom_Producto
                        {
                            Id = Data.IsDBNull(0) ? 0 : (int)Data.GetUInt32(0),
                            Clave = Data.IsDBNull(1) ? "" : Data.GetString(1),
                            Descripcion = Data.IsDBNull(2) ? "" : Data.GetString(2),
                            PrecioCotizacion = Data.IsDBNull(3) ? 0 : Data.GetDouble(3),
                            PrecioCompra = Data.IsDBNull(4) ? 0 : Data.GetDouble(4),
                            PrecioVenta = Data.IsDBNull(5) ? 0 : Data.GetDouble(5),
                            FechaCotizacion = Data.IsDBNull(6) ? DateTime.Now : Data.GetDateTime(6),
                            FechaCompra = Data.IsDBNull(7) ? DateTime.Now : Data.GetDateTime(7),
                            FechaVenta = Data.IsDBNull(8) ? DateTime.Now : Data.GetDateTime(8),
                            Estatus = Data.IsDBNull(9) ? 0 : Data.GetInt32(9),
                            Pedido = Data.IsDBNull(10) ? 0 : Data.GetInt32(10),
                            TipoProducto = Data.IsDBNull(11) ? 0 : Data.GetInt32(11),
                            Cliente = Data.IsDBNull(12) ? 0 : Data.GetInt32(12),
                        });

                    }
                    Data.Close();
                    List.ForEach(item => {
                        item.Ecom_ProductoTipo_ = new Ecom_ProductoTipo(Data_DBConnection_);
                        item.Ecom_ProductoTipo_.Get(item.TipoProducto);
                    });
                }
                else
                {
                    Data_DBConnection_.Message = "Sin registros";
                }
                return List;
            }
            catch (Ecom_Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Data != null)
                {
                    Data.Close();
                }
            }
        }
        public void SetConnection(Data_DBConnection Data_DBConnection_)
        {
            this.Data_DBConnection_ = Data_DBConnection_;
        }
        #endregion
    }
}
