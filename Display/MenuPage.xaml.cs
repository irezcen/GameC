using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using Game.Sound;
using Game.Sound.Players;

namespace Game.Display
{
    /// <summary>
    /// Interactions for game menu and its buttons: Start Game, Load Game, Exit Game
    /// </summary>
    public partial class MenuPage : Page
    {
        private MainWindow frameRef;
        public SoundEngine soundEngine;
        public MenuPage(MainWindow frame)
        {
            InitializeComponent();
            // start background music player
            SoundLibrary.InitializeLibrary(true);
            soundEngine = new SoundEngine(SoundContext.MenuPage);
            soundEngine.PlayBackgroundMusic();

            frameRef = frame;
            frame.Background = new SolidColorBrush(Colors.Beige);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this); 
            window.IsVisibleChanged += CleaningAfterPageClosedHandler;
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            PlayButtonSoundClick();
            StartingChoicePage scPage = new StartingChoicePage(frameRef, this); // create a new StartingChoicePage
            frameRef.ParentFrame.Navigate(scPage); // switch priority from MenuPage to StartingChoicePage
        }
        public void StartGameRun(string data)
        {
            GamePage gamePage = new GamePage(frameRef, data);
            soundEngine.StopBackgroundMusic();
            frameRef.ParentFrame.Navigate(gamePage);
        }
        private void LoadGame(object sender, RoutedEventArgs e)
        {
            PlayButtonSoundClick();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".bin"; // Default file extension
            dlg.Filter = "Text documents (.bin)|*.bin"; // Filter files by extension
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                GamePage gamePage = new GamePage(frameRef, null); // create a new GamePage
                frameRef.ParentFrame.Navigate(gamePage); // switch priority from MenuPage to GamePage
                gamePage.LoadGame(dlg.FileName);
            }
        }
        private void ExitGame(object sender, RoutedEventArgs e)
        {
            soundEngine.ForceStopAllPlayers();
            var window = Window.GetWindow(this);
            window.IsVisibleChanged -= CleaningAfterPageClosedHandler;
            System.Windows.Application.Current.Shutdown(); //close the application
        }

        private void PlayButtonSoundHover(object sender, System.Windows.Input.MouseEventArgs e)
        {
            soundEngine.PlaySound(SoundNames.MOUSE_HOVER_MENU);
        }
        private void PlayButtonSoundClick()
        {
            soundEngine.PlaySound(SoundNames.MOUSE_CLICK_MENU);
        }

        private void CleaningAfterPageClosedHandler(object sender, DependencyPropertyChangedEventArgs e)
        {
            soundEngine.ForceStopAllPlayers();
        }
        private void VolumeLoaded(object sender, RoutedEventArgs e)
        {
            Volume.Value = 50;
            soundEngine.UpdateVolume(50);
        }
        private void VolumeChanged(object sender, RoutedEventArgs e)
        {
            soundEngine.UpdateVolume(Volume.Value);
        }

    }
}
