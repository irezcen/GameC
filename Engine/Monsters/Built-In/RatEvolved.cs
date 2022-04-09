using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class RatEvolved : Monster
    {
        // evolved rat - this time also with venom
        public RatEvolved()
        {
            Health = 60;
            Strength = 15;
            Armor = 0;
            Precision = 50;
            MagicPower = 0;
            Stamina = 70;
            XPValue = 40;
            Name = "monster0002";
            BattleGreetings = "Powracam... w jadowitej wersji!"; // this rat actually has something to say
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>()
                { 
                    // the same bite move as in Rat, but also with 15 poison damage
                    new StatPackage(DmgType.Physical, 5 + Strength, "Szczur atakuje ugryzieniem! "+ (5 + Strength) +" dmg [fizyczne]"),
                    new StatPackage(DmgType.Poison, 15, "Jad szczura piecze w twoich zylach! (15 dmg [trucizna])")
                };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Szczur nie ma sil na dalsza walke!") };
            }
        }
    }
}
