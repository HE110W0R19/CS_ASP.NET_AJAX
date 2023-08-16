using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Reflection
{
    internal class ChangebleTask1
    {
        private int _id = 1024;
        private static int _age = 8;

        public int Id { get { return _id; } }
        public int Age { get { return _age;} }
    }
}
