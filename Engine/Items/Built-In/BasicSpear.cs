using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class BasicSpear : Spear
    {
        // simple spear
        public BasicSpear() : base("item0002") 
        {
            PrMod = 10;
            GoldValue = 10;
            PublicName = "Zwykla Wlocznia"; 
        }
    }
}
