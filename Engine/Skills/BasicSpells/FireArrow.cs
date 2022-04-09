using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class FireArrow : Spell
    {
        // fire arrow: [Pr]% chance to land an arrow that deals 0.5*[Mp] damage
        // if your precision stat is higher than 100, you will always land the arrow
        public FireArrow() : base("Fire Arrow", 20, 1)
        { 
            PublicName = "Ognista Strzala: procentowa szansa rowna twojej precyzji na zadanie (0.5 * Moc) dmg [ogien]";
        }
        public override List<StatPackage> BattleMove(Player player, List<string> items)
        {
            StatPackage response = new StatPackage(DmgType.Fire);
            if (Index.RNG(0, 100) < player.Precision)
            {
                response.HealthDmg = (int)(0.5 * player.MagicPower);
                response.CustomText = "Ognista Strzala trafia przeciwnika! " + (int)(0.5 * player.MagicPower) + " dmg [ogien]";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "Ognista Strzala nie trafila w przeciwnika!";
            }
            return new List<StatPackage>() { response };
        }
    }
}
