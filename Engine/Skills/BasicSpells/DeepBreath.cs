using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;


namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class DeepBreath : Spell
    {
        // deep breath: take a deep breath to regenerate some stamina
        public DeepBreath() : base("Deep Breath", 0, 1)
        {
            PublicName = "Gleboki wdech: zregeneruj 30 punktow energii";
        }
        public override List<StatPackage> BattleMove(Player player, List<string> items)
        {
            player.BattleBuffStamina += 30; // use BattleBuff[something] for skills which need to buff statistics
            StatPackage response = new StatPackage("Bierzesz gleboki wdech i regenerujesz 30 punktow energii!");
            return new List<StatPackage>() { response }; 
        }
    }
}
