using System;

namespace DataAdminGold
{
    public class Ecom_Exception : Exception
    {
        public Ecom_Exception()
        {

        }

        public Ecom_Exception(string mensaje)
            : base(mensaje)
        {

        }
    }
}
