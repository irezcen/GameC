using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using Game.Engine.Interactions;

namespace Game.Display
{
    // utility class - prepare display details for ImageInteraction objects
    public class ImageInteractionScene
    {
        protected GamePage parentPage;
        protected Image imgSetup;
        public ImageInteractionScene(GamePage parent, Image img)
        {
            imgSetup = img;
            parentPage = parent;
        }
        public virtual void SetupDisplay()
        { 
            // initialize display elements
            if(imgSetup != null)
            {
                imgSetup.Stretch = Stretch.Fill;
                parentPage.PageGrid.Children.Add(imgSetup);
                Grid.SetColumn(imgSetup, 0);
                Grid.SetRow(imgSetup, 0);
                Grid.SetRowSpan(imgSetup, 2);
            }
        }
        public virtual void EndDisplay()
        {
            // clean up
            if(imgSetup != null) parentPage.PageGrid.Children.Remove(imgSetup);
        }

    }
}
