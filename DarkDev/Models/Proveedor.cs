using DarkDev.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DarkDev.Models
{

    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class Proveedor
    {
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdProveedor { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Nombre { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Telefono { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Direccion { get; set; }
    }
}
