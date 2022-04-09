using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    [Serializable]
    abstract class GymirState
    {
        public abstract void RunContent(GameSession ses, GymirEncounter myself, HymirEncounter myBrother);
    }
}
