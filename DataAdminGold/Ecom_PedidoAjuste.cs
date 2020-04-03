using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAdminGold
{
    public class Ecom_PedidoAjuste
    {
        #region Propiedades
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Total")]
        [Required]
        public double Total { get; set; }
        [Display(Name = "Tipo")]
        [Required]
        public int Tipo { get; set; }
        [Display(Name = "Pedido")]
        [Required]
        public int Pedido { get; set; }
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        private Data_DBConnection Data_DBConnection_;
        #endregion

        #region Constructores
        ~Ecom_PedidoAjuste()
        {

        }
        public Ecom_PedidoAjuste()
        {

        }
        public Ecom_PedidoAjuste(Data_DBConnection Data_DBConnection_)
        {
            this.Data_DBConnection_ = Data_DBConnection_;
        }
        #endregion

        #region Metodos
        public bool Add()
        {
            try
            {
                Data_DBConnection_.StartProcedure("SP_PedidoAjuste");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(Total, "Total", "DOUBLE");
                Data_DBConnection_.AddParameter(Tipo, "Tipo", "INT");
                Data_DBConnection_.AddParameter(Pedido, "Pedido", "INT");
                Data_DBConnection_.AddParameter(Descripcion, "Descripcion", "VARCHAR");
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
                Data_DBConnection_.StartProcedure("SP_PedidoAjuste");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(Total, "Total", "DOUBLE");
                Data_DBConnection_.AddParameter(Tipo, "Tipo", "INT");
                Data_DBConnection_.AddParameter(Pedido, "Pedido", "INT");
                Data_DBConnection_.AddParameter(Descripcion, "Descripcion", "VARCHAR");
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
                Data_DBConnection_.StartProcedure("SP_PedidoAjuste");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(Total, "Total", "DOUBLE");
                Data_DBConnection_.AddParameter(Tipo, "Tipo", "INT");
                Data_DBConnection_.AddParameter(Pedido, "Pedido", "INT");
                Data_DBConnection_.AddParameter(Descripcion, "Descripcion", "VARCHAR");
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
                List<Ecom_PedidoAjuste> List = ReadDatReader(string.Format("SELECT * FROM t06_pedidoajustes where t06_pk01 = '{0}'", id));
                if (List.Count == 1)
                {
                    List.ForEach(item => {
                        Id = item.Id;
                        Total = item.Total;
                        Tipo = item.Tipo;
                        Pedido = item.Pedido;
                        Descripcion = item.Descripcion;
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
        public List<Ecom_PedidoAjuste> Get()
        {
            return ReadDatReader("select * from t06_pedidoajustes");
        }
        public List<Ecom_PedidoAjuste> GetByPedido(int idPEdido)
        {
            return ReadDatReader(string.Format("select * from t06_pedidoajustes where t04_pk01 = {0}", idPEdido));
        }
        private List<Ecom_PedidoAjuste> ReadDatReader(string Statement)
        {
            List<Ecom_PedidoAjuste> List = null;
            MySqlDataReader Data = null;
            try
            {
                Ecom_Tools.ValidDBobject(Data_DBConnection_);
                Data = Data_DBConnection_.DoQuery(Statement);
                List = new List<Ecom_PedidoAjuste>();
                if (Data.HasRows)
                {
                    while (Data.Read())
                    {
                        List.Add(new Ecom_PedidoAjuste
                        {
                            Id = Data.IsDBNull(0) ? 0 : (int)Data.GetUInt32(0),
                            Total = Data.IsDBNull(1) ? 0 : Data.GetDouble(1),
                            Tipo = Data.IsDBNull(2) ? 0 : Data.GetInt32(2),
                            Pedido = Data.IsDBNull(3) ? 0 : Data.GetInt32(3),
                            Descripcion = Data.IsDBNull(4) ? "" : Data.GetString(4)
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
