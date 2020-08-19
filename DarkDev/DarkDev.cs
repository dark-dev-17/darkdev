using DarkDev.DbManagers;
using DarkDev.Managers;
using DarkDev.Models;
using Microsoft.Extensions.Configuration;
using System;

namespace DarkDev
{
    public class DarkDev
    {
        protected DBConnection dBConnection { get; set; }
        protected string StringConnectionDb { get; set; }
        protected string Server { get; set; }
        protected string From { get; set; }
        protected int Port { get; set; }
        protected string User { get; set; }
        protected string Password { get; set; }
        protected bool UserSSL { get; set; }

        #region Variables de acceso
        public virtual DarkManager<Proveedor> Proveedor { get; set; }
        public virtual DarkManager<ProductoTipo> ProductoTipo { get; set; }
        public virtual DarkManager<Pedido> Pedido { get; set; }
        public virtual DarkManager<PedidoNota> PedidoNota { get; set; }
        public virtual DarkManager<Articulo> NotaProducto { get; set; }
        public virtual DarkManager<Inversionista> Inversionista { get; set; }
        public virtual DarkManager<AportacionesPedidos> AportacionesPedidos { get; set; }
        public virtual DarkManager<Articulo> Articulo { get; set; }

        #endregion

        #region Constructtores
        public DarkDev(IConfiguration Configuration)
        {
            this.StringConnectionDb = Configuration.GetConnectionString("Default");
        }
        public DarkDev(string DBconnection)
        {
            this.StringConnectionDb = DBconnection;
        }
        ~DarkDev()
        {

        }
        #endregion

        #region Base de datos
        public string GetLastMessage()
        {
            return dBConnection.mensaje;
        }

        public void LoadObject(GpsManagerObjects gpsManagerObjects)
        {
            if (gpsManagerObjects == GpsManagerObjects.Proveedor)
            {
                Proveedor = new DarkManager<Proveedor>(dBConnection);
            }
            else if (gpsManagerObjects == GpsManagerObjects.ProductoTipo)
            {
                ProductoTipo = new DarkManager<ProductoTipo>(dBConnection);
            }
            else if (gpsManagerObjects == GpsManagerObjects.Pedido)
            {
                Pedido = new DarkManager<Pedido>(dBConnection);
            }
            else if (gpsManagerObjects == GpsManagerObjects.PedidoNota)
            {
                PedidoNota = new DarkManager<PedidoNota>(dBConnection);
            }
            else if (gpsManagerObjects == GpsManagerObjects.NotaProducto)
            {
                NotaProducto = new DarkManager<Articulo>(dBConnection);
            }
            else if (gpsManagerObjects == GpsManagerObjects.Inversionista)
            {
                Inversionista = new DarkManager<Inversionista>(dBConnection);
            }
            else if (gpsManagerObjects == GpsManagerObjects.AportacionesPedidos)
            {
                AportacionesPedidos = new DarkManager<AportacionesPedidos>(dBConnection);
            }
            else if (gpsManagerObjects == GpsManagerObjects.Articulo)
            {
                Articulo = new DarkManager<Articulo>(dBConnection);
            }
        }

        public void OpenConnection()
        {
            dBConnection = new DBConnection(this.StringConnectionDb);
            dBConnection.OpenConnection();
        }

        public void CloseConnection()
        {
            if (dBConnection != null)
            {
                dBConnection.CloseDataBaseAccess();
            }
        }

        public void StartTransaction()
        {
            dBConnection.StartTransaction();
        }
        public void Commit()
        {
            dBConnection.Commit();
        }
        public void RolBack()
        {
            dBConnection.RolBack();
        }

        #endregion
    }

    public enum GpsManagerObjects
    {
        Proveedor = 1,
        ProductoTipo = 2,
        Pedido = 3,
        PedidoNota = 4,
        NotaProducto = 5,
        Inversionista = 6,
        AportacionesPedidos = 7,
        Articulo = 8,
    }
}