using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Game.Engine.Interactions
{
    [Serializable]
    public abstract class Interaction : DisplayItem
    {
        protected GameSession parentSession;
        public bool Enterable { get; protected set; } = true; // display: can you enter this place?
        public bool Complete { get; protected set; } = false; // has this interaction been completed?
        // for quests, changing this property is mandatory and will affect the game
        // for all other interactions, it doesn't do anything, but you can use it for your own utility purposes
        // you can also consider removing an interaction after it has been completed (optional)

        public Interaction(GameSession ses)
        {
            parentSession = ses;
        }
        public override Image GetImage()
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(("Assets/Interactions/" + Name + ".png"), UriKind.Relative));
            img.Name = Name;
            return img;
        }

        // every interaction has to know how to run itself
        public abstract void Run();
    }
}
