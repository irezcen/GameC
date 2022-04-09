using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Rat : Monster
    {
        // example monster: rat
        public Rat()
        {
            Health = 35;
            Strength = 10;
            Armor = 0;
            Precision = 50;
            MagicPower = 0;
            Stamina = 50;
            XPValue = 25;
            Name = "monster0001";
            BattleGreetings = null; // rat doesn't say anything
        }
        public override List<StatPackage> BattleMove()
        {
            if(Stamina>0)
            {
                Stamina -= 10;
                // a simple bite move dealing 5 + (rat strength statistic) damage
                return new List<StatPackage>() { new StatPackage(DmgType.Physical, 5 + Strength, "Szczur atakuje ugryzieniem! ("+ (5 + Strength) +" dmg [fizyczne])") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Szczur nie ma sil na dalsza walke!") };
            }
        }
    }
}
