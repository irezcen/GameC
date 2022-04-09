using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    // hostile Hymir strategy - you will fight Hymir's pet (which is a randomly generated monster)

    [Serializable]
    class HymirHostileStrategy : IHymirStrategy
    {
        public bool Execute(GameSession parentSession, bool complete)
        {
            parentSession.SendText("\nPatrzcie jaka podejrzana twarz sie tutaj kreci... slyszalem juz o twojej kradziezy topora od mojego brata Gymira. Teraz dostaniesz za swoje.");
            parentSession.SendText("Dalej Charlie, bierz go!");
            parentSession.FightRandomMonster();
            return true; // executing this strategy means HymirEncounter is now complete
        }
    }
}
