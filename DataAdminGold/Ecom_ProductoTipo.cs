using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAdminGold
{
    public class Ecom_ProductoTipo
    {
        #region Propiedades
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Descripción")]
        [Required]
        public string Descripcion { get; set; }
        private Data_DBConnection Data_DBConnection_;
        #endregion

        #region Constructores
        ~Ecom_ProductoTipo()
        {

        }
        public Ecom_ProductoTipo()
        {

        }
        public Ecom_ProductoTipo(Data_DBConnection Data_DBConnection_)
        {
            this.Data_DBConnection_ = Data_DBConnection_;
        }
        #endregion

        #region Metodos
        public bool Add()
        {
            try
            {
                Data_DBConnection_.StartProcedure("SP_tipoProducto");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
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
                Data_DBConnection_.StartProcedure("SP_tipoProducto");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
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
                Data_DBConnection_.StartProcedure("SP_tipoProducto");
                Data_DBConnection_.AddParameter(Id, "Id", "INT");
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
                List<Ecom_ProductoTipo> List = ReadDatReader(string.Format("SELECT * FROM t01_tipoproducto where t01_pk01 = '{0}'", id));
                if (List.Count == 1)
                {
                    List.ForEach(item => {
                        Id = item.Id;
                        Descripcion = item.Descripcion;
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
        public List<Ecom_ProductoTipo> Get()
        {
            return ReadDatReader("select * from t01_tipoproducto");
        }
        private List<Ecom_ProductoTipo> ReadDatReader(string Statement)
        {
            List<Ecom_ProductoTipo> List = null;
            MySqlDataReader Data = null;
            try
            {
                Ecom_Tools.ValidDBobject(Data_DBConnection_);
                Data = Data_DBConnection_.DoQuery(Statement);
                List = new List<Ecom_ProductoTipo>();
                if (Data.HasRows)
                {
                    while (Data.Read())
                    {
                        List.Add(new Ecom_ProductoTipo
                        {
                            Id = Data.IsDBNull(0) ? 0 : (int)Data.GetUInt32(0),
                            Descripcion = Data.IsDBNull(1) ? "" : Data.GetString(1),
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
