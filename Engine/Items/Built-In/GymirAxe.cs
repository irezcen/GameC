using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class GymirAxe : Axe
    {
        public GymirAxe() : base("item0009")
        {
            StrMod = 50;
            GoldValue = 80;
            PublicName = "Topor Gymira";
        }
    }
}
