using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.ItemFactories
{
    interface ItemFactory
    {
        // interface for all item factories
        Item CreateAnyItem(GameSession parentSession);
        Item CreateNonMagicItem(GameSession parentSession);
        Item CreateNonWeaponItem(GameSession parentSession);
    }
}
