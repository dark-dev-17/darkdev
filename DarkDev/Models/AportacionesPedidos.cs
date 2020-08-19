using DarkDev.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DarkDev.Models
{
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class AportacionesPedidos
    {
        [Display(Name = "Folio")]
        [DisplayFormat(DataFormatString = "I{0:0000}", ApplyFormatInEditMode = false)]
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdAportacionesPedidos { get; set; }

        [Display(Name = "Folio pedido")]
        [DisplayFormat(DataFormatString = "P{0:0000}", ApplyFormatInEditMode = false)]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdPedido { get; set; }

        [Required]
        [Range(1, 10000,ErrorMessage = "Por favor selecciona un inversionista")]
        [Display(Name = "Inversionista")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdInversionista { get; set; }

        [Required]
        [Display(Name = "Inversión")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public float Aporte { get; set; }

        [Display(Name = "Inversionista")]
        [ColumnDB(IsMapped = false, IsKey = false)]
        public string NombreInversionista { get; set; }
    }
}
