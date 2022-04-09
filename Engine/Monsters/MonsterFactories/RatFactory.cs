using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class RatFactory : MonsterFactory
    {
        // this factory produces rats (or evolved rats)

        private int encounterNumber = 0; // how many times has this factory been used already?
        public override Monster Create()
        {
            if (encounterNumber == 0) // if this is the first time, return a Rat
            {
                encounterNumber++;
                return new Rat();
            }
            else if (encounterNumber == 1) // if this is the second time, return a RatEvolved
            {
                encounterNumber++;
                return new RatEvolved();
            }
            else return null; // no more rats to fight
        }
        public override System.Windows.Controls.Image Hint() 
        {
            if (encounterNumber == 0) return new Rat().GetImage();
            else if (encounterNumber == 1) return new RatEvolved().GetImage();
            else return null; 
        }
    }
}
