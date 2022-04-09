using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    [Serializable]
    class GymirNoMoneyState : GymirState
    {
        public override void RunContent(GameSession parentSession, GymirEncounter myself, HymirEncounter myBrother)
        {
            parentSession.SendText("\nWitaj ponownie. Wybacz ze znowu prosze cie o pomoc, ale potrzebuje narabac jeszcze troche drewna.");
            // get player choice
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Jasne, nie ma problemu!", "Wszystko w zyciu ma swoja cene.", "Czy ja wygladam ci na drwala?" });
            switch (choice)
            {
                case 0:
                    ChopWood(parentSession, myself, myBrother);
                    break;
                case 1:
                    parentSession.SendText("Wstyd przyznac, ale tym razem nie mam juz czym ci zaplacic...");
                    int choice2 = parentSession.GetListBoxChoice(new List<string>() { "Normalnie nie pracuje za darmo, ale powiedzmy ze tym razem zrobie wyjatek", "Nic z tego, nie zamierzam pracowac za darmo." });
                    if (choice2 == 0)
                    {
                        ChopWood(parentSession, myself, myBrother);
                    }
                    else parentSession.SendText("Ta dzisiejsza mlodziez... w takim razie idz sobie!");
                    break;
                default:
                    parentSession.SendText("Nie, wygladasz mi na bezuzytecznego lenia. Precz stad");
                    break;
            }
        }

        private void ChopWood(GameSession parentSession, GymirEncounter myself, HymirEncounter myBrother)
        {
            parentSession.SendText("Wspaniale! Mozesz uzyc mojego topora, ktory lezy w szopie.");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Spedz nastepna godzine na rabaniu drzewa", "Poczekaj az Gymir sie oddali i ucieknij z jego toporem" });
            if (choice == 0)
            {
                parentSession.SendText("Jestem naprawde wdzieczny za twoja pomoc! Powinienes poznac mojego brata Hymira. To bardzo mila osoba, zupelnie jak ty.");
                myBrother.Strategy = new HymirFriendlyStrategy(); // Hymir will hear about this and he will like you now
                myself.ChangeState(new GymirCompleteState(), true); // this interaction is now complete
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
