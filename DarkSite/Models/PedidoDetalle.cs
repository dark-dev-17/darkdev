using DarkDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkSite.Models
{
    public class PedidoDetalle
    {
        public string Details { get; set; }
        public Pedido Pedido { get; set; }
        public Proveedor Proveedor { get; set; }
        public List<AportacionesPedidos> AportacionesPedidos { get; set; }
        public List<PedidoNota> PedidoNotas { get; set; }
    }
}
