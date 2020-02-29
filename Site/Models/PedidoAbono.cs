using MySql.Data.MySqlClient;
using Site.Models.Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class PedidoAbono
    {
        #region Propiedades
        public int Id { get; set; }
        [Display(Name = "Pedido")]
        public int Id_pedido { get; set; }
        [Display(Name = "Total aporte")]
        public double Total { get; set; }
        [Display(Name = "Inversionista")]
        public int Id_invercionista { get; set; }
        [Display(Name = "Inf.Inversionista")]
        public Inversionista Inversionista_ { get; set; }
        [Display(Name = "Registrado")]
        public DateTime Created { get; private set; }
        [Display(Name = "Actualizado")]
        public DateTime Updated { get; private set; }
        private DBMysql DBMysql_;
        #endregion

        #region Constructores
        public PedidoAbono(DBMysql DBMysql_)
        {
            this.DBMysql_ = DBMysql_;
        }
        public PedidoAbono()
        {

        }
        #endregion
        #region Metodos
        public int Update()
        {
            string Statement = string.Format("PedidoAporte|Id@INT={0}&Id_pedido@INT={1}&Total@DOUBLE={2}&Id_invercionista@INT={3}",
                 Id,
                 Id_pedido,
                 Total,
                 Id_invercionista
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
            string Statement = string.Format("PedidoAporte|Id@INT={0}&Id_pedido@INT={1}&Total@DOUBLE={2}&Id_invercionista@INT={3}",
                 0,
                 Id_pedido,
                 Total,
                 Id_invercionista
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
            string Statement = string.Format("select * from t08_notas_abonos where t08_pk01 = '{0}'", id);
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
                        Id_pedido = data.IsDBNull(1) ? 0 : data.GetInt32(1);
                        Total = data.IsDBNull(2) ? 0 : data.GetDouble(2);
                        Id_invercionista = data.IsDBNull(3) ? 0 : data.GetInt32(3);
                        Created = data.IsDBNull(4) ? DateTime.Now : data.GetDateTime(4);
                        Updated = data.IsDBNull(5) ? DateTime.Now : data.GetDateTime(5); ;
                    }
                    data.Close();
                    Inversionista_ = new Inversionista(DBMysql_);
                    Inversionista_.GetById(Id_invercionista);
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
        public List<PedidoAbono> List()
        {
            string Statement = string.Format("select * from t08_notas_abonos");
            MySqlDataReader data = null;
            List<PedidoAbono> List;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                List = new List<PedidoAbono>();
                if (data.HasRows)
                {

                    while (data.Read())
                    {
                        PedidoAbono PedidoAbono_ = new PedidoAbono();
                        PedidoAbono_.Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        PedidoAbono_.Id_pedido = data.IsDBNull(1) ? 0 : data.GetInt32(1);
                        PedidoAbono_.Total = data.IsDBNull(2) ? 0 : data.GetDouble(2);
                        PedidoAbono_.Id_invercionista = data.IsDBNull(3) ? 0 : data.GetInt32(3);
                        PedidoAbono_.Created = data.IsDBNull(4) ? DateTime.Now : data.GetDateTime(4);
                        PedidoAbono_.Updated = data.IsDBNull(5) ? DateTime.Now : data.GetDateTime(5);
                        List.Add(PedidoAbono_);
                    }
                    data.Close();
                    List.ForEach(Abono =>
                    {
                        Abono.Inversionista_ = new Inversionista(DBMysql_);
                        Abono.Inversionista_.GetById(Abono.Id_invercionista);
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
        public List<PedidoAbono> ListByPedido(int id)
        {
            string Statement = string.Format("select * from t08_notas_abonos where t05_pk01 = {0}",id);
            MySqlDataReader data = null;
            List<PedidoAbono> List;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                List = new List<PedidoAbono>();
                if (data.HasRows)
                {

                    while (data.Read())
                    {
                        PedidoAbono PedidoAbono_ = new PedidoAbono();
                        PedidoAbono_.Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        PedidoAbono_.Id_pedido = data.IsDBNull(1) ? 0 : data.GetInt32(1);
                        PedidoAbono_.Total = data.IsDBNull(2) ? 0 : data.GetDouble(2);
                        PedidoAbono_.Id_invercionista = data.IsDBNull(3) ? 0 : data.GetInt32(3);
                        PedidoAbono_.Created = data.IsDBNull(4) ? DateTime.Now : data.GetDateTime(4);
                        PedidoAbono_.Updated = data.IsDBNull(5) ? DateTime.Now : data.GetDateTime(5);
                        List.Add(PedidoAbono_);
                    }
                    data.Close();
                    List.ForEach(Abono =>
                    {
                        Abono.Inversionista_ = new Inversionista(DBMysql_);
                        Abono.Inversionista_.GetById(Abono.Id_invercionista);
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
        public List<PedidoAbono> ListByInvercionista(int id)
        {
            string Statement = string.Format("select * from t08_notas_abonos where t07_pk01 = {0}", id);
            MySqlDataReader data = null;
            List<PedidoAbono> List;
            try
            {
                data = DBMysql_.DoQuery(Statement);
                List = new List<PedidoAbono>();
                if (data.HasRows)
                {

                    while (data.Read())
                    {
                        PedidoAbono PedidoAbono_ = new PedidoAbono();
                        PedidoAbono_.Id = data.IsDBNull(0) ? 0 : (int)data.GetUInt32(0);
                        PedidoAbono_.Id_pedido = data.IsDBNull(1) ? 0 : data.GetInt32(1);
                        PedidoAbono_.Total = data.IsDBNull(2) ? 0 : data.GetDouble(2);
                        PedidoAbono_.Id_invercionista = data.IsDBNull(3) ? 0 : data.GetInt32(3);
                        PedidoAbono_.Created = data.IsDBNull(4) ? DateTime.Now : data.GetDateTime(4);
                        PedidoAbono_.Updated = data.IsDBNull(5) ? DateTime.Now : data.GetDateTime(5);
                        List.Add(PedidoAbono_);
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
        public void SetConnection(DBMysql DBMysql_)
        {
            this.DBMysql_ = DBMysql_;
        }
        #endregion
    }
}
