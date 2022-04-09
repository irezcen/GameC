using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    abstract class Axe : Item
    {
        // same as Item class, but IsAxe is set to true
        public override bool IsAxe { get; protected set; } = true;
        public Axe(string name) : base(name) 
        {
            IsAxe = true;
        }
    }
}
