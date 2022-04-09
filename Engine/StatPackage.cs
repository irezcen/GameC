using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine
{
    // wrapper class for a bunch of statistics
    // meant to be used during battles and interactions

    // for damage types, see file DmgType.cs
    

    public class StatPackage
    {
        public int HealthDmg { get; set; }
        public int StrengthDmg { get; set; }
        public int ArmorDmg { get; set; }
        public int PrecisionDmg { get; set; }
        public int MagicPowerDmg { get; set; }
        public DmgType DamageType { get; set; }
        public string CustomText { get; set; }
        public StatPackage(DmgType dmgType)
        {
            DamageType = dmgType;
        }
        public StatPackage(DmgType dmgType, int hp)
        {
            DamageType = dmgType;
            HealthDmg = hp;
        }
        public StatPackage(DmgType dmgType, int hp, string text)
        {
            DamageType = dmgType;
            HealthDmg = hp;
            CustomText = text;
        }
        public StatPackage(DmgType dmgType, int hp, int strength, int armor, int precision, int magic, string text)
        {
            DamageType = dmgType;
            HealthDmg = hp;
            StrengthDmg = strength;
            ArmorDmg = armor;
            PrecisionDmg = precision;
            MagicPowerDmg = magic;
            CustomText = text;
        }

        public StatPackage(string text)
        {
            DamageType = DmgType.Other;
            CustomText = text;
        }

        public StatPackage Copy()
        {
            return new StatPackage(this.DamageType, this.HealthDmg, this.StrengthDmg, this.ArmorDmg, this.PrecisionDmg,
                this.MagicPowerDmg, this.CustomText);
        }
        
    }
}
