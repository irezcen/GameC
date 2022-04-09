using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.BasicSkills
{
    class ChargeGSArmor : Spell
    {
        public ChargeGSArmor() : base("Charge GSArmor", 20, 3)
        {
            PublicName = "Naladuj zbroje rosnacego kamienia: zwieksz pancerz o 100 [wymaga posiadania przedmiotu]";
            SpecialItem = "item0008"; // this spell will only work if the player has GrowingStoneArmor
        }
        public override List<StatPackage> BattleMove(Player player, List<string> items)
        {
            player.BattleBuffArmor += 100; // use BattleBuff[something] for skills which need to buff statistics
            StatPackage response = new StatPackage("Twoja magia laduje zbroje rosnacego kamienia, zwiekszajac pancerz o 100.");
            return new List<StatPackage>() { response };
        }
    }
}
