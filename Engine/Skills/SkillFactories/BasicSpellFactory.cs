using System;
using System.Collections.Generic;
using Game.Engine.Skills.BasicSkills;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class BasicSpellFactory : SkillFactory
    {  
        // this factory produces skills from BasicSpells directory
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            List<Skill> tmp = new List<Skill>();
            FireArrow s1 = new FireArrow();
            WindGust s2 = new WindGust();
            DeepBreath s3 = new DeepBreath();
            ChargeGSArmor s4 = new ChargeGSArmor();
            if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
            if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
            if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
            if (s4.MinimumLevel <= player.Level) tmp.Add(s4);
            foreach (Skill skill in playerSkills) // don't offer skills which the player knows already
            {
                if (skill is FireArrow) tmp.Remove(s1);
                if (skill is WindGust) tmp.Remove(s2);
                if (skill is DeepBreath) tmp.Remove(s3);
                if (skill is ChargeGSArmor) tmp.Remove(s4);
            }
            if (tmp.Count == 0) return null;
            return tmp[Index.RNG(0, tmp.Count)];
        }
    }
}
