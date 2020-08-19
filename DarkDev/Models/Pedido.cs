using DarkDev.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DarkDev.Models
{

    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class Pedido
    {
        [Display(Name = "Folio")]
        [DisplayFormat(DataFormatString = "P{0:0000}", ApplyFormatInEditMode = true)]
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdPedido { get; set; }

        [Display(Name = "Descripción")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha de compra")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime FechaCompra { get; set; }

        [Display(Name = "Total del pedido")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public float Total { get; set; }

        [Display(Name = "Proveedor")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdProveedor { get; set; }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public string ProvedorNombre { get; set; }
    }
}
