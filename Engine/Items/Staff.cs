using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    abstract class Staff : Item
    {
        // same as Item class, but IsStaff is set to true
        public Staff(string name) : base(name) 
        {
            IsStaff = true;
        }
    }
}
