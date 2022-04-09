using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Game.Display
{
    // prepare and display listbox interaction
    class ListBoxInteractionDisplay
    {
        public int ChosenNumber { get; protected set; } = -1;
        protected GamePage parentPage;
        protected ListBox box;
        public ListBoxInteractionDisplay(GamePage page) { parentPage = page; }
        public void SetChoices(List<String> choices)
        {
            box = new ListBox();
            box.Background = Brushes.Black;
            box.Foreground = Brushes.White;
            box.FontWeight = FontWeights.Bold;
            box.FontSize = 12.0;
            box.BorderThickness = new Thickness(1);
            box.ItemContainerStyle = Application.Current.Resources["ListBoxRowHeight"] as Style;
            box.GotFocus += Box_GotFocus;
            box.SelectionChanged += new SelectionChangedEventHandler(Chosen);
            parentPage.PageGrid.Children.Add(box);
            Grid.SetColumn(box, 0);
            Grid.SetRow(box, 0);
            Grid.SetRowSpan(box, 2);
            box.ItemsSource = choices;
        }

        private void Box_GotFocus(object sender, RoutedEventArgs e)
        {
            parentPage.soundEngine.PlaySound(Sound.SoundNames.MOUSE_CLICK_GAME_2);
        }

        public void Finish()
        {
            parentPage.PageGrid.Children.Remove(box);
        }
        private void Chosen(object sender, RoutedEventArgs e)
        {
            var item = (ListBox)sender;
            ChosenNumber = item.SelectedIndex;
        }
    }
}
