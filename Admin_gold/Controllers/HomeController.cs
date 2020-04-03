using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Admin_gold.Models;
using DataAdminGold;
using System.Configuration;

namespace Admin_gold.Controllers
{
    public class HomeController : Controller
    {
        private readonly string StringConnectio = ConfigurationManager.AppSettings["DataBase"].ToString();
        private EcomData EcomData_;
        private Ecom_venta Ecom_venta_;
        public IActionResult Index(DateTime fecha1, DateTime fecha2)
        {
            EcomData_ = new EcomData(StringConnectio);
            try
            {
                EcomData_.Connect();
                Ecom_venta_ = new Ecom_venta();
                Ecom_venta_.Incio = fecha1;
                Ecom_venta_.Final = fecha2;
                Ecom_Abono Ecom_Abono_list = (Ecom_Abono)EcomData_.GetObject(DataModel.Abono);
                Ecom_Inversiones Ecom_Inversiones_list = (Ecom_Inversiones)EcomData_.GetObject(DataModel.Inversioniones);
                Ecom_venta_.Ecom_Abono_ = Ecom_Abono_list.Get(fecha1, fecha2);
                Ecom_venta_.Ecom_Inversiones_ = Ecom_Inversiones_list.Get(fecha1, fecha2);
                return View(Ecom_venta_);
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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
