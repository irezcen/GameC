using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    [Serializable]
    class GymirCompleteState : GymirState
    {
        public override void RunContent(GameSession parentSession, GymirEncounter myself, HymirEncounter myBrother)
        {
            parentSession.SendText("\nAch, to ty. Milo cie tu znowu widziec, ale chwilowo nie mam dla ciebie zadnej pracy do zaoferowania.");
            return;
        }
    }
}
