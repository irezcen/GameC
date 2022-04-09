using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    abstract class Spear : Item
    {
        // same as Item class, but IsSpear is set to true
        public Spear(string name) : base(name) 
        {
            IsSpear = true;
        }
    }
}
