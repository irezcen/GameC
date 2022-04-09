using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    public interface InteractionFactory
    {
        List<Interaction> CreateInteractionsGroup(GameSession parentSession);
    }
}
