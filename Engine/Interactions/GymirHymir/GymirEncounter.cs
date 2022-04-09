using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    // meet with an old troll named Gymir
    // Gymir has also a brother - Hymir

    [Serializable]
    class GymirEncounter : PlayerInteraction
    {
        private GymirState currentState; // current state of this interaction (design pattern)
        private HymirEncounter myBrother; // store reference to Hymir    
        public GymirEncounter(GameSession ses, HymirEncounter myBrother) : base(ses)
        {
            parentSession = ses;
            Name = "interaction0003";
            this.myBrother = myBrother; // set reference to Hymir
            currentState = new GymirInitialState();
        }
        protected override void RunContent()
        {
            currentState.RunContent(parentSession, this, myBrother);
        }
        public void ChangeState(GymirState newState, bool isCompleted = false)
        {
            currentState = newState;
            if (isCompleted) Complete = true; // while changing state, we may also want to set this property
        }
    }
}
