using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAdminGold
{
    public class Ecom_Proveedor
    {
        #region Propiedades
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string Nombre { get; set; }
        [Display(Name = "Telefono")]
        [Required]
        public string Telefono { get; set; }
        [Display(Name = "Dirección")]
        [Required]
        public string Direccion { get; set; }
        private Data_DBConnection Data_DBConnection_;
        #endregion

        #region Constructores
        ~Ecom_Proveedor()
        {

        }
        public Ecom_Proveedor()
        {

        }
        public Ecom_Proveedor(Data_DBConnection Data_DBConnection_)
        {
            this.Data_DBConnection_ = Data_DBConnection_;
        }
        #endregion

        #region Metodos
        public bool Add()
        {
            try
            {
                Data_DBConnection_.StartProcedure("SP_Proveedor");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(Nombre, "Nombre", "VARCHAR");
                Data_DBConnection_.AddParameter(Telefono, "Telefono", "VARCHAR");
                Data_DBConnection_.AddParameter(Direccion, "Direccion", "VARCHAR");
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
                Data_DBConnection_.StartProcedure("SP_Proveedor");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(Nombre, "Nombre", "VARCHAR");
                Data_DBConnection_.AddParameter(Telefono, "Telefono", "VARCHAR");
                Data_DBConnection_.AddParameter(Direccion, "Direccion", "VARCHAR");
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
                Data_DBConnection_.StartProcedure("SP_Proveedor");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
                Data_DBConnection_.AddParameter(Nombre, "Nombre", "VARCHAR");
                Data_DBConnection_.AddParameter(Telefono, "Telefono", "VARCHAR");
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
                List<Ecom_Proveedor> List = ReadDatReader(string.Format("SELECT * FROM t03_proveedor where t03_pk01 = '{0}'", id));
                if (List.Count == 1)
                {
                    List.ForEach(item => {
                        Id = item.Id;
                        Nombre = item.Nombre;
                        Telefono = item.Telefono;
                        Direccion = item.Direccion;
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
        public List<Ecom_Proveedor> Get()
        {
            return ReadDatReader("select * from t03_proveedor");
        }
        private List<Ecom_Proveedor> ReadDatReader(string Statement)
        {
            List<Ecom_Proveedor> List = null;
            MySqlDataReader Data = null;
            try
            {
                Ecom_Tools.ValidDBobject(Data_DBConnection_);
                Data = Data_DBConnection_.DoQuery(Statement);
                List = new List<Ecom_Proveedor>();
                if (Data.HasRows)
                {
                    while (Data.Read())
                    {
                        List.Add(new Ecom_Proveedor
                        {
                            Id = Data.IsDBNull(0) ? 0 : (int)Data.GetUInt32(0),
                            Nombre = Data.IsDBNull(1) ? "" : Data.GetString(1),
                            Telefono = Data.IsDBNull(2) ? "" : Data.GetString(2),
                            Direccion = Data.IsDBNull(3) ? "" : Data.GetString(3),
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
