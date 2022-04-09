using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.BasicArmor
{
    [Serializable]
    class GrowingStoneArmor : Item
    {
        // armor with magic crystals that can grow stronger from the user's magic aura
        public GrowingStoneArmor() : base("item0008") 
        { 
            PublicName = "Zbroja Rosnacego Kamienia";
            PublicTip = "bonusowy punkt pancerza za kazde 4 punkty mocy magicznej";
            GoldValue = 40;
            ArMod = 20;
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.ArmorBuff += ArMod + currentPlayer.MagicPower / 4;
        }
    }
}
