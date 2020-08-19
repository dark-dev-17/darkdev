using DarkDev.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DarkDev.Models
{

    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class PedidoNota
    {
        [Display(Name = "Folio")]
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdPedidoNota { get; set; }

        [Display(Name = "Pedido")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdPedido { get; set; }

        [Display(Name = "Folio Nota")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Folio { get; set; }

        [Display(Name = "Total")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public float Total { get; set; }

        [Display(Name = "Fecha")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Fecha { get; set; }
    }
}
