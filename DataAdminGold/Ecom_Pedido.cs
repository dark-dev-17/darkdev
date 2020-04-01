using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAdminGold
{
    public class Ecom_Pedido
    {
        #region Propiedades
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Total")]
        [Required]
        public double Total { get; set; }
        [Display(Name = "Fecha Compra")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime FechaCompra { get; set; }
        [Display(Name = "Estatus")]
        [Required]
        public int Estatus { get; set; }
        [Display(Name = "Proveedor")]
        [Required]
        public int Proveedor { get; set; }
        private Data_DBConnection Data_DBConnection_;
        #endregion

        #region Constructores
        ~Ecom_Pedido()
        {

        }
        public Ecom_Pedido()
        {

        }
        public Ecom_Pedido(Data_DBConnection Data_DBConnection_)
        {
            this.Data_DBConnection_ = Data_DBConnection_;
        }
        #endregion

        #region Metodos
        public bool Add()
        {
            try
            {
                Data_DBConnection_.StartProcedure("SP_Pedido");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(Total, "Total", "DOUBLE");
                Data_DBConnection_.AddParameter(FechaCompra, "FechaCompra", "DATETIME");
                Data_DBConnection_.AddParameter(Estatus, "Estatus", "INT");
                Data_DBConnection_.AddParameter(Proveedor, "Proveedor", "INT");
                Data_DBConnection_.AddParameter(1, "ModeProcedure", "INT");
                int result = Data_DBConnection_.ExecProcedure();
                return result == 0 ? true : false;
            }
            catch (Ecom_Exception ex)
            {
                throw ex;
            }
        }
        public bool Update()
        {
            try
            {
                Data_DBConnection_.StartProcedure("SP_Pedido");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(Total, "Total", "DOUBLE");
                Data_DBConnection_.AddParameter(FechaCompra, "FechaCompra", "DATETIME");
                Data_DBConnection_.AddParameter(Estatus, "Estatus", "INT");
                Data_DBConnection_.AddParameter(Proveedor, "Proveedor", "INT");
                Data_DBConnection_.AddParameter(2, "ModeProcedure", "INT");
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
                Data_DBConnection_.StartProcedure("SP_Pedido");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(Total, "Total", "DOUBLE");
                Data_DBConnection_.AddParameter(FechaCompra, "FechaCompra", "DATETIME");
                Data_DBConnection_.AddParameter(Estatus, "Estatus", "INT");
                Data_DBConnection_.AddParameter(Proveedor, "Proveedor", "INT");
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
                List<Ecom_Pedido> List = ReadDatReader(string.Format("SELECT * FROM t04_pedido where t04_pk01 = '{0}'", id));
                if (List.Count == 1)
                {
                    List.ForEach(item => {
                        Id = item.Id;
                        Total = item.Total;
                        FechaCompra = item.FechaCompra;
                        Estatus = item.Estatus;
                        Proveedor = item.Proveedor;
                    });
                    return true;
                }
                else
                {
                    Data_DBConnection_.Message = string.Format("No se ha podido encontrar el tipo de producto seleccionado");
                    return false;
                }
            }
            catch (Ecom_Exception ex)
            {
                throw ex;
            }
        }
        public List<Ecom_Pedido> Get()
        {
            return ReadDatReader("select * from t04_pedido");
        }
        private List<Ecom_Pedido> ReadDatReader(string Statement)
        {
            List<Ecom_Pedido> List = null;
            MySqlDataReader Data = null;
            try
            {
                Ecom_Tools.ValidDBobject(Data_DBConnection_);
                Data = Data_DBConnection_.DoQuery(Statement);
                List = new List<Ecom_Pedido>();
                if (Data.HasRows)
                {
                    while (Data.Read())
                    {
                        List.Add(new Ecom_Pedido
                        {
                            Id = Data.IsDBNull(0) ? 0 : (int)Data.GetUInt32(0),
                            Total = Data.IsDBNull(1) ? 0 : Data.GetDouble(1),
                            FechaCompra = Data.IsDBNull(2) ? DateTime.Now : Data.GetDateTime(2),
                            Estatus = Data.IsDBNull(3) ? 0 : Data.GetInt32(3),
                            Proveedor = Data.IsDBNull(4) ? 0 : Data.GetInt32(4),
                        });

                    }
                    Data.Close();
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
