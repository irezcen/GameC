using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    [Serializable]
    class GymirHostileState : GymirState
    {
        public override void RunContent(GameSession parentSession, GymirEncounter myself, HymirEncounter myBrother)
        {
            parentSession.SendText("\nZnowu tutaj, zlodzieju? Niech no tylko moj bol plecow troche odpusci, to wezme sie za ciebie...");
            return;
        }
    }
}
