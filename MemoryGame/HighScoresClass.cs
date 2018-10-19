using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MemoryGame
{
    class HighScoresClass
    {
        private Grid grid;

        private HighScores window;
        public HighScoresClass(HighScores window, Grid grid, int kolommen, int rijen)
        {
            this.window = window;
            this.grid = grid;
            InitializeMain(kolommen, rijen);
            AddBack();

        }
        public void InitializeMain(int kolommen, int rijen)
        {
            for (int i = 0; i < rijen; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < kolommen; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        public void AddBack()
        {
            Button Back = new Button();
            Back.Content = "Back";
            Back.FontSize = 18;
            //startgame.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(Back, 18);
            Grid.SetColumn(Back, 5);
            Grid.SetColumnSpan(Back, 1);
            Grid.SetRowSpan(Back, 2);
            grid.Children.Add(Back);
            Back.Click += Back_Click1;
        }

        public void Back_Click1(object sender, RoutedEventArgs e)
        {
            var SelectScherm = new MainMenuWindow(); //create your new form.
            SelectScherm.Show(); //show the new form.
            window.Close();
        }

    }
}
