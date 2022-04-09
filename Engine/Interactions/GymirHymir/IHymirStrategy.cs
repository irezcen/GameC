using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    interface IHymirStrategy
    {
        bool Execute(GameSession ses, bool Complete);
    }
}
