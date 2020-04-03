using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using DataAdminGold;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin_gold.Controllers
{
    public class AbonoController : Controller
    {
        private readonly string StringConnectio = ConfigurationManager.AppSettings["DataBase"].ToString();
        private EcomData EcomData_;
        private Ecom_Abono Ecom_Abono_;


        // GET: TipoProducto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Get(int id)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Abono_ = (Ecom_Abono)EcomData_.GetObject(DataModel.Abono);
                List<Ecom_Abono> result = Ecom_Abono_.GetCliente(id);
                return Ok(result);
            }
            catch (Ecom_Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                if (EcomData_ != null)
                {
                    EcomData_.Disconnect();
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRange(DateTime fecha1, DateTime fecha2)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Abono_ = (Ecom_Abono)EcomData_.GetObject(DataModel.Abono);
                List<Ecom_Abono> result = Ecom_Abono_.Get(fecha1, fecha2);
                return Ok(result);
            }
            catch (Ecom_Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                if (EcomData_ != null)
                {
                    EcomData_.Disconnect();
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromBody]Ecom_Abono Ecom_Abono_)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Abono_ = (Ecom_Abono)EcomData_.SetObjectConnection(Ecom_Abono_, DataModel.Abono);
                if (Ecom_Abono_.Cliente == 0)
                {
                    throw new Ecom_Exception("Por favor selecciona Cliente");
                }
                bool result = Ecom_Abono_.Add();
                if (result)
                {
                    return Ok(EcomData_.GetLastMessage());
                }
                else
                {
                    return BadRequest(EcomData_.GetLastMessage());
                }
            }
            catch (Ecom_Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                if (EcomData_ != null)
                {
                    EcomData_.Disconnect();
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Abono_ = (Ecom_Abono)EcomData_.GetObject(DataModel.Abono);
                Ecom_Abono_.Id = id;
                bool result = Ecom_Abono_.Delete();
                if (result)
                {
                    return Ok(EcomData_.GetLastMessage());
                }
                else
                {
                    return BadRequest(EcomData_.GetLastMessage());
                }
            }
            catch (Ecom_Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                if (EcomData_ != null)
                {
                    EcomData_.Disconnect();
                }
            }
        }
    }
}