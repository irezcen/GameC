using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class BasicAxe : Axe
    {
        // simple axe
        public BasicAxe() : base("item0003")
        {
            StrMod = 10;
            GoldValue = 10;
            PublicName = "Zwykly Topor"; 
        }
    }
}
