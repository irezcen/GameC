using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using Game.Engine;

namespace Game.Display
{
    // utility class - prepare display details for Interaction objects
    class InteractionScene
    {
        protected GamePage parentPage;
        protected Interaction interaction;
        protected Image imgSetup;
        public InteractionScene(Interaction inter, GamePage parent)
        {
            interaction = inter;
            parentPage = parent;
        }
        public virtual void SetupDisplay()
        { 
            imgSetup = interaction.GetImage();
            imgSetup.Stretch = Stretch.Fill;
            parentPage.PageGrid.Children.Add(imgSetup);
            Grid.SetColumn(imgSetup, 0);
            Grid.SetRow(imgSetup, 0);
            Grid.SetRowSpan(imgSetup, 2);
        }
        public virtual void EndDisplay()
        {
            if(imgSetup != null) parentPage.PageGrid.Children.Remove(imgSetup);
        }

    }
}
