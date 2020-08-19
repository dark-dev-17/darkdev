using System;
using System.Collections.Generic;
using System.Text;

namespace DarkDev.Exceptions
{
    public class DarkException : Exception
    {
        public DarkException()
        {

        }

        public DarkException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
