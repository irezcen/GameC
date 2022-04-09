using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine
{
    // enum with damage types
    // usage: DmgType.Cut, Dmg.Type.Crush, etc.
    // you can also use DmgTest.Physical and DmgTest.Magic methods below to test for all physical/magic dmg types at the same time 
    public enum DmgType
    {
        // physical 
        Physical,
        // magic
        Fire, 
        Air,
        Water,
        Earth,
        Psycho,
        // others
        Poison, 
        Other
    }

    public class DmgTest
    {
        // utility class for building monsters and skills
        public static bool Physical(DmgType dmg)
        {
            if (dmg == DmgType.Physical) return true;
            else return false;
        }
        public static bool Magic(DmgType dmg)
        {
            if (dmg == DmgType.Fire || dmg == DmgType.Water || dmg == DmgType.Air || dmg == DmgType.Earth || dmg == DmgType.Psycho) return true;
            else return false;
        }

    }

}
