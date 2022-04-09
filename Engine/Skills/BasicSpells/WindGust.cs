using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class WindGust : Spell
    {
        // wind gust: deal 5+0.3*[Mp] damage
        public WindGust() : base("Wind Gust", 10, 1)
        {
            PublicName = "Podmuch Wiatru: (5 + 0.3 * Moc) dmg [wiatr]";
        }
        public override List<StatPackage> BattleMove(Player player, List<string> items)
        {
            StatPackage response = new StatPackage(DmgType.Air);
            response.HealthDmg = 5 + (int)(0.3 * player.MagicPower);
            response.CustomText = "Podmuch Wiatru uderza w przeciwnika! " + (5 + (int)(0.3 * player.MagicPower)) + " obrazen [wiatr]";
            return new List<StatPackage>() { response };
        }
    }
}
