using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAdminGold
{
    public class Ecom_Abono
    {
        #region Propiedades
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Total")]
        [Required]
        public double Total { get; set; }
        [Display(Name = "Telefono")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Fecha { get; set; }
        public int Cliente { get; set; }
        public Ecom_Cliente Ecom_Cliente_ { get; set; }
        private Data_DBConnection Data_DBConnection_;
        #endregion

        #region Constructores
        ~Ecom_Abono()
        {

        }
        public Ecom_Abono()
        {

        }
        public Ecom_Abono(Data_DBConnection Data_DBConnection_)
        {
            this.Data_DBConnection_ = Data_DBConnection_;
        }
        #endregion

        #region Metodos
        public bool Add()
        {
            try
            {
                Data_DBConnection_.StartProcedure("SP_Abonos");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(Total, "Total", "DOUBLE");
                Data_DBConnection_.AddParameter(Fecha, "Fecha", "DATETIME");
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
        public bool Delete()
        {
            try
            {
                Data_DBConnection_.StartProcedure("SP_Abonos");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(Total, "Total", "DOUBLE");
                Data_DBConnection_.AddParameter(Fecha, "Fecha", "DATETIME");
                Data_DBConnection_.AddParameter(Cliente, "Cliente", "INT");
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
                List<Ecom_Abono> List = ReadDatReader(string.Format("SELECT * FROM t10_abonos where t10_pk01 = '{0}'", id));
                if (List.Count == 1)
                {
                    List.ForEach(item => {
                        Id = item.Id;
                        Total = item.Total;
                        Fecha = item.Fecha;
                        Cliente = item.Cliente;
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
        public List<Ecom_Abono> Get()
        {
            return ReadDatReader("select * from t10_abonos");
        }
        public List<Ecom_Abono> Get(DateTime Fecha1, DateTime Fecha2)
        {
            List<Ecom_Abono> List = ReadDatReader(string.Format("select * from t10_abonos where t10_f002 >= '{0} 00:00:00' and t10_f002 <= '{1} 23:59:59'", Fecha1.ToString("yyyy-MM-dd"),Fecha2.ToString("yyyy-MM-dd")));
            List.ForEach(item => {
                item.Ecom_Cliente_ = new Ecom_Cliente(Data_DBConnection_);
                item.Ecom_Cliente_.Get(item.Cliente);
            });
            return List;
        }
        public List<Ecom_Abono> GetCliente(int idCliente)
        {
            List<Ecom_Abono> List = ReadDatReader(string.Format("select * from t10_abonos where t02_pk01 = {0}", idCliente));
            return List;
        }
        private List<Ecom_Abono> ReadDatReader(string Statement)
        {
            List<Ecom_Abono> List = null;
            MySqlDataReader Data = null;
            try
            {
                Ecom_Tools.ValidDBobject(Data_DBConnection_);
                Data = Data_DBConnection_.DoQuery(Statement);
                List = new List<Ecom_Abono>();
                if (Data.HasRows)
                {
                    while (Data.Read())
                    {
                        List.Add(new Ecom_Abono
                        {
                            Id = Data.IsDBNull(0) ? 0 : (int)Data.GetUInt32(0),
                            Total = Data.IsDBNull(1) ? 0 : Data.GetDouble(1),
                            Fecha = Data.IsDBNull(2) ? DateTime.Now : Data.GetDateTime(2),
                            Cliente = Data.IsDBNull(3) ?0 : Data.GetInt32(3),
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
