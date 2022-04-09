using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.BasicArmor
{
    [Serializable]
    class BerserkerArmor : Item
    {
        // special passive: receive physical damage bonus after losing health

        private int berserkerBonus;
        public BerserkerArmor() : base("item0007")
        {
            PublicName = "Zbroja Berserkera";
            PublicTip = "gdy stracisz X punktow zdrowia, otrzymujesz X/4 procentowego bonusu do zadawanych obrazen fizycznych w tym pojedynku";
            GoldValue = 40;
            ArMod = 20;
            berserkerBonus = 0;
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (DmgTest.Physical(pack.DamageType))
            {
                pack.HealthDmg = (100 + berserkerBonus / 4) * pack.HealthDmg / 100;
            }
            return pack;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            berserkerBonus += pack.HealthDmg;
            return pack;
        }
        public override void ResetAfterBattle()
        {
            berserkerBonus = 0;
        }
    }
}
