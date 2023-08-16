using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Reflection
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    internal class MyModifiedAttribute : Attribute
    {
        /// <summary>
        /// Stub
        /// </summary> 
    }
}
