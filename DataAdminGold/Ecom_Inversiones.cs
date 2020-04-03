using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAdminGold
{
    public class Ecom_Inversiones
    {
        #region Propiedades
        [Display(Name = "Id")]
        public int Id { get; set; }
        public double TotalInversion { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInversion { get; set; }
        public int Inversionista { get; set; }
        public int Pedido { get; set; }
        public double TotalRecuperado { get; set; }
        public DateTime FechaRecuperado { get; set; }
        public int Estatus { get; set; }
        public Ecom_Inversionista Ecom_Inversionista_ { get; private set; }
        public Ecom_Pedido Ecom_Pedido_ { get; private set; }
        //public double Ganancia {
        //    get { return PrecioCotizacion > 0 ? (PrecioVenta - PrecioCotizacion) : (PrecioVenta - PrecioCompra); }
        //}

        private Data_DBConnection Data_DBConnection_;
        #endregion

        #region Constructores
        ~Ecom_Inversiones()
        {

        }
        public Ecom_Inversiones()
        {

        }
        public Ecom_Inversiones(Data_DBConnection Data_DBConnection_)
        {
            this.Data_DBConnection_ = Data_DBConnection_;
        }
        #endregion

        #region Metodos
        public bool Add()
        {
            try
            {
                Data_DBConnection_.StartProcedure("SP_Inversiones");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(TotalInversion, "TotalInversion", "DOUBLE");
                Data_DBConnection_.AddParameter(Descripcion, "Descripcion", "VARCHAR");
                Data_DBConnection_.AddParameter(FechaInversion, "FechaInversion", "DATETIME");
                Data_DBConnection_.AddParameter(Inversionista, "Inversionista", "INT");
                Data_DBConnection_.AddParameter(Pedido, "Pedido", "INT");
                Data_DBConnection_.AddParameter(TotalRecuperado, "TotalRecuperado", "DOUBLE");
                Data_DBConnection_.AddParameter(FechaRecuperado, "FechaRecuperado", "DATETIME");
                Data_DBConnection_.AddParameter(Estatus, "Estatus", "INT");
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
                Data_DBConnection_.StartProcedure("SP_Inversiones");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(TotalInversion, "TotalInversion", "DOUBLE");
                Data_DBConnection_.AddParameter(Descripcion, "Descripcion", "VARCHAR");
                Data_DBConnection_.AddParameter(FechaInversion, "FechaInversion", "DATETIME");
                Data_DBConnection_.AddParameter(Inversionista, "Inversionista", "INT");
                Data_DBConnection_.AddParameter(Pedido, "Pedido", "INT");
                Data_DBConnection_.AddParameter(TotalRecuperado, "TotalRecuperado", "DOUBLE");
                Data_DBConnection_.AddParameter(FechaRecuperado, "FechaRecuperado", "DATETIME");
                Data_DBConnection_.AddParameter(Estatus, "Estatus", "INT");
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
                Data_DBConnection_.StartProcedure("SP_Inversiones");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(TotalInversion, "TotalInversion", "DOUBLE");
                Data_DBConnection_.AddParameter(Descripcion, "Descripcion", "VARCHAR");
                Data_DBConnection_.AddParameter(FechaInversion, "FechaInversion", "DATETIME");
                Data_DBConnection_.AddParameter(Inversionista, "Inversionista", "INT");
                Data_DBConnection_.AddParameter(Pedido, "Pedido", "INT");
                Data_DBConnection_.AddParameter(TotalRecuperado, "TotalRecuperado", "DOUBLE");
                Data_DBConnection_.AddParameter(FechaRecuperado, "FechaRecuperado", "DATETIME");
                Data_DBConnection_.AddParameter(Estatus, "Estatus", "INT");
                Data_DBConnection_.AddParameter(2, "ModeProcedure", "INT");
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
                List<Ecom_Inversiones> List = ReadDatReader(string.Format("SELECT * FROM t09_inversiones where t09_pk01 = '{0}'", id));
                if (List.Count == 1)
                {
                    List.ForEach(item => {
                        Id = item.Id;
                        TotalInversion = item.TotalInversion;
                        Descripcion = item.Descripcion;
                        FechaInversion = item.FechaInversion;
                        Inversionista = item.Inversionista;
                        Pedido = item.Pedido;
                        TotalRecuperado = item.TotalRecuperado;
                        FechaRecuperado = item.FechaRecuperado;
                        Estatus = item.Estatus;
                        Ecom_Inversionista_ = item.Ecom_Inversionista_;
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
        public List<Ecom_Inversiones> Get()
        {
            return ReadDatReader("select * from t09_inversiones");
        }
        public List<Ecom_Inversiones> Get(DateTime Fecha1, DateTime Fecha2)
        {
            List<Ecom_Inversiones> List = ReadDatReader(string.Format("select * from t09_inversiones where t09_f003 >= '{0} 00:00:00' and t09_f003 <= '{1} 23:59:59'", Fecha1.ToString("yyyy-MM-dd"), Fecha2.ToString("yyyy-MM-dd")));
            return List;
        }
        public List<Ecom_Inversiones> GetByPedido(int idPEdido)
        {
            return ReadDatReader(string.Format("select * from t09_inversiones where t04_pk01 = {0}", idPEdido));
        }
        public List<Ecom_Inversiones> GetByClienteInversionista(int inverionistas)
        { 
            return ReadDatReader(string.Format("select * from t09_inversiones where t08_pk01 = {0}", inverionistas));
        }
        private List<Ecom_Inversiones> ReadDatReader(string Statement)
        {
            List<Ecom_Inversiones> List = null;
            MySqlDataReader Data = null;
            try
            {
                Ecom_Tools.ValidDBobject(Data_DBConnection_);
                Data = Data_DBConnection_.DoQuery(Statement);
                List = new List<Ecom_Inversiones>();
                if (Data.HasRows)
                {
                    while (Data.Read())
                    {
                        List.Add(new Ecom_Inversiones
                        {
                            Id = Data.IsDBNull(0) ? 0 : (int)Data.GetUInt32(0),
                            TotalInversion = Data.IsDBNull(1) ? 0 : Data.GetDouble(1),
                            Descripcion = Data.IsDBNull(2) ? "" : Data.GetString(2),
                            FechaInversion = Data.IsDBNull(3) ? DateTime.Now : Data.GetDateTime(3),
                            Inversionista = Data.IsDBNull(4) ? 0 : Data.GetInt32(4),
                            Pedido = Data.IsDBNull(5) ? 0 : Data.GetInt32(5),
                            TotalRecuperado = Data.IsDBNull(6) ? 0 : Data.GetDouble(6),
                            FechaRecuperado = Data.IsDBNull(7) ? DateTime.Now : Data.GetDateTime(7),
                            Estatus = Data.IsDBNull(8) ? 0: Data.GetInt32(8),
                        });

                    }
                    Data.Close();
                    List.ForEach(item => {
                        item.Ecom_Inversionista_ = new Ecom_Inversionista(Data_DBConnection_);
                        item.Ecom_Inversionista_.Get(item.Inversionista);
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
