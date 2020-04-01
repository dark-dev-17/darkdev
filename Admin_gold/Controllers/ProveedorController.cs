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
    public class ProveedorController : Controller
    {
        private readonly string StringConnectio = ConfigurationManager.AppSettings["DataBase"].ToString();
        private EcomData EcomData_;
        private Ecom_Proveedor Ecom_Proveedor_;


        // GET: TipoProducto
        public ActionResult Index()
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_Proveedor_ = (Ecom_Proveedor)EcomData_.GetObject(DataModel.Proveedor);
                List<Ecom_Proveedor> result = Ecom_Proveedor_.Get();
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
                Ecom_Proveedor_ = (Ecom_Proveedor)EcomData_.GetObject(DataModel.Proveedor);
                bool result = Ecom_Proveedor_.Get(id);
                if (result)
                {
                    return View(Ecom_Proveedor_);
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
        public ActionResult Create(Ecom_Proveedor Ecom_Proveedor_)
        {
            //return RedirectToAction(nameof(Index));
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Ecom_Proveedor_);
                }
                else
                {
                    EcomData_.Connect();
                    Ecom_Proveedor_ = (Ecom_Proveedor)EcomData_.SetObjectConnection(Ecom_Proveedor_, DataModel.Proveedor);
                    bool result = Ecom_Proveedor_.Add();
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
                return View(Ecom_Proveedor_);
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
                Ecom_Proveedor_ = (Ecom_Proveedor)EcomData_.GetObject(DataModel.Proveedor);
                bool result = Ecom_Proveedor_.Get(id);
                if (result)
                {
                    return View(Ecom_Proveedor_);
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
        public ActionResult Edit(Ecom_Proveedor Ecom_Proveedor_)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Ecom_Proveedor_);
                }
                else
                {
                    EcomData_.Connect();
                    Ecom_Proveedor_ = (Ecom_Proveedor)EcomData_.SetObjectConnection(Ecom_Proveedor_, DataModel.Proveedor);
                    bool result = Ecom_Proveedor_.Update();
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
                return View(Ecom_Proveedor_);
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
                Ecom_Proveedor_ = (Ecom_Proveedor)EcomData_.GetObject(DataModel.Proveedor);
                bool result = Ecom_Proveedor_.Get(id);
                if (result)
                {
                    return View(Ecom_Proveedor_);
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
                Ecom_Proveedor_ = (Ecom_Proveedor)EcomData_.GetObject(DataModel.Proveedor);
                Ecom_Proveedor_.Id = id;
                bool result = Ecom_Proveedor_.Delete();
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