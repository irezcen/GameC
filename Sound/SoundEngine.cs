using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Sound.Players;

namespace Game.Sound
{
    /// <summary>
    /// Handles sound implementation
    /// Contains two players: one for background music and one for effects
    /// </summary>
    public class SoundEngine
    {
        private BasicSoundPlayer backgroundPlayer;
        private BasicSoundPlayer soundPlayer;
        private SoundContext soundContext;

        public SoundEngine(SoundContext soundContext)
        {
            this.soundContext = soundContext;
            this.backgroundPlayer = new BasicSoundPlayer();
            this.soundPlayer = new BasicSoundPlayer();
        }

        // update game volume for all sound players
        public void UpdateVolume(double volume)
        {
            backgroundPlayer.Volume = volume / 100.0;
            soundPlayer.Volume = volume / 100.0;
        }

        /// <summary>
        /// Plays background music for specified location in game navigation 
        /// by current game sound context (check SoundEngine.GetBackgroundMusic())
        /// </summary>
        public void PlayBackgroundMusic()
        {
            backgroundPlayer.Open(GetBackgroundMusic());
            backgroundPlayer.PlayLooped();
        }

        /// <summary>
        /// Stops background music player gently.
        /// Use it while entering another game music context eg. Battle, GamePage, MenuPage.
        /// </summary>
        public void StopBackgroundMusic()
        {
            backgroundPlayer.Stop();
        }

        /// <summary>
        /// Force stops background music player. 
        /// Use for eg. while ending app etc.
        /// </summary>
        public void ForceStopBackgroundMusic()
        {
            backgroundPlayer.ForceStop();
        }

        /// <summary>
        /// Pause background music
        /// Use it while entering new context with probability of comming back to previous. 
        /// </summary>
        public void PauseBackgroundMusic()
        {
            backgroundPlayer.Pause();
        }

        /// <summary>
        /// Resume paused background music. 
        /// </summary>
        public void ResumeBackgroundMusic()
        {
            backgroundPlayer.Play();
        }

        /// <summary>
        /// Getting background music Sound obj. based on current game context. 
        /// </summary>
        /// <returns>Sound type music background object.</returns>
        private Sound GetBackgroundMusic()
        {
            return SoundLibrary.Sounds.Find(t => t.SoundType == SoundType.Background && t.SoundContext == soundContext);
        }

        /// <summary>
        /// Plays sound by its name. 
        /// </summary>
        /// <param name="soundName">Name of sound to play</param>
        public void PlaySound(string soundName)
        {
            PlaySound(SoundLibrary.Sounds.Find(t => t.SoundName == soundName));
        }

        /// <summary>
        /// Plays sound by its name and sound type. 
        /// </summary>
        /// <param name="soundName">Name of sound to play. Must not be null, otherwise doesn't play anything.</param>
        /// <param name="soundType">Type of sound. Must not be null, otherwise doesn't play anything.</param>
        public void PlaySound(string soundName, SoundType soundType)
        {
            PlaySound(SoundLibrary.Sounds.Find(t => t.SoundName == soundName && t.SoundType == soundType));
        }

        /// <summary>
        /// Plays sound using embedded self-managed playlist. 
        /// </summary>
        /// <param name="soundName">Name of sound to play. Must not be null, otherwise doesn't play anything.</param>
        /// <param name="soundType">Type of sound. Must not be null, otherwise doesn't play anything.</param>
        public void WaitAndPlay(string soundName, SoundType soundType)
        {
            soundPlayer.WaitAndPlay(SoundLibrary.Sounds.Find(t => t.SoundName == soundName && t.SoundType == soundType));
        }

        /// <summary>
        /// Play given sound.
        /// </summary>
        /// <param name="s">Sound type object.</param>
        private void PlaySound(Sound s)
        {
            if (s != null)
            {
                soundPlayer.Open(s);
                soundPlayer.Play();
            }
        }

        /// <summary>
        /// Stops all actively running sound players. 
        /// </summary>
        public void StopAllPlayers()
        {
            backgroundPlayer.Stop();
            soundPlayer.Stop();
        }

        /// <summary>
        /// Force stops all actively running sound players.
        /// </summary>
        public void ForceStopAllPlayers()
        {
            backgroundPlayer.ForceStop();
            soundPlayer.ForceStop();
        }
    }

    
    
}
