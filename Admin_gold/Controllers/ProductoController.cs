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
    public class ProductoController : Controller
    {
        private readonly string StringConnectio = ConfigurationManager.AppSettings["DataBase"].ToString();
        private EcomData EcomData_;
        private Ecom_Producto Ecom_Producto_;


        // GET: TipoProducto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int id)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Producto_ = (Ecom_Producto)EcomData_.GetObject(DataModel.Producto);
                List<Ecom_Producto> result = Ecom_Producto_.GetByPedido(id);
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
        public ActionResult GetSinVender(int id)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Producto_ = (Ecom_Producto)EcomData_.GetObject(DataModel.Producto);
                List<Ecom_Producto> result = Ecom_Producto_.GetByPedido(id);
                return Ok(result.Where(item => item.PrecioCotizacion > 0 && item.Estatus >= 1 && item.Estatus <=2).ToList());
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
        public ActionResult GetSinCotizar(int id)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Producto_ = (Ecom_Producto)EcomData_.GetObject(DataModel.Producto);
                List<Ecom_Producto> result = Ecom_Producto_.GetByPedido(id);
                return Ok(result.Where(item => item.Estatus == 0 || item.PrecioCotizacion == 0).ToList());
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
        public ActionResult GetSinComprar(int id)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Producto_ = (Ecom_Producto)EcomData_.GetObject(DataModel.Producto);
                List<Ecom_Producto> result = Ecom_Producto_.GetByPedido(id);
                return Ok(result.Where(item => item.Estatus == 1 || item.PrecioCompra == 0).ToList());
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
        // GET: TipoProducto/Details/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(int id)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Producto_ = (Ecom_Producto)EcomData_.GetObject(DataModel.Cliente);
                bool result = Ecom_Producto_.Get(id);
                if (result)
                {
                    return Ok(Ecom_Producto_);
                }
                else
                {
                    return BadRequest(Ecom_Producto_);
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
        public ActionResult Create([FromBody]Ecom_Producto Ecom_Producto_)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Producto_ = (Ecom_Producto)EcomData_.SetObjectConnection(Ecom_Producto_,DataModel.Producto);
                if (Ecom_Producto_.TipoProducto == 0)
                {
                    throw new Ecom_Exception("Por favor selecciona tipo de producto");
                }
                bool result = Ecom_Producto_.Add();
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
        public ActionResult Edit([FromBody]Ecom_Producto Ecom_Producto_)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Producto_ = (Ecom_Producto)EcomData_.SetObjectConnection(Ecom_Producto_, DataModel.Producto);
                bool result = Ecom_Producto_.Update(2);
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
        public ActionResult Vender([FromBody]Ecom_Producto Ecom_Producto_)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Producto_ = (Ecom_Producto)EcomData_.SetObjectConnection(Ecom_Producto_, DataModel.Producto);
                if(Ecom_Producto_.Cliente == 0)
                {
                    throw new Ecom_Exception("Por favor selecciona un cliente para la venta");
                }
                bool result = Ecom_Producto_.Update(4);
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
        public ActionResult Cotizar([FromBody]Ecom_Producto Ecom_Producto_)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Producto_ = (Ecom_Producto)EcomData_.SetObjectConnection(Ecom_Producto_, DataModel.Producto);
                if (Ecom_Producto_.Cliente == 0)
                {
                    throw new Ecom_Exception("Por favor selecciona un cliente para la venta");
                }
                bool result = Ecom_Producto_.Update(5);
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
        public ActionResult Comprar([FromBody]Ecom_Producto Ecom_Producto_)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Producto_ = (Ecom_Producto)EcomData_.SetObjectConnection(Ecom_Producto_, DataModel.Producto);
                bool result = Ecom_Producto_.Update(6);
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
        public ActionResult ConcelarVenta([FromBody]Ecom_Producto Ecom_Producto_)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Producto_ = (Ecom_Producto)EcomData_.SetObjectConnection(Ecom_Producto_, DataModel.Producto);
                bool result = Ecom_Producto_.Update(7);
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
                Ecom_Producto_ = (Ecom_Producto)EcomData_.GetObject(DataModel.Producto);
                Ecom_Producto_.Id = id;
                bool result = Ecom_Producto_.Delete();
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