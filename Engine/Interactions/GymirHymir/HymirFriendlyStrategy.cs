using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    // friendly Hymir strategy - get bonus xp

    [Serializable]
    class HymirFriendlyStrategy : IHymirStrategy
    {
        public bool Execute(GameSession parentSession, bool complete)
        {
            if(complete)
            {
                parentSession.SendText("\n?Witaj ponownie! Przyjemna dzisiaj pogoda, nieprawdaz?");
            }
            else
            {
                parentSession.SendText("\nWitaj. Slyszalem juz o tobie i o twojej pomocy dla mojego brata Gymira - koniecznie wejdz do srodka, musze ci podziekowac!");
                parentSession.SendText("Mowia, ze woda z tej zakletej fiolki przynosi wielka madrosc. To ostatnia, jaka mi zostala, wiec chcialbym podarowac ja tobie.");
                parentSession.UpdateStat(7, 400); // + 400 xp
            }
            return true; // executing this strategy means HymirEncounter is now complete
        }
    }
}
