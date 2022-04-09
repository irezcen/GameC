using System;
using System.Collections.Generic;
using System.Windows;
using Game.Display;
using Game.Engine.Skills;

namespace Game.Engine.CharacterClasses
{
    [Serializable]
    public abstract class Player : Subject
    {
        // statistics: Health, Strength, Armor, Precision, MagicPower, Stamina, XP (hidden), Level, Gold
        public List<Skill> ListOfSkills { get; set; }
        public int LostHP { get; set; } // sum of HP lost in battles
        protected GameSession parentSession;
        protected int xp, gold;

        // public properties - used during battle by skills
        public int BattleBuffHealth { get; set; }
        public int BattleBuffStrength { get; set; }
        public int BattleBuffArmor { get; set; }
        public int BattleBuffPrecision { get; set; }
        public int BattleBuffMagicPower { get; set; }
        public int BattleBuffStamina { get; set; }

        // other public properties
        public override int Health
        {
            get
            { return health + HealthBuff + BattleBuffHealth; }
            set
            {
                if (value < 0) health = 0;
                else health = value;
                if (health == 0)
                {
                    parentSession.SoundEngine.PlaySound(Sound.SoundNames.PLAYER_DEATH, Sound.SoundType.Player);
                    parentSession.SendText("");
                    parentSession.SendText("***********************************************************************************************");
                    parentSession.SendText("Przegrana! Nacisnij dowolny klawisz, aby kontynuowac.");
                    parentSession.GetKeyResponse();
                    parentSession.EndGame();
                    //health = 200; // cheat
                }
            }
        }
        public override int Strength
        {
            get
            { return strength + StrengthBuff + BattleBuffStrength; }
            set
            {
                if (value < 0) strength = 0;
                else strength = value;
            }
        }
        public override int Armor
        {
            get
            { return armor + ArmorBuff + BattleBuffArmor; }
            set
            {
                if (value < 0) armor = 0;
                else armor = value;
            }
        }
        public override int Precision
        {
            get
            { return precision + PrecisionBuff + BattleBuffPrecision; }
            set
            {
                if (value < 0) precision = 0;
                else precision = value;
            }
        }
        public override int MagicPower
        {
            get
            { return magicPower + MagicPowerBuff + BattleBuffMagicPower; }
            set
            {
                if (value < 0) magicPower = 0;
                else magicPower = value;
            }
        }
        public override int Stamina
        {
            get { return stamina + StaminaBuff + BattleBuffStamina; }
            set
            {
                if (value < 0) stamina = 0;
                else stamina = value;
            }
        }
        public int XP
        {
            get { return xp; }
            set
            {
                xp = value;
                while (Level < LevelBasedOnXP())
                {
                    LevelUp();
                }
            }
        }
        public int Level { get; protected set; }
        public int Gold
        {
            get { return gold; }
            set
            {
                if (value < 0) gold = 0;
                else gold = value;
            }
        }
        public string ClassName { get; protected set; }

        // core stats and temporary item buffs are stored separately so that they can be updated easily
        public int HealthBuff { get; set; }
        public int StrengthBuff { get; set; }
        public int ArmorBuff { get; set; }
        public int PrecisionBuff { get; set; }
        public int MagicPowerBuff { get; set; }
        public int StaminaBuff { get; set; }


        // methods
        protected Player(GameSession ses) // for derived classes
        {
            parentSession = ses;

            // this has to be the first skill 
            // if you need to change this, change SkillForgetInteraction as well
            ListOfSkills = new List<Skill>() { new RunAway() };

            Name = "player";
            Level = 1;
        }
        private int LevelBasedOnXP()
        {
            // how much xp do you need to level up?
            // 100xp for level 2
            // 100+141 = 241xp for level 3 (this is total xp so you you begin level 2 with 100xp already)
            // 100+141+173 = 414xp for level 4 etc.
            int lvl = 1;
            int x = 0;
            while (x <= XP)
            {
                x += (int)(100 * Math.Sqrt(lvl));
                lvl++;
            }
            return lvl - 1;
        }
        public void ResetBuffs()
        {
            // convenience method that resets all item buffs
            HealthBuff = 0;
            StrengthBuff = 0;
            ArmorBuff = 0;
            PrecisionBuff = 0;
            MagicPowerBuff = 0;
            StaminaBuff = 0;
        }
        public void ResetBattleBuffs()
        {
            // similar to ResetBuffs, but for battle buffs
            BattleBuffHealth = 0;
            BattleBuffStrength = 0;
            BattleBuffArmor = 0;
            BattleBuffPrecision = 0;
            BattleBuffMagicPower = 0;
            BattleBuffStamina = 0;
        }
        public virtual List<StatPackage> React(List<StatPackage> packs)
        {
            // receive the result of your opponent's action
            List<StatPackage> ans = new List<StatPackage>();
            foreach (StatPackage pack in packs)
            {
                Health = Health - HealthBuff - BattleBuffHealth - 1 * (100 * pack.HealthDmg) / (100 + Armor);
                Strength = Strength - StrengthBuff - BattleBuffStrength - pack.StrengthDmg;
                Armor = Armor - ArmorBuff - BattleBuffArmor - pack.ArmorDmg;
                Precision = Precision - PrecisionBuff - BattleBuffPrecision - pack.PrecisionDmg;
                MagicPower = MagicPower - MagicPowerBuff - BattleBuffMagicPower - pack.MagicPowerDmg;
                pack.HealthDmg = (100 * pack.HealthDmg) / (100 + Armor);
                ans.Add(pack);
            }
            return ans;
        }
        protected virtual void LevelUp()
        {
            // override this for specific character classes, which may have easier time learning one stat vs another... 
            Level++;
            parentSession.SendText("\n");
            parentSession.SendColorText("Nowy poziom! Poziom: " + Level, "yellow");
            List<string> validInputs = new List<string>() { "1", "2", "3", "4", "5" }; // only accept these inputs
            parentSession.SendColorText("Wybierz statystyke do ulepszenia: +10 Zdrowia (nacisnij 1), +10 Sily (nacisnij 2), +5 Precyzji (nacisnij 3), +10 Mocy Magicznej (nacisnij 4), +10 Energii (nacisnij 5)", "yellow");
            string key = parentSession.GetValidKeyResponse(validInputs).Item1;
            // don't make changes directly, ask GameSession to do it right
            if (key == "1") parentSession.UpdateStat(1, 10);
            else if (key == "2") parentSession.UpdateStat(2, 10);
            else if (key == "3") parentSession.UpdateStat(4, 5);
            else if (key == "4") parentSession.UpdateStat(5, 10);
            else if (key == "5") parentSession.UpdateStat(6, 10);
        }
        public virtual void LearnNewSkill(List<Skill> learningSkills)
        {
            // learn a new skill from the list (maximum three choices)
            if (learningSkills.Count > 2)
            {
                parentSession.SendColorText("Wybierz zaklecie do nauczenia sie:", "yellow");
                parentSession.SendColorText(learningSkills[0] + " (nacisnij 1)", "yellow");
                parentSession.SendColorText(learningSkills[1] + " (nacisnij 2)", "yellow");
                parentSession.SendColorText(learningSkills[2] + " (nacisnij 3)", "yellow");
                parentSession.SendColorText("Dziekuje, tym razem nie skorzystam (nacisnij 4)", "yellow");
                string key = parentSession.GetValidKeyResponse(new List<string>() { "1", "2", "3", "4" }).Item1;
                if (key == "1") Learn(learningSkills[0]);
                else if (key == "2") Learn(learningSkills[1]);
                else if (key == "3") Learn(learningSkills[2]);
            }
            else if (learningSkills.Count > 1)
            {
                parentSession.SendColorText("Wybierz zaklecie do nauczenia sie:", "yellow");
                parentSession.SendColorText(learningSkills[0] + " (nacisnij 1)", "yellow");
                parentSession.SendColorText(learningSkills[1] + " (nacisnij 2)", "yellow");
                parentSession.SendColorText("Dziekuje, tym razem nie skorzystam (nacisnij 3)", "yellow");
                string key = parentSession.GetValidKeyResponse(new List<string>() { "1", "2", "3" }).Item1;
                if (key == "1") Learn(learningSkills[0]);
                else if (key == "2") Learn(learningSkills[1]);
            }
            else if (learningSkills.Count > 0)
            {
                parentSession.SendColorText("Wybierz zaklecie do nauczenia sie:", "yellow");
                parentSession.SendColorText(learningSkills[0] + " (nacisnij 1)", "yellow");
                parentSession.SendColorText("Dziekuje, tym razem nie skorzystam (nacisnij 2)", "yellow");
                string key = parentSession.GetValidKeyResponse(new List<string>() { "1", "2" }).Item1;
                if (key == "1") Learn(learningSkills[0]);
            }
        }
        public virtual void Learn(Skill skill)
        {
            // a method that helps LearnNewSkill
            ListOfSkills.Add(skill);
        }
        public List<Skill> ListAvailableSkills(bool canRunAway = true)
        {
            // return list of currently available skills (based on items and stamina)
            // to be used during battles
            List<Skill> tmp = new List<Skill>();
            foreach (Skill skill in ListOfSkills)
            {
                if (Stamina >= skill.StaminaCost && parentSession.TestForItemClass(skill.ReqItem))
                {
                    if (skill is Spell && (skill as Spell).SpecialItem != "none" && !parentSession.TestForItem((skill as Spell).SpecialItem)) continue;
                    tmp.Add(skill);
                }
            }
            if (tmp.Count > 1 && !canRunAway) tmp.RemoveAt(0);
            return tmp;
        }
    }
}
