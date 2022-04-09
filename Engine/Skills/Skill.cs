using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
    [Serializable]
    public abstract class Skill
    {
        // a class representing a generic skill
        public string PublicName { get; protected set; } // a name to be displayed in the game
        public int StaminaCost { get; protected set; } // how much does this spell cost
        public int MinimumLevel { get; protected set; } // what level do you need to learn it
        public RequiredItem ReqItem { get; protected set; } = RequiredItem.None; 
        protected Skill(string name, int stamina, int minLevel) // for derived classes
        {
            PublicName = name;
            StaminaCost = stamina;
            MinimumLevel = minLevel;
        }
        public override string ToString()
        {
            return "[" + StaminaCost + " punktow energii] " + PublicName;
        }
        public abstract List<StatPackage> BattleMove(Player player, List<string> items);

    }
}
