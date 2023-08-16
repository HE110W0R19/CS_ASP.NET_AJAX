using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Reflection
{
    [MyModified(TargetType = typeof(int), TargetModificationValue = "Add 10")]
    [MyModified(TargetType = typeof(string), TargetModificationValue = "Add broken")]
    [MyModified(TargetType = typeof(bool), TargetModificationValue = "Inversion")]
    internal class ChangebleTask4
    {
        [MyModified]
        private int _id = 1024;
        [MyModified]
        private string _name = "Barbos";
        [MyModified]
        private bool _isHuman = true;

        private int _idNoAttr = 512;
        private string _nameNoAttr = "Nikitos";
        private bool _isHumanNoAttr = false;

        public int Id { get => _id; }
        public string Name { get => _name; }
        public bool IsHuman { get => _isHuman; }

        public int IdNoAttr { get => _idNoAttr; }
        public string NameNoAttr { get => _nameNoAttr; }
        public bool IsHumanNoAttr { get => _isHumanNoAttr; }
    }
}
