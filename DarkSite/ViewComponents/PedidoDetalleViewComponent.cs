using DarkDev;
using DarkDev.Models;
using DarkSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkSite.ViewComponents
{
    public class PedidoDetalleViewComponent : ViewComponent
    {
        private DarkDev.DarkDev darkDev;
        public PedidoDetalleViewComponent(IConfiguration configuration)
        {
            darkDev = new DarkDev.DarkDev(configuration);
            darkDev.OpenConnection();
            darkDev.LoadObject(GpsManagerObjects.Pedido);
            darkDev.LoadObject(GpsManagerObjects.AportacionesPedidos);
            darkDev.LoadObject(GpsManagerObjects.Proveedor);
            darkDev.LoadObject(GpsManagerObjects.PedidoNota);
        }

        public async Task<IViewComponentResult> InvokeAsync(int id, string details)
        {
            var Pedido = darkDev.Pedido.Get(id);
            List<AportacionesPedidos> Aportaciones = darkDev.AportacionesPedidos.Get("" + id, nameof(darkDev.AportacionesPedidos.Element.IdPedido));
            List<PedidoNota> PedidoNotas = darkDev.PedidoNota.Get("" + id, nameof(darkDev.PedidoNota.Element.IdPedido));
            return await Task.FromResult((IViewComponentResult)View("PedidoDetalle", new PedidoDetalle
            {
                Details = details,
                Pedido = Pedido,
                AportacionesPedidos = Aportaciones,
                PedidoNotas = PedidoNotas,
                Proveedor = darkDev.Proveedor.Get(Pedido.IdProveedor)
            })); ;
        }
    }
}
