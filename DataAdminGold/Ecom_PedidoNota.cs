using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAdminGold
{
    public class Ecom_PedidoNota
    {
        #region Propiedades
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Folio")]
        [Required]
        public double Folio { get; set; }
        [Display(Name = "Pedido")]
        [Required]
        public int Pedido { get; set; }

        private Data_DBConnection Data_DBConnection_;
        #endregion

        #region Constructores
        ~Ecom_PedidoNota()
        {

        }
        public Ecom_PedidoNota()
        {

        }
        public Ecom_PedidoNota(Data_DBConnection Data_DBConnection_)
        {
            this.Data_DBConnection_ = Data_DBConnection_;
        }
        #endregion

        #region Metodos
        public bool Add()
        {
            try
            {
                Data_DBConnection_.StartProcedure("SP_PedidoNota");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(Folio, "Folio", "VARCHAR");
                Data_DBConnection_.AddParameter(Pedido, "Pedido", "INT");
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
                Data_DBConnection_.StartProcedure("SP_PedidoNota");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(Folio, "Folio", "VARCHAR");
                Data_DBConnection_.AddParameter(Pedido, "Pedido", "INT");
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
                Data_DBConnection_.StartProcedure("SP_PedidoNota");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(Folio, "Folio", "VARCHAR");
                Data_DBConnection_.AddParameter(Pedido, "Pedido", "INT");
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
                List<Ecom_PedidoNota> List = ReadDatReader(string.Format("SELECT * FROM t05_pedidonota where t05_pk01 = '{0}'", id));
                if (List.Count == 1)
                {
                    List.ForEach(item => {
                        Id = item.Id;
                        Folio = item.Folio;
                        Pedido = item.Pedido;
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
        public List<Ecom_PedidoNota> Get()
        {
            return ReadDatReader("select * from t05_pedidonota");
        }
        public List<Ecom_PedidoNota> GetByPedido(int idPEdido)
        {
            return ReadDatReader(string.Format("select * from t05_pedidonota where t04_pk01 = {0}",idPEdido));
        }
        private List<Ecom_PedidoNota> ReadDatReader(string Statement)
        {
            List<Ecom_PedidoNota> List = null;
            MySqlDataReader Data = null;
            try
            {
                Ecom_Tools.ValidDBobject(Data_DBConnection_);
                Data = Data_DBConnection_.DoQuery(Statement);
                List = new List<Ecom_PedidoNota>();
                if (Data.HasRows)
                {
                    while (Data.Read())
                    {
                        List.Add(new Ecom_PedidoNota
                        {
                            Id = Data.IsDBNull(0) ? 0 : (int)Data.GetUInt32(0),
                            Folio = Data.IsDBNull(1) ? 0 : Data.GetDouble(1),
                            Pedido = Data.IsDBNull(2) ? 0 : Data.GetInt32(2)
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
