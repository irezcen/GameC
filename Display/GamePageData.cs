using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Game.Engine.Items;
using Game.Engine;

namespace Game.Display
{
    public partial class GamePage : Page
    {
        // Windows.Page is non-serializable, so we have to split the class data here
        [Serializable]
        internal class PageData
        {
            public int prevX, prevY;
            public string lastMove;
            [NonSerialized] public GamePage parent;
            private List<Item> items;
            private List<int> itemImagePositions;
            public PageData(GamePage parent)
            {
                this.parent = parent;
                items = new List<Item>();
                itemImagePositions = new List<int>();
            }
            public void CountItems()
            {
                items = new List<Item>();
                itemImagePositions = new List<int>();
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 6; y++)
                    {
                        Image tmp = parent.GetImageFromGrid(x, y);
                        if (tmp != null)
                        {
                            items.Add(Index.ProduceSpecificItem(tmp.Name));
                            itemImagePositions.Add(5 * y + x);
                        }
                    }
                }
            }
            public void RestoreItems()
            {
                for (int i = 0; i < itemImagePositions.Count; i++)
                {
                    parent.currentSession.InsertItemToGrid(items[i], itemImagePositions[i]);
                }   
            }
        }
    }
}
