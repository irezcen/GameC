using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicWeaponMoves
{
    [Serializable]
    class SpearStab : Skill
    {
        // simple stab with spear
        public SpearStab() : base("Spear Stab", 20, 1) 
        { 
            PublicName = "Atak wlocznia: (10 + 0.2 * Sila) dmg [fizyczne] oraz (Precyzja %) szansy na kolejne uderzenie";
            ReqItem = RequiredItem.Spear;
        }
        public override List<StatPackage> BattleMove(Player player, List<string> items)
        {
            List<StatPackage> attacks = new List<StatPackage>();
            // first attack
            int dmg = (int)(10 + 0.2 * player.Strength);
            attacks.Add(new StatPackage(DmgType.Physical, dmg, "Atakujesz wlocznia! " + dmg + " dmg [fizyczne]"));
            // additional attacks
            int chance = player.Precision;
            while (chance >= 100)
            {
                attacks.Add(new StatPackage(DmgType.Physical, dmg, "Udaje ci sie zadac dodatkowe uderzenie! " + dmg + " dmg [fizyczne]"));
                chance -= 100;
            }
            if (Index.RNG(0, 100) < chance) attacks.Add(new StatPackage(DmgType.Physical, dmg, "Udaje ci sie zadac dodatkowe uderzenie! " + dmg + " dmg [fizyczne]"));
            return attacks;
        }
    }
}
