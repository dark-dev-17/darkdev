using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAdminGold;
namespace Admin_gold.Controllers
{
    public class TipoProductoController : Controller
    {
        private readonly string StringConnectio = ConfigurationManager.AppSettings["DataBase"].ToString();
        private EcomData EcomData_;
        private Ecom_ProductoTipo Ecom_ProductoTipo_;


        // GET: TipoProducto
        public ActionResult Index()
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_ProductoTipo_ = (Ecom_ProductoTipo)EcomData_.GetObject(DataModel.TipoProducto);
                List<Ecom_ProductoTipo> result = Ecom_ProductoTipo_.Get();
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
                Ecom_ProductoTipo_ = (Ecom_ProductoTipo)EcomData_.GetObject(DataModel.TipoProducto);
                bool result = Ecom_ProductoTipo_.Get(id);
                if (result)
                {
                    return View(Ecom_ProductoTipo_);
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoProducto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ecom_ProductoTipo Ecom_ProductoTipo_)
        {
            //return RedirectToAction(nameof(Index));
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Ecom_ProductoTipo_);
                }
                else
                {
                    EcomData_.Connect();
                    Ecom_ProductoTipo_ = (Ecom_ProductoTipo)EcomData_.SetObjectConnection(Ecom_ProductoTipo_, DataModel.TipoProducto);
                    bool result = Ecom_ProductoTipo_.Add();
                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
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
                return View(Ecom_ProductoTipo_);
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
                Ecom_ProductoTipo_ = (Ecom_ProductoTipo)EcomData_.GetObject(DataModel.TipoProducto);
                bool result = Ecom_ProductoTipo_.Get(id);
                if (result)
                {
                    return View(Ecom_ProductoTipo_);
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
        public ActionResult Edit(Ecom_ProductoTipo Ecom_ProductoTipo_)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Ecom_ProductoTipo_);
                }
                else
                {
                    EcomData_.Connect();
                    Ecom_ProductoTipo_ = (Ecom_ProductoTipo)EcomData_.SetObjectConnection(Ecom_ProductoTipo_, DataModel.TipoProducto);
                    bool result = Ecom_ProductoTipo_.Update();
                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
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
                return View(Ecom_ProductoTipo_);
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
                Ecom_ProductoTipo_ = (Ecom_ProductoTipo)EcomData_.GetObject(DataModel.TipoProducto);
                bool result = Ecom_ProductoTipo_.Get(id);
                if (result)
                {
                    return View(Ecom_ProductoTipo_);
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
                Ecom_ProductoTipo_ = (Ecom_ProductoTipo)EcomData_.GetObject(DataModel.TipoProducto);
                Ecom_ProductoTipo_.Id = id;
                bool result = Ecom_ProductoTipo_.Delete();
                if (result)
                {
                    return RedirectToAction(nameof(Index));
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