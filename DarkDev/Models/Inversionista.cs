using DarkDev.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DarkDev.Models
{

    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class Inversionista
    {
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdInversionista { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string NombreCompleto { get; set; }
    }
}
