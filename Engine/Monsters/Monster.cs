using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Game.Engine.Monsters
{
    [Serializable]
    public abstract class Monster : Subject
    {
        // abstract class representing a monster
        public int XPValue { get; protected set; }
        public string BattleGreetings { get; protected set; } // what the monster says when it attacks the player for the first time
        public abstract List<StatPackage> BattleMove(); // perform an action in the battle
        public virtual List<StatPackage> React(List<StatPackage> packs) // receive the result of your opponent's action
        {
            List<StatPackage> ans = new List<StatPackage>();
            foreach (StatPackage pack in packs)
            {
                Health -= pack.HealthDmg;
                Strength -= pack.StrengthDmg;
                Armor -= pack.ArmorDmg;
                Precision -= pack.PrecisionDmg;
                MagicPower -= pack.MagicPowerDmg;
                ans.Add(pack); // if your monster has some resistances, modify pack elements before adding them (example in VampireKnight)
            }
            return ans; // return effective damage
        }
        public override Image GetImage()
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(("Assets/Monsters/" + Name + ".png"), UriKind.Relative));
            img.Name = Name;
            return img;
        }

    }
}
