using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.BasicArmor
{
    [Serializable]
    class SteelArmor : Item
    {
        // no special effects, but stronger than other BasicArmors
        public SteelArmor() : base("item0005") 
        { 
            PublicName = "Stalowa Zbroja";
            GoldValue = 40;
            ArMod = 40;
        }

    }
}
