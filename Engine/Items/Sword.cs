using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    abstract class Sword : Item
    {
        // same as Item class, but IsSword is set to true
        public Sword(string name) : base(name) 
        {
            IsSword = true;
        }
    }
}
