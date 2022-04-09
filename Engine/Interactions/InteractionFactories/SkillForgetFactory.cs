using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class SkillForgetFactory : InteractionFactory
    {
        public List<Interaction> CreateInteractionsGroup(GameSession ses)
        {
            return new List<Interaction>() { new SkillForgetInteraction(ses) };
        }
    }
}
