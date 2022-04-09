using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Media;
using System.IO;

namespace Game.Sound.Players
{
    /// <summary>
    /// Basic class for sound handling
    /// </summary>
    class BasicSoundPlayer
    {
        protected MediaPlayer mediaPlayer;
        protected bool playLooped;
        protected bool waiting;
        protected List<Sound> SoundList;

        public double Volume
        {
            get { return mediaPlayer.Volume; }
            set { mediaPlayer.Volume = value; }
        }
        public BasicSoundPlayer()
        {
            mediaPlayer = new MediaPlayer();
            playLooped = false;
            waiting = false;
            SoundList = new List<Sound>();
            mediaPlayer.Volume = 0.2;

            // allow to loop audio
            mediaPlayer.MediaEnded += new EventHandler(Player_Ended);
        }

        /// <summary>
        /// Opens given file and prepare to play it
        /// </summary>
        /// <param name="sound">Sound</param>
        public void Open(Sound sound)
        {
            if(sound != null && File.Exists(sound.FilePath.AbsolutePath))
            {
                mediaPlayer.Open(sound.FilePath);
            }
        }

        /// <summary>
        /// Plays opened file
        /// </summary>
        public void Play()
        {
            if(mediaPlayer.Source != null)
            {
                mediaPlayer.IsMuted = false;
                mediaPlayer.Play();
            }
        }

        /// <summary>
        /// Pauses the player
        /// </summary>
        public void Pause()
        {
            mediaPlayer.Pause();
        }

        /// <summary>
        /// Stops the player gently
        /// </summary>
        public void Stop()
        {
            double tempVolume = mediaPlayer.Volume;
            int msTime = 10;
            double sleepFactor = (double)msTime / 500;

            while (mediaPlayer.Volume > 0)
            {
                mediaPlayer.Volume -= sleepFactor;
                // wait to decrease volume sound slowly
                System.Threading.Thread.Sleep(msTime);
            }

            mediaPlayer.IsMuted = true;
            mediaPlayer.Stop();
            mediaPlayer.Volume = tempVolume;
        }

        /// <summary>
        /// Stops the player immediately
        /// </summary>
        public void ForceStop()
        {
            mediaPlayer.IsMuted = true;
            mediaPlayer.Stop();
            mediaPlayer.IsMuted = false;
        }

        /// <summary>
        /// Plays opened sound over and over (use it eg. for background music)
        /// </summary>
        public void PlayLooped()
        {
            playLooped = true;
            Play();
        }

        /// <summary>
        /// Adds music to playlist and plays it
        /// </summary>
        /// <param name="sound"></param>
        public void WaitAndPlay(Sound sound)
        {
            if (sound == null) return;
            SoundList.Add(sound);

            if (mediaPlayer.Source != null && mediaPlayer.NaturalDuration.HasTimeSpan && mediaPlayer.NaturalDuration.TimeSpan > mediaPlayer.Position)
            {
                waiting = true;
            }
            else
            {
                HandleWaitingPlayer();
            }
        }

        /// <summary>
        /// Handle looped and playlist based players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player_Ended(object sender, EventArgs e)
        {
            if (playLooped)
            {
                //Set the music back to the beginning
                mediaPlayer.Position = TimeSpan.Zero;
                //Play the music
                mediaPlayer.Play();
            }
            if (waiting && SoundList.Count > 0)
            {
                HandleWaitingPlayer();
            }
        }

        /// <summary>
        /// Method used to handle playlist
        /// </summary>
        private void HandleWaitingPlayer()
        {
            SoundList.RemoveAll(x => x == null);
            if (SoundList.Count == 0)
            {
                waiting = false;
                return;
            }

            Sound temp = SoundList.First();
            SoundList.RemoveAt(0);
            Open(temp);
            Play();
            if (SoundList.Count == 0)
                waiting = false;
        }

    }
}
