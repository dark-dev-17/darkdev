using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class TipoMovimiento
    {
        [Display(Name = "Id")]
        public string Id { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}
