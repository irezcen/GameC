using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Spider : Monster
    {
        public Spider()
        {
            Health = 50;
            Strength = 15;
            Armor = 5;
            Precision = 60;
            MagicPower = 0;
            Stamina = 70;
            XPValue = 35;
            Name = "monster0003";
            BattleGreetings = null;
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 50)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Physical, 15 + Strength, "Pajak atakuje ugryzieniem! (" + (15 + Strength) + " dmg [fizyczne])") };
            }

            if (Stamina > 20 && Stamina <= 50)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Physical, 10 + Strength, "Pajak atakuje zadlem! (" + (5 + Strength) + " dmg [fizyczne])") };
            }

            if (Stamina > 0 && Stamina <= 20)
            {
                Stamina -= 5;
                return new List<StatPackage>() { new StatPackage(DmgType.Physical, 5 + Strength, "Pajak atakuje ugryzieniem! (" + (5 + Strength) + " dmg [fizyczne])") };
            }

            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Pajak nie ma sil na dalsza walke!") };
            }
        }
    }
}
