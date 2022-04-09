using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine
{
    // monsters and players are subjects
    // nothing important happens here, just a bunch of properties are defined
    [Serializable]
    public abstract class Subject : DisplayItem
    {
        protected int health, strength, armor, precision, magicPower, stamina;
        public virtual int Health
        {
            get { return health; }
            set
            {
                if (value < 0) health = 0;
                else health = value;
                // if (health == 0)  //przegrana
            }
        }
        public virtual int Strength
        {
            get { return strength; }
            set
            {
                if (value < 0) strength = 0;
                else strength = value;
            }
        }
        public virtual int Armor
        {
            get { return armor; }
            set
            {
                if (value < 0) armor = 0;
                else armor = value;
            }
        }
        public virtual int Precision
        {
            get { return precision; }
            set
            {
                if (value < 0) precision = 0;
                else precision = value;
            }
        }
        public virtual int MagicPower
        {
            get { return magicPower; }
            set
            {
                if (value < 0) magicPower = 0;
                else magicPower = value;
            }
        }
        public virtual int Stamina
        {
            get { return stamina; }
            set
            {
                if (value < 0) stamina = 0;
                else stamina = value;
            }
        }
    }
}
