using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class VampireKnight : Monster
    {
        public VampireKnight()
        {
            Health = 300;
            Strength = 30;
            Armor = 90;
            Precision = 80;
            Stamina = 500;
            XPValue = 150;
            Name = "monster0006";
            BattleGreetings = "Witam...";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                int chance = Index.RNG(0, 10);
                if (chance < 5)
                {
                    Stamina -= 25;
                    return new List<StatPackage>() { new StatPackage(DmgType.Physical, 50 + Strength, "Wampir atakuje cie swoim mieczem (" + (50 + Strength) + " dmg [fizyczne])") };
                }
                else
                {
                    Stamina -= 30;
                    health += 30;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Other, 70 + Strength, "Wampir wysysa twoja krew (" + (70 + Strength) + " dmg [inne]) i odzyskuje 30 punktow zdrowia!"), 
                    };
                }
            }
            else
            {
                stamina += 20;
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Wampirowi brakuje sil, musi przez chwile odpoczac.") };
            }
        }

        public override List<StatPackage> React(List<StatPackage> packs)
        {
            List<StatPackage> ans = new List<StatPackage>();
            foreach (StatPackage pack in packs)
            {
                pack.ArmorDmg = pack.ArmorDmg / 2; // vampire knight has partial resistance to armor debuffs
                Health -= pack.HealthDmg;
                Strength -= pack.StrengthDmg;
                Armor -= pack.ArmorDmg;
                Precision -= pack.PrecisionDmg;
                MagicPower -= pack.MagicPowerDmg;
                ans.Add(pack); 
            }
            return ans;
        }
    }
}
