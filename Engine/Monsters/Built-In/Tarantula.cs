using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Tarantula : Monster
    {
        public Tarantula()
        {
            Health = 75;
            Strength = 30;
            Armor = 10;
            Precision = 120;
            MagicPower = 50;
            Stamina = 100;
            XPValue = 70;
            Name = "monster0004";
            BattleGreetings = "Widze cie, moja mala muszko!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Health > 40)
            {
                if (Stamina > 70)
                {
                    Stamina -= 10;
                    return new List<StatPackage>() { new StatPackage(DmgType.Physical, 20 + Strength, "Tarantula szarzuje naprzod! (" + (20 + Strength) + " dmg [fizyczne])") };
                }

                if (Stamina > 0 && Stamina <= 70)
                {
                    Stamina -= 10;
                    return new List<StatPackage>() { new StatPackage(DmgType.Poison, 15 + MagicPower, "Jad tarantuli zadaje ci obrazenia! (" + (15 + MagicPower) + " dmg [trucizna])") };
                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Tarantula nie ma sil na dalsza walke!") };
                }
            }
            else
            {
                if (Stamina > 0)
                {
                    Stamina -= 5;
                    return new List<StatPackage>() { new StatPackage(DmgType.Physical, 10 + Strength, "Tarantula atakuje ugryzieniem! (" + (10 + Strength) + " dmg [fizyczne])") };
                }

                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Tarantula nie ma sil na dalsza walke!") };
                }
            }
        }
    }
}
