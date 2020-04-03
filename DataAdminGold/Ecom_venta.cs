using System;
using System.Collections.Generic;

namespace DataAdminGold
{
    public class Ecom_venta
    {
        public DateTime Incio { get; set; }
        public DateTime Final { get; set; }
        public List<Ecom_Abono> Ecom_Abono_ { get; set; }
        public List<Ecom_Inversiones> Ecom_Inversiones_ { get; set; }
    }
}
