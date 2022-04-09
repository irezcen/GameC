using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items
{
    // a class representing a generic item
    [Serializable]
    public abstract class Item : DisplayItem
    {
        // statistic buffs
        public int HpMod { get; protected set; }
        public int StrMod { get; protected set; }
        public int ArMod { get; protected set; }
        public int PrMod { get; protected set; }
        public int MgcMod { get; protected set; }
        public int StaMod { get; protected set; }
        public string PublicName { get; protected set; } // the name to be displayed in game
        public string PublicTip { get; protected set; } // short description of special bonuses
        public int GoldValue { get; protected set; } 
        public virtual bool IsAxe { get; protected set; } = false;
        public virtual bool IsSword { get; protected set; } = false;
        public virtual bool IsSpear { get; protected set; } = false;
        public virtual bool IsStaff { get; protected set; } = false;
        public Item(string name)
        {
            Name = name;
            HpMod = 0;
        }
        public override Image GetImage()
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(("Assets/Items/" + Name + ".png"), UriKind.Relative));
            img.Name = Name;
            return img;
        }
        public virtual void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            // by default, simply add item statistics to player statistics
            // can be overriden to include more complicated item mechanics (conditionals, randomness... )
            // note: otherItems are specified here by their Name property
            currentPlayer.HealthBuff += HpMod;
            currentPlayer.StrengthBuff += StrMod;
            currentPlayer.ArmorBuff += ArMod;
            currentPlayer.PrecisionBuff += PrMod;
            currentPlayer.MagicPowerBuff += MgcMod;
            currentPlayer.StaminaBuff += StaMod;
        }
        public virtual StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            // by default, do not include any specific offensive bonuses for player attacks
            return pack;
        }
        public virtual StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            // by default, do not include any specific defensive bonuses for player receiving an attack
            return pack;
        }
        public virtual void ResetAfterBattle() 
        { 
            // optional method for resetting item statistics after battle
        }

    }
}
