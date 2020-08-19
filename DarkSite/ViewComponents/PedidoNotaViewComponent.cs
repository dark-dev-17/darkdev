using DarkDev;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkSite.ViewComponents
{
    public class PedidoNotaViewComponent : ViewComponent
    {
        private DarkDev.DarkDev darkDev;
        public PedidoNotaViewComponent(IConfiguration configuration)
        {
            darkDev = new DarkDev.DarkDev(configuration);
            darkDev.OpenConnection();
            darkDev.LoadObject(GpsManagerObjects.Pedido);
            darkDev.LoadObject(GpsManagerObjects.PedidoNota);
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var Pedido = darkDev.PedidoNota.Get(id);
            return await Task.FromResult((IViewComponentResult)View("PedidoNota", Pedido)); ;
        }
    }
}