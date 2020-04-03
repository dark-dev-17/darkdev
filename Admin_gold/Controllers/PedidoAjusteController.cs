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
    public class PedidoAjusteController : Controller
    {
        private readonly string StringConnectio = ConfigurationManager.AppSettings["DataBase"].ToString();
        private EcomData EcomData_;
        private Ecom_PedidoAjuste Ecom_PedidoAjuste_;


        // GET: TipoProducto
        public ActionResult Index()
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_PedidoAjuste_ = (Ecom_PedidoAjuste)EcomData_.GetObject(DataModel.PedidoAjuste);
                List<Ecom_PedidoAjuste> result = Ecom_PedidoAjuste_.Get();
                return View(result);
            }
            catch (Ecom_Exception ex)
            {
                return View("../ErrorPages/Error", new { id = ex.Message });
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
        public ActionResult Details(int id)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_PedidoAjuste_ = (Ecom_PedidoAjuste)EcomData_.GetObject(DataModel.PedidoAjuste);
                bool result = Ecom_PedidoAjuste_.Get(id);
                if (result)
                {
                    return View(Ecom_PedidoAjuste_);
                }
                else
                {
                    throw new Ecom_Exception(EcomData_.GetLastMessage());
                }

            }
            catch (Ecom_Exception ex)
            {
                return View("../ErrorPages/Error", new { id = ex.Message });
            }
            finally
            {
                if (EcomData_ != null)
                {
                    EcomData_.Disconnect();
                }
            }
        }

        // GET: TipoProducto/Create
        public ActionResult Create(int id)
        {
            if(id != 0)
            {
                return View(new Ecom_PedidoAjuste { Pedido = id });
            }
            else
            {
                return View("../ErrorPages/Error", new { id = "Ningun pedido seleccionado" });
            }
            
        }

        // POST: TipoProducto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ecom_PedidoAjuste Ecom_PedidoAjuste_)
        {
            //return RedirectToAction(nameof(Index));
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Ecom_PedidoAjuste_);
                }
                else
                {
                    EcomData_.Connect();
                    Ecom_PedidoAjuste_ = (Ecom_PedidoAjuste)EcomData_.SetObjectConnection(Ecom_PedidoAjuste_, DataModel.PedidoAjuste);
                    bool result = Ecom_PedidoAjuste_.Add();
                    if (result)
                    {
                        return RedirectToAction("Details", "Pedido", new { Id = Ecom_PedidoAjuste_.Pedido });
                    }
                    else
                    {
                        throw new Ecom_Exception(EcomData_.GetLastMessage());
                    }
                }
            }
            catch (Ecom_Exception ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("{0}", ex.Message));
                return View(Ecom_PedidoAjuste_);
            }
            finally
            {
                if (EcomData_ != null)
                {
                    EcomData_.Disconnect();
                }
            }

        }

        // GET: TipoProducto/Edit/5
        public ActionResult Edit(int id)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_PedidoAjuste_ = (Ecom_PedidoAjuste)EcomData_.GetObject(DataModel.PedidoAjuste);
                bool result = Ecom_PedidoAjuste_.Get(id);
                if (result)
                {
                    return View(Ecom_PedidoAjuste_);
                }
                else
                {
                    throw new Ecom_Exception(EcomData_.GetLastMessage());
                }

            }
            catch (Ecom_Exception ex)
            {
                return View("../ErrorPages/Error", new { id = ex.Message });
            }
            finally
            {
                if (EcomData_ != null)
                {
                    EcomData_.Disconnect();
                }
            }
        }

        // POST: TipoProducto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ecom_PedidoAjuste Ecom_PedidoAjuste_)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Ecom_PedidoAjuste_);
                }
                else
                {
                    EcomData_.Connect();
                    Ecom_PedidoAjuste_ = (Ecom_PedidoAjuste)EcomData_.SetObjectConnection(Ecom_PedidoAjuste_, DataModel.PedidoAjuste);
                    bool result = Ecom_PedidoAjuste_.Update();
                    if (result)
                    {
                        return RedirectToAction("Details", "Pedido", new { Id = Ecom_PedidoAjuste_.Pedido });
                    }
                    else
                    {
                        throw new Ecom_Exception(EcomData_.GetLastMessage());
                    }
                }
            }
            catch (Ecom_Exception ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("{0}", ex.Message));
                return View(Ecom_PedidoAjuste_);
            }
            finally
            {
                if (EcomData_ != null)
                {
                    EcomData_.Disconnect();
                }
            }
        }

        // GET: TipoProducto/Delete/5
        public ActionResult Delete(int id)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_PedidoAjuste_ = (Ecom_PedidoAjuste)EcomData_.GetObject(DataModel.PedidoAjuste);
                bool result = Ecom_PedidoAjuste_.Get(id);
                if (result)
                {
                    return View(Ecom_PedidoAjuste_);
                }
                else
                {
                    throw new Ecom_Exception(EcomData_.GetLastMessage());
                }

            }
            catch (Ecom_Exception ex)
            {
                return View("../ErrorPages/Error", new { id = ex.Message });
            }
            finally
            {
                if (EcomData_ != null)
                {
                    EcomData_.Disconnect();
                }
            }
        }

        // POST: TipoProducto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_PedidoAjuste_ = (Ecom_PedidoAjuste)EcomData_.GetObject(DataModel.PedidoAjuste);
                Ecom_PedidoAjuste_.Id = id;
                bool result2 = Ecom_PedidoAjuste_.Get(id);
                int perdido = Ecom_PedidoAjuste_.Pedido;
                bool result = Ecom_PedidoAjuste_.Delete();
                if (result)
                {
                    return RedirectToAction("Details","Pedido", new { Id = perdido });
                }
                else
                {
                    throw new Ecom_Exception(EcomData_.GetLastMessage());
                }

            }
            catch (Ecom_Exception ex)
            {
                return View("../ErrorPages/Error", new { id = ex.Message });
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