using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Game.Engine;
using Game.Engine.Skills;
using Game.Engine.Monsters;
using Game.Engine.CharacterClasses;

namespace Game.Display
{
    // prepare and display graphical elements during battles
    class BattleScene
    {
        protected Grid BattleGrid;
        protected RichTextBox battleConsole;
        protected ListBox moves;
        protected GamePage parentPage;
        protected GameSession parentSession;
        protected Image playerImage;
        protected Image monsterImage;
        protected Player player;
        protected Monster monster;
        List<RichTextBox> rtbs;
        public Image ImgSetup { get; set; }
        public BattleScene(GamePage page, GameSession session, Player player, Monster monster)
        {
            parentPage = page;
            parentSession = session;
            this.player = player;
            this.monster = monster;
            this.playerImage = player.GetImage();
            this.monsterImage = monster.GetImage();
        }

        public void SetupDisplay()
        {
            // initialize display elements
            BattleGrid = new Grid();
            for (int i = 0; i < 5; i++) BattleGrid.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < 5; i++) BattleGrid.ColumnDefinitions.Add(new ColumnDefinition());
            // construct battle image
            Grid ImageGrid = new Grid();
            ImageGrid.Background = Brushes.Black;
            for (int i = 0; i < 12; i++) ImageGrid.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < 2; i++) ImageGrid.ColumnDefinitions.Add(new ColumnDefinition());
            ImgSetup.Stretch = Stretch.Fill;
            ImageGrid.Children.Add(ImgSetup);
            Grid.SetColumn(ImgSetup, 0);
            Grid.SetColumnSpan(ImgSetup, 2);
            Grid.SetRow(ImgSetup, 0);
            Grid.SetRowSpan(ImgSetup, 8);
            playerImage.Stretch = Stretch.Uniform;
            monsterImage.Stretch = Stretch.Uniform;
            ImageGrid.Children.Add(playerImage);
            ImageGrid.Children.Add(monsterImage);
            Grid.SetColumn(playerImage, 0);
            Grid.SetColumn(monsterImage, 1);
            Grid.SetRow(playerImage, 1);
            Grid.SetRowSpan(playerImage, 3);
            Grid.SetRow(monsterImage, 1);
            Grid.SetRowSpan(monsterImage, 3);
            // still constructing battle image - statistics
            rtbs = new List<RichTextBox>() { new RichTextBox(), new RichTextBox(), 
                new RichTextBox(), new RichTextBox(), new RichTextBox(), new RichTextBox(), 
                new RichTextBox(), new RichTextBox(), new RichTextBox(), new RichTextBox(), 
                new RichTextBox(), new RichTextBox() };
            foreach(RichTextBox rtb in rtbs)
            {
                rtb.Focusable = false;
                rtb.Background = Brushes.Black;
                rtb.Foreground = Brushes.Yellow;
                rtb.FontWeight = FontWeights.Bold;
                rtb.BorderThickness = new Thickness(0);
                ImageGrid.Children.Add(rtb);
            }
            Grid.SetColumn(rtbs[0], 0);
            Grid.SetColumn(rtbs[1], 0);
            Grid.SetColumn(rtbs[2], 0);
            Grid.SetColumn(rtbs[3], 0);
            Grid.SetColumn(rtbs[4], 0);
            Grid.SetColumn(rtbs[5], 0);
            Grid.SetColumn(rtbs[6], 1);
            Grid.SetColumn(rtbs[7], 1);
            Grid.SetColumn(rtbs[8], 1);
            Grid.SetColumn(rtbs[9], 1);
            Grid.SetColumn(rtbs[10], 1);
            Grid.SetColumn(rtbs[11], 1);
            Grid.SetRow(rtbs[0], 5);
            Grid.SetRow(rtbs[1], 6);
            Grid.SetRow(rtbs[2], 7);
            Grid.SetRow(rtbs[3], 8);
            Grid.SetRow(rtbs[4], 9);
            Grid.SetRow(rtbs[5], 10);
            Grid.SetRow(rtbs[6], 5);
            Grid.SetRow(rtbs[7], 6);
            Grid.SetRow(rtbs[8], 7);
            Grid.SetRow(rtbs[9], 8);
            Grid.SetRow(rtbs[10], 9);
            Grid.SetRow(rtbs[11], 10);
            RefreshStats();
            // add battle image to grid
            BattleGrid.Children.Add(ImageGrid);
            Grid.SetColumn(ImageGrid, 0);
            Grid.SetColumnSpan(ImageGrid, 2);
            Grid.SetRow(ImageGrid, 0);
            Grid.SetRowSpan(ImageGrid, 2);
            // style
            moves = new ListBox();
            moves.Background = Brushes.Black;
            moves.Foreground = Brushes.White;
            moves.FontWeight = FontWeights.Bold;
            moves.FontSize = 12.0;
            moves.BorderThickness = new Thickness(1);
            moves.ItemContainerStyle = Application.Current.Resources["ListBoxRowHeight"] as Style;
            moves.SelectionChanged += new SelectionChangedEventHandler(SkillChosen);
            BattleGrid.Children.Add(moves);
            //positioning
            Grid.SetColumn(moves, 0);
            Grid.SetColumnSpan(moves, 5);
            Grid.SetRow(moves, 2);
            Grid.SetRowSpan(moves, 3);
            // battle text console
            battleConsole = new RichTextBox();
            battleConsole.Background = Brushes.Black;
            battleConsole.Foreground = Brushes.Yellow;
            battleConsole.FontWeight = FontWeights.Bold;
            battleConsole.SetValue(Paragraph.LineHeightProperty, 1.0);
            battleConsole.FontSize = 12.0;
            //battleConsole.IsReadOnly = true;
            battleConsole.Focusable = false;
            BattleGrid.Children.Add(battleConsole);
            Grid.SetColumn(battleConsole, 2);
            Grid.SetColumnSpan(battleConsole, 3);
            Grid.SetRow(battleConsole, 0);
            Grid.SetRowSpan(battleConsole, 2);
            // final
            parentPage.PageGrid.Children.Add(BattleGrid);
            Grid.SetColumn(BattleGrid, 0);
            Grid.SetRow(BattleGrid, 0);
            Grid.SetRowSpan(BattleGrid, 2);
            BattleGrid.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ItemsMouseLeftButtonDown);
            battleConsole.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ItemsMouseLeftButtonDown);
        }
        public void EndDisplay()
        {
            // clean up
            if (BattleGrid != null) parentPage.PageGrid.Children.Remove(BattleGrid);
        }     
        public void SetSkills(List<Skill> skills)
        {
            // set skills for the player to choose from
            moves.ItemsSource = skills;
        }
        private void SkillChosen(object sender, RoutedEventArgs e)
        {
            // a skill has been chosen - inform the parent page which will do rest of the job
            var item = (ListBox)sender;
            parentPage.ListBoxSelected((Skill)item.SelectedItem);
        }
        public void ResetChoice()
        {
            // reset skill choice
            moves.SelectedItem = null;
        }
        public void SendBattleText(string text)
        {
            // send a text message to the battle console (not to the main game console)
            battleConsole.AppendText(text + "\n");
            battleConsole.ScrollToEnd();
        }
        public void SendColorText(string text, string color)
        {
            // same as SendBattleText, but in color
            if (battleConsole == null) return;
            SendBattleText(text);
            SolidColorBrush brush;
            switch (color)
            {
                case "yellow":
                    brush = Brushes.Yellow;
                    break;
                case "red":
                    brush = Brushes.Red;
                    break;
                case "green":
                    brush = Brushes.LimeGreen;
                    break;
                case "blue":
                    brush = Brushes.DodgerBlue;
                    break;
                default:
                    brush = Brushes.Yellow;
                    break;
            }
            foreach (var paragraph in battleConsole.Document.Blocks)
            {
                var text2 = new TextRange(paragraph.ContentStart, paragraph.ContentEnd).Text;
                if (text2 == text) paragraph.Foreground = brush;
            }
        }

        public void RefreshStats()
        {
            // refresh all statistics displayed
            rtbs[0].Document.Blocks.Clear();
            rtbs[0].AppendText("Zdrowie: " + player.Health);
            rtbs[1].Document.Blocks.Clear();
            rtbs[1].AppendText("Sila: " + player.Strength);
            rtbs[2].Document.Blocks.Clear();
            rtbs[2].AppendText("Pancerz: " + player.Armor);
            rtbs[3].Document.Blocks.Clear();
            rtbs[3].AppendText("Precyzja: " + player.Precision);
            rtbs[4].Document.Blocks.Clear();
            rtbs[4].AppendText("Moc: " + player.MagicPower);
            rtbs[5].Document.Blocks.Clear();
            rtbs[5].AppendText("Energia: " + player.Stamina);
            rtbs[6].Document.Blocks.Clear();
            rtbs[6].AppendText("Zdrowie: " + monster.Health);
            rtbs[7].Document.Blocks.Clear();
            rtbs[7].AppendText("Sila: " + monster.Strength);
            rtbs[8].Document.Blocks.Clear();
            rtbs[8].AppendText("Pancerz: " + monster.Armor);
            rtbs[9].Document.Blocks.Clear();
            rtbs[9].AppendText("Precyzja: " + monster.Precision);
            rtbs[10].Document.Blocks.Clear();
            rtbs[10].AppendText("Moc: " + monster.MagicPower);
            rtbs[11].Document.Blocks.Clear();
            rtbs[11].AppendText("Energia: " + monster.Stamina);
            AdjustStatDisplay();
        }
        private void AdjustStatDisplay()
        {
            // adjustments (don't ask me why this can't be done only once in xaml... )
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtbs[0]);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtbs[1]);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtbs[2]);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtbs[3]);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtbs[4]);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtbs[5]);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtbs[6]);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtbs[7]);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtbs[8]);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtbs[9]);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtbs[10]);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtbs[11]);
        }
        protected void ItemsMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            parentSession.CurrentKey = "MousePress";
        }
    }
}
