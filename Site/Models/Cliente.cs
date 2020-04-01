using MySql.Data.MySqlClient;
using Site.Models.Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class Cliente
    {
        #region Propiedades
        [Display(Name = "Clave")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get;  set; }
        [Display(Name = "Telefono")]
        [StringLength(10)]
        public string Telefono { get;  set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Correo { get;  set; }
        [Required]
        [Display(Name = "Activo")]
        public bool IsActive { get;  set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registrado")]
        public DateTime Created { get; private set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Actualizado")]
        public DateTime Updated { get; private set; }
        [Display(Name = "Total deuda")]
        public double TotalCuenta { get; private set; }
        [Display(Name = "Total pagado")]
        public double TotalPagado { get; private set; }
        [Display(Name = "Total pagado")]
        public double TotalSaldoFavor { get { return TotalPagado - TotalCuenta; } }
        public List<Producto> Producto_ { get; private set; }
        private DBMysql DBMysql_;
        #endregion
        #region Constructores
        public Cliente(DBMysql DBMysql_)
        {
            this.DBMysql_ = DBMysql_;
        }
        public Cliente()
        {

        }
        #endregion
        #region Metodos
        public void SetConnection(DBMysql DBMysql_)
        {
            this.DBMysql_ = DBMysql_;
        }
        public int Delete()
        {
            string Statement = string.Format("Cliente_delete|Id@INT={0}", Id);
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
            string Statement = string.Format("Cliente_update|Id@INT={0}&Nombre@VARCHAR={1}&Telefono@VARCHAR={2}&Correo@VARCHAR={3}&IsActive@INT={4}", 
                Id, 
                Nombre, 
                Telefono,
                Correo.Replace("@", "[AT]"), 
                (IsActive == true ? 1 : 0) 
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
            string Statement = string.Format("Cliente_add|Id@INT={0}&Nombre@VARCHAR={1}&Telefono@VARCHAR={2}&Correo@VARCHAR={3}&IsActive@INT={4}",
                 0,
                 Nombre,
                 Telefono,
                 Correo.Replace("@","[AT]"),
                 (IsActive == true ? 1 : 0)
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
        public List<Cliente> List()
        {
            string Statement = string.Format("select * from t04_clientes");
            MySqlDataReader data = null;
            List<Cliente> List = null;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                List = new List<Cliente>();
                if (data.HasRows)
                {
                    
                    while (data.Read())
                    {
                        Cliente Cliente_ = new Cliente();
                        Cliente_.Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        Cliente_.Nombre = data.IsDBNull(1) ? "" : data.GetString(1);
                        Cliente_.Telefono = data.IsDBNull(2) ? "" : data.GetString(2);
                        Cliente_.Correo = data.IsDBNull(3) ? "" : data.GetString(3);
                        Cliente_.IsActive = data.IsDBNull(4) ? false : (data.GetInt32(4) == 1 ? true: false);
                        Cliente_.Created = data.IsDBNull(5) ? DateTime.Now : data.GetDateTime(5);
                        Cliente_.Updated = data.IsDBNull(6) ? DateTime.Now : data.GetDateTime(6);
                        List.Add(Cliente_);
                    }
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
        public bool GetById(int id)
        {
            string Statement = string.Format("select * from t04_clientes where t04_pk01 = '{0}'", id);
            MySqlDataReader data = null;
            bool isExists = false;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        Nombre = data.IsDBNull(1) ? "" : data.GetString(1);
                        Telefono = data.IsDBNull(2) ? "" : data.GetString(2);
                        Correo = data.IsDBNull(3) ? "" : data.GetString(3);
                        IsActive = data.IsDBNull(4) ? false : (data.GetInt32(4) == 1 ? true : false);
                        Created = data.IsDBNull(5) ? DateTime.Now : data.GetDateTime(5);
                        Updated = data.IsDBNull(6) ? DateTime.Now : data.GetDateTime(6);
                    }
                    data.Close();
                    Producto_ = new Producto(DBMysql_).ListByCliente(Id);
                    TotalCuenta = new Producto(DBMysql_).GetTotalByCliente(Id);
                    TotalPagado = (new CuentaAbono(DBMysql_).GetTotalByCliente("I",Id) - new CuentaAbono(DBMysql_).GetTotalByCliente("E", Id)) ;
                    isExists = true;
                }
                return isExists;
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
        #endregion
    }
}
