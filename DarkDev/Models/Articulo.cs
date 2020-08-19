using DarkDev.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DarkDev.Models
{

    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class Articulo
    {
        [Display(Name = "Folio interno")]
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdArticulo { get; set; }

        [Required]
        [Display(Name = "Codigo")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Codigo { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int Cantidad { get; set; }

        [Required]
        [Display(Name = "Precio unitario")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public float PrecioCompraUnit { get; set; }

        [Required]
        [Display(Name = "% Ganancia")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public float Porcentaje { get; set; }

        [Required]
        [Display(Name = "Comentarios")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Comentarios { get; set; }

        [Required]
        [Display(Name = "Nota")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdPedidoNota { get; set; }

        [Display(Name = "Fecha Compra")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime FechaCompra { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdProductoTipo { get; set; }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public string ProductoTipoNombre { get; set; }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public string FolioNota { get; set; }
    }
}
