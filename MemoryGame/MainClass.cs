﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;


namespace MemoryGame
{
    
    class MainClass
    {
        private MainMenuWindow window;
        private Grid grid;
        Button newgame = new Button();
        public static int aantalSpelers;
        public static int windowstate;
        public static int windowstyle;
        public object Children { get; internal set; }
        

        /// <summary>
        /// Het hoofdgrid.
        /// </summary>
        /// <param name="grid"></param>
        public MainClass(MainMenuWindow window, Grid grid)
        {  //settings//
            if (MainClass.windowstyle == 2)
            { window.WindowStyle = WindowStyle.None; }
            else
            { window.WindowStyle = WindowStyle.SingleBorderWindow; }
            if (MainClass.windowstate == 2)
            { window.WindowState = WindowState.Maximized; }
            else
            { window.WindowState = WindowState.Normal; }
            //end//
            this.window = window;
            this.grid = grid;

            int kolommen = 6;
            int rijen = 20;

            InitializeMain(kolommen, rijen);
            
            AddTitle();
            AddNewGame();
            AddLoadGame();
            AddHighScores();
            AddSettings();
            AddQuit();


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
            Label title = new Label
            {
                Content = "Memory Game",
                FontSize = 120,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Bahnschrift"),
            };


            Grid.SetRow(title, 1);
            Grid.SetColumn(title, 1);
            Grid.SetColumnSpan(title, 4);
            Grid.SetRowSpan(title, 4);
            grid.Children.Add(title);

        }

        public void AddNewGame()
        {
            Button newgame = new Button
            {
                Content = "New Game",
                FontSize = 60,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(3),
                FontFamily = new FontFamily("Bahnschrift"),
                Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue),
            };



            Grid.SetRow(newgame, 7);
            Grid.SetColumn(newgame, 2);
            Grid.SetColumnSpan(newgame, 2);
            Grid.SetRowSpan(newgame, 2);
            grid.Children.Add(newgame);

            newgame.Click += new RoutedEventHandler(Newgame_click);

        }
        public void AddNewGame2()
        {
            Button newgame2 = new Button
            {
                Content = "2 Players",
                FontSize = 50,
                BorderBrush = Brushes.LightGray,
                BorderThickness = new Thickness(3),
                FontFamily = new FontFamily("Bahnschrift"),
                Background = new LinearGradientBrush(Colors.White, Colors.LightSteelBlue, 3),
            };

            Grid.SetRow(newgame2, 7);
            Grid.SetColumn(newgame2, 3);
            Grid.SetColumnSpan(newgame2, 1);
            Grid.SetRowSpan(newgame2, 2);
            grid.Children.Add(newgame2);

            newgame2.Click += new RoutedEventHandler(Newgame2_click);


        }

        public void AddNewGame1()
        {
            Button newgame1 = new Button
            {
                Content = "1 Player",
                FontSize = 50,
                BorderBrush = Brushes.LightGray,
                BorderThickness = new Thickness(3),
                FontFamily = new FontFamily("Bahnschrift"),
                Background = new LinearGradientBrush(Colors.LightSteelBlue, Colors.White, 3),
            };

            Grid.SetRow(newgame1, 7);
            Grid.SetColumn(newgame1, 2);
            Grid.SetColumnSpan(newgame1, 1);
            Grid.SetRowSpan(newgame1, 2);
            grid.Children.Add(newgame1);

            newgame1.Click += new RoutedEventHandler(Newgame1_click);


        }


        public void AddLoadGame()
        {
            Button loadgame = new Button
            {
                Content = "Load Game",
                FontSize = 60,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(3),
                FontFamily = new FontFamily("Bahnschrift"),
                Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue),
            };

            Grid.SetRow(loadgame, 10);
            Grid.SetColumn(loadgame, 2);
            Grid.SetColumnSpan(loadgame, 2);
            Grid.SetRowSpan(loadgame, 2);
            grid.Children.Add(loadgame);

            loadgame.Click += new RoutedEventHandler(Loadgame_click);

        }

        public void AddHighScores()
        {
            Button highscores = new Button
            {
                Content = "Highscores",
                FontSize = 60,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(3),
                FontFamily = new FontFamily("Bahnschrift"),
                Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue),
        };

            Grid.SetRow(highscores, 13);
            Grid.SetColumn(highscores, 2);
            Grid.SetColumnSpan(highscores, 2);
            Grid.SetRowSpan(highscores, 2);
            grid.Children.Add(highscores);

            highscores.Click += new RoutedEventHandler(Highscores_click);

        }

        public void AddSettings()
        {
            Button settings = new Button
            {
                Content = "Settings",
                FontSize = 60,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(3),
                FontFamily = new FontFamily("Bahnschrift"),
                Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue),
            };

            Grid.SetRow(settings, 16);
            Grid.SetColumn(settings, 2);
            Grid.SetColumnSpan(settings, 2);
            Grid.SetRowSpan(settings, 2);
            grid.Children.Add(settings);

            settings.Click += new RoutedEventHandler(settings_click);


        }
        public void AddQuit()
        {
            Button Quit = new Button
            {
                Content = "Quit",
                FontSize = 60,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(3),
                FontFamily = new FontFamily("Bahnschrift"),
                Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue),
            };

            Grid.SetRow(Quit, 18);
            Grid.SetColumn(Quit, 5);
            Grid.SetColumnSpan(Quit, 1);
            Grid.SetRowSpan(Quit, 2);
            grid.Children.Add(Quit);

            Quit.Click += new RoutedEventHandler(Quit_click);


        }

        void Quit_click(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();
        }

        public void Newgame_click(object sender, RoutedEventArgs e)
        {
            AddNewGame1();
            AddNewGame2();
        }

        public void Newgame1_click(object sender, RoutedEventArgs e)
        {
            aantalSpelers = 1;
            var SelectScherm = new SelectOptions(aantalSpelers,windowstate,windowstyle); //create your new form.
            SelectScherm.Show(); //show the new form.
            window.Close();
        }
        public void Newgame2_click(object sender, RoutedEventArgs e)
        {
            aantalSpelers = 2; 
            var SelectScherm = new SelectOptions(aantalSpelers,windowstate, windowstyle); //create your new form.
            SelectScherm.Show(); //show the new form.
            window.Close();
        }

        public void Loadgame_click(object sender, RoutedEventArgs e)
        {
            var Loading = new LoadScreen(windowstate); //create your new form.
            Loading.Show(); //show the new form.
            window.Close();

        }

        public void Highscores_click(object sender, RoutedEventArgs e)
        {
            var HighScores = new HighScores(); //create your new form.
            HighScores.Show(); //show the new form.
            window.Close();


        }



        // to test need to remove
        
        void settings_click(object sender, RoutedEventArgs e)
        {

            var SelectScherm = new Settings(); //create your new form.
            SelectScherm.Show(); //show the new form.
            window.Close();
        }

    }


}
