using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Reflection
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    internal class MyModifiedAttribute : Attribute
    {
        public Type? TargetType { get; set; } = null;
        public object? TargetModificationValue { get; set; } = null;
    }
}
