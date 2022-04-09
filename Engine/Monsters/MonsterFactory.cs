using System;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    public abstract class MonsterFactory
    {
        // interface representing monster factory
        public abstract Monster Create(); // produce next monster
        public abstract System.Windows.Controls.Image Hint(); // to update the map, also hint what monster would be produced next
        public virtual MonsterFactory Clone() // clone this factory so that there can be multiple instances in the map
        {
            return (MonsterFactory)this.MemberwiseClone();
        }
    }
}
