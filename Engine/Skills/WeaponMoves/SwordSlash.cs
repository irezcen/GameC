using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicWeaponMoves
{
    [Serializable]
    class SwordSlash : Skill
    {
        public SwordSlash() : base("Sword Slash", 20, 1)
        {
            PublicName = "Atak mieczem: (Sila * Precyzja / 100) dmg [fizyczne]";
            ReqItem = RequiredItem.Sword;
        }
        public override List<StatPackage> BattleMove(Player player, List<string> items)
        {
            StatPackage response = new StatPackage(DmgType.Physical);
            response.HealthDmg = (int)(player.Strength * player.Precision / 100);
            response.CustomText = "Atakujesz mieczem! " + (int)(player.Strength * player.Precision / 100) + " dmg [fizyczne]";
            return new List<StatPackage>() { response };
        }
    }
}
