using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    // neutral Hymir strategy - not much happens here

    [Serializable]
    class HymirNeutralStrategy : IHymirStrategy
    {
        public bool Execute(GameSession parentSession, bool complete)
        {
            parentSession.SendText("\nWitaj, przechodniu. Nie masz przypadkiem jakichs wiesci o moim bracie Gymirze? Juz dawno go nie widzialem.");
            parentSession.SendText("Tak czy inaczej, jestem dosyc zajety, wiec wybacz, ale musze wracac do pracy.");
            return false; // executing this strategy means HymirEncounter is still not complete
        }
    }
}
