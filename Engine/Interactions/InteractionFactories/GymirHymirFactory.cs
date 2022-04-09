using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class GymirHymirFactory : InteractionFactory
    {
        private int i = 0;
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            if (i < 5)
            {
                // Gymir and Hymir must always appear together in the game world
                i++;
                HymirEncounter hymir = new HymirEncounter(parentSession);
                GymirEncounter gymir = new GymirEncounter(parentSession, hymir);
                return new List<Interaction>() { hymir, gymir };
            }
            else return new List<Interaction>();
        }
    }
}
