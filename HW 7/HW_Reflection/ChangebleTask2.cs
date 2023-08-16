using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Reflection
{
    internal class ChangebleTask2
    {
        private int _id = 1024;
        private string _name = "Barbos";
        private bool _isHuman = true;

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public bool IsHuman { get { return _isHuman; } }
    }
}
