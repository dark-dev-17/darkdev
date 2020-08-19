using System;
using System.Collections.Generic;
using System.Text;

namespace DarkDev.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class TableDB : Attribute
    {
        public string Name { get; set; }
        public bool IsMappedByLabels { get; set; }
        public bool IsStoreProcedure { get; set; }
    }
}
