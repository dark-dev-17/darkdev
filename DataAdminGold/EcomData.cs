using System;

namespace DataAdminGold
{
    public class EcomData
    {
        private Data_DBConnection Data_DBConnection_;
        private string StringConnection { set; get; }
        public EcomData(string StringConnection)
        {
            this.StringConnection = StringConnection;
        }
        public void Connect()
        {
            try
            {
                Ecom_Tools.ValidStringParameter(StringConnection, "StringConnection");
                Data_DBConnection_ = new Data_DBConnection(StringConnection);
                Data_DBConnection_.OpenConnection();
            }
            catch (Ecom_Exception ex)
            {
                throw ex;
            }
        }
        public void Disconnect()
        {
            try
            {
                if (Data_DBConnection_ != null)
                {
                    Data_DBConnection_.CloseConnection();
                }
            }
            catch (Ecom_Exception ex)
            {
                throw ex;
            }
        }
        public string GetLastMessage()
        {
            return Data_DBConnection_.Message;
        }
        public object SetObjectConnection(object Modelo, DataModel objectSource)
        {
            if (objectSource == DataModel.TipoProducto)
            {
                Ecom_ProductoTipo objeto = (Ecom_ProductoTipo)Modelo;
                objeto.SetConnection(Data_DBConnection_);
                return objeto;
            }
            else if (objectSource == DataModel.Cliente)
            {
                Ecom_Cliente objeto = (Ecom_Cliente)Modelo;
                objeto.SetConnection(Data_DBConnection_);
                return objeto;
            }
            else if (objectSource == DataModel.Proveedor)
            {
                Ecom_Proveedor objeto = (Ecom_Proveedor)Modelo;
                objeto.SetConnection(Data_DBConnection_);
                return objeto;
            }
            else if (objectSource == DataModel.Pedido)
            {
                Ecom_Pedido objeto = (Ecom_Pedido)Modelo;
                objeto.SetConnection(Data_DBConnection_);
                return objeto;
            }
            else if (objectSource == DataModel.PedidoNota)
            {
                Ecom_PedidoNota objeto = (Ecom_PedidoNota)Modelo;
                objeto.SetConnection(Data_DBConnection_);
                return objeto;
            }
            else if (objectSource == DataModel.PedidoAjuste)
            {
                Ecom_PedidoAjuste objeto = (Ecom_PedidoAjuste)Modelo;
                objeto.SetConnection(Data_DBConnection_);
                return objeto;
            }
            else if (objectSource == DataModel.Producto)
            {
                Ecom_Producto objeto = (Ecom_Producto)Modelo;
                objeto.SetConnection(Data_DBConnection_);
                return objeto;
            }
            else if (objectSource == DataModel.Inversionista)
            {
                Ecom_Inversionista objeto = (Ecom_Inversionista)Modelo;
                objeto.SetConnection(Data_DBConnection_);
                return objeto;
            }
            else if (objectSource == DataModel.Inversioniones)
            {
                Ecom_Inversiones objeto = (Ecom_Inversiones)Modelo;
                objeto.SetConnection(Data_DBConnection_);
                return objeto;
            }
            else if (objectSource == DataModel.Abono)
            {
                Ecom_Abono objeto = (Ecom_Abono)Modelo;
                objeto.SetConnection(Data_DBConnection_);
                return objeto;
            }
            else
            {
                throw new Ecom_Exception(string.Format("Objeto no valido"));
            }
        }
        public object GetObject(DataModel objectSource)
        {
            if (objectSource == DataModel.TipoProducto)
            {
                return new Ecom_ProductoTipo(Data_DBConnection_);
            }
            else if (objectSource == DataModel.Cliente)
            {
                return new Ecom_Cliente(Data_DBConnection_);
            }
            else if (objectSource == DataModel.Proveedor)
            {
                return new Ecom_Proveedor(Data_DBConnection_);
            }
            else if (objectSource == DataModel.Pedido)
            {
                return new Ecom_Pedido(Data_DBConnection_);
            }
            else if (objectSource == DataModel.PedidoNota)
            {
                return new Ecom_PedidoNota(Data_DBConnection_);
            }
            else if (objectSource == DataModel.PedidoAjuste)
            {
                return new Ecom_PedidoAjuste(Data_DBConnection_);
            }
            else if (objectSource == DataModel.Producto)
            {
                return new Ecom_Producto(Data_DBConnection_);
            }
            else if (objectSource == DataModel.Inversionista)
            {
                return new Ecom_Inversionista(Data_DBConnection_);
            }
            else if (objectSource == DataModel.Inversioniones)
            {
                return new Ecom_Inversiones(Data_DBConnection_);
            }
            else if (objectSource == DataModel.Abono)
            {
                return new Ecom_Abono(Data_DBConnection_);
            }
            else
            {
                throw new Ecom_Exception(string.Format("Objeto no valido"));
            }
        }
    }
}
