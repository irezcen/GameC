using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    [Serializable]
    class GymirInitialState : GymirState
    {
        private int payment = 0;
        public override void RunContent(GameSession parentSession, GymirEncounter myself, HymirEncounter myBrother)
        {
            parentSession.SendText("\nWitaj! Nazywam sie Gymir i akurat szukalem kogos do pomocy przy rabaniu drzewa. Co ty na to?");
            // get player choice
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Jasne, nie ma problemu!", "Wszystko w zyciu ma swoja cene.", "Czy ja wygladam ci na drwala?" });
            switch (choice)
            {
                case 0:
                    payment = 0;
                    ChopWood(parentSession, myself, myBrother);
                    break;
                case 1:
                    parentSession.SendText("Ech, nie mam zbyt wiele pieniedzy... czy wystarczy ci 15 sztuk zlota?");
                    int choice2 = parentSession.GetListBoxChoice(new List<string>() { "Niech bedzie.", "Wybacz, ale to zbyt malo." });
                    if (choice2 == 0)
                    {
                        payment = 15;
                        ChopWood(parentSession, myself, myBrother);
                    }
                    else parentSession.SendText("Ta dzisiejsza mlodziez... w takim razie idz sobie!");
                    break;
                default:
                    parentSession.SendText("Nie, wygladasz mi na bezuzytecznego lenia. Precz stad!");
                    break;
            }
        }

        private void ChopWood(GameSession parentSession, GymirEncounter myself, HymirEncounter myBrother)
        {
            parentSession.SendText("Wspaniale! Mozesz uzyc mojego topora, ktory lezy w szopie.");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Spedz nastepna godzine na rabaniu drzewa", "Poczekaj az Gymir sie oddali i ucieknij z jego toporem" });
            if (choice == 0)
            {
                if (payment == 0)
                {
                    parentSession.SendText("Jestem naprawde wdzieczny za twoja pomoc! Powinienes poznac mojego brata Hymira. To bardzo mila osoba, zupelnie jak ty.");
                    myBrother.Strategy = new HymirFriendlyStrategy(); // Hymir will hear about this and he will like you now
                    myself.ChangeState(new GymirCompleteState(), true); // this interaction is now complete
                }
                else
                {
                    parentSession.SendText("W porzadku, oto twoja zaplata.");
                    parentSession.UpdateStat(8, payment); // +15 gold
                    myself.ChangeState(new GymirNoMoneyState()); // this interaction is still not complete, but the player can return here
                }    
            }
            else
            {
                parentSession.SendText("Chwila moment, dokad sie wybierasz z moim toporem? WRACAJ TU!");
                parentSession.AddThisItem(Index.ProduceSpecificItem("item0009")); //gymir's axe
                myBrother.Strategy = new HymirHostileStrategy(); // Hymir will hear about this and he will hate you now
                myself.ChangeState(new GymirHostileState(), true); // this interaction is now complete, but Gymir will no longer let you work here
            }
        }

    }
}
