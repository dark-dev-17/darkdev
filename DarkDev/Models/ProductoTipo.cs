using DarkDev.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DarkDev.Models
{

    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class ProductoTipo
    {
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdProductoTipo { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Nombre { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Identificador { get; set; }
    }
}
