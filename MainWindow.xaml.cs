using System.Windows;


namespace Game
{
    /// <summary>
    /// Main window - the application will start here
    /// Nothing else should happen here, we outsource navigation duties to MenuPage
    /// </summary> 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // specify window behavior after initialization
        // WPF will automatically detect this function
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ParentFrame.Navigate(new Display.MenuPage(this)); // go to the menu page
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            Sound.SoundLibrary.DiscardTemporaryFiles();
            Application.Current.Dispatcher.DisableProcessing();
            Application.Current.Dispatcher.InvokeShutdown();
            Application.Current.Shutdown();
        }
    }
}
