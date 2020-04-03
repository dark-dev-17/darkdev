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
    public class InversionesController : Controller
    {
        private readonly string StringConnectio = ConfigurationManager.AppSettings["DataBase"].ToString();
        private EcomData EcomData_;
        private Ecom_Inversiones Ecom_Inversiones_;


        // GET: TipoProducto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int id)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Inversiones_ = (Ecom_Inversiones)EcomData_.GetObject(DataModel.Inversioniones);
                List<Ecom_Inversiones> result = Ecom_Inversiones_.GetByPedido(id);
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
        public ActionResult GetInversionista(int id)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Inversiones_ = (Ecom_Inversiones)EcomData_.GetObject(DataModel.Inversioniones);
                List<Ecom_Inversiones> result = Ecom_Inversiones_.GetByClienteInversionista(id);
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
        public ActionResult Create([FromBody]Ecom_Inversiones Ecom_Inversiones_)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Inversiones_ = (Ecom_Inversiones)EcomData_.SetObjectConnection(Ecom_Inversiones_,DataModel.Inversioniones);
                if (Ecom_Inversiones_.Inversionista == 0)
                {
                    throw new Ecom_Exception("Por favor selecciona Inversionista");
                }
                bool result = Ecom_Inversiones_.Add();
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
        public ActionResult Recuperar([FromBody]Ecom_Inversiones Ecom_Inversiones_)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Inversiones_ = (Ecom_Inversiones)EcomData_.SetObjectConnection(Ecom_Inversiones_, DataModel.Inversioniones);
                bool result = Ecom_Inversiones_.Update(3);
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
                Ecom_Inversiones_ = (Ecom_Inversiones)EcomData_.GetObject(DataModel.Inversioniones);
                Ecom_Inversiones_.Id = id;
                bool result = Ecom_Inversiones_.Delete();
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