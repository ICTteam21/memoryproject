using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace Memory_HoofdUI
{

    public class Class1
    {

        private Grid grid;

        /// <summary>
        /// Genereert een 2de menu.
        /// </summary>
        /// <param name="grid"></param>
        public Class1(Grid grid)
        {

            this.grid = grid;

            int kolommen = 5;
            int rijen = 15;

            InitializeMain(kolommen, rijen);

            AddTitle();
            AddNewGame();
            AddLoadGame();
            AddHighScores();
            AddCredits();

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


        public void AddTitle()
        {
            Label title = new Label();
            title.Content = "Memory Game";
            title.FontSize = 40;
            title.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(title, 0);
            Grid.SetColumn(title, 1);
            Grid.SetColumnSpan(title, 3);
            Grid.SetRowSpan(title, 2);
            grid.Children.Add(title);

        }

        public void AddNewGame()
        {
            Button newgame = new Button();
            newgame.Content = "New Game";
            newgame.FontSize = 20;
            //startgame.HorizontalAlignment = HorizontalAlignment.Center;
            newgame.Background = Brushes.Red;

            Grid.SetRow(newgame, 3);
            Grid.SetColumn(newgame, 1);
            Grid.SetColumnSpan(newgame, 3);
            Grid.SetRowSpan(newgame, 2);
            grid.Children.Add(newgame);

            newgame.Click += new RoutedEventHandler(newgame_click);

        }

        public void AddLoadGame()
        {
            Button loadgame = new Button();
            loadgame.Content = "Load Game";
            loadgame.FontSize = 20;
            //startgame.HorizontalAlignment = HorizontalAlignment.Center;
            loadgame.Background = Brushes.Red;

            Grid.SetRow(loadgame, 6);
            Grid.SetColumn(loadgame, 1);
            Grid.SetColumnSpan(loadgame, 3);
            Grid.SetRowSpan(loadgame, 2);
            grid.Children.Add(loadgame);

            loadgame.Click += new RoutedEventHandler(loadgame_click);

        }

        public void AddHighScores()
        {
            Button highscores = new Button();

            highscores.Content = "Highscores";
            highscores.FontSize = 20;
            //startgame.HorizontalAlignment = HorizontalAlignment.Center;
            highscores.Background = Brushes.Red;

            Grid.SetRow(highscores, 9);
            Grid.SetColumn(highscores, 1);
            Grid.SetColumnSpan(highscores, 3);
            Grid.SetRowSpan(highscores, 2);
            grid.Children.Add(highscores);

            highscores.Click += new RoutedEventHandler(highscores_click);

        }

        public void AddCredits()
        {
            Button credits = new Button();

            credits.Content = "Credits";
            credits.FontSize = 20;
            //startgame.HorizontalAlignment = HorizontalAlignment.Center;
            credits.Background = Brushes.Red;

            Grid.SetRow(credits, 12);
            Grid.SetColumn(credits, 1);
            Grid.SetColumnSpan(credits, 3);
            Grid.SetRowSpan(credits, 2);
            grid.Children.Add(credits);

            credits.Click += new RoutedEventHandler(credits_click);


        }

        public static void newgame_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New Game");
        }

        public static void loadgame_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Load Game");
        }

        public static void highscores_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Highscores");
        }

        public static void credits_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("WUTTTTT");
        }




    }




}

