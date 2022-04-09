using System;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Game.Display;
using System.Collections.Generic;
using Game.Sound;

namespace Game.Engine
{
    // contains all information that has to be saved (and then loaded) in order to restore a game state

    partial class GameSession
    {
        public void SaveGame(string filename)
        {
            try 
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, this);
                stream.Close();
            }
            catch(Exception e)
            {
                SendText(e.Message);
            }
        }

        public void ReInitialize(GamePage page)
        {
            parentPage = page;
            timer = new System.Windows.Forms.Timer();
            timerPlayer = new System.Windows.Forms.Timer();
            SoundEngine = parentPage.soundEngine; 
            ChildSoundEngines = new List<SoundEngine>();
            InitializeMapDisplay(-1); // don't move player - this will be handled seprately
            RefreshMonstersDisplay();
            RefreshItems();
            RefreshStats();
            UpdateLocations();
        }

    }
       
}
