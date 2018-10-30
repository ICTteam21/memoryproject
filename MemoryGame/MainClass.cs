using System;
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

        /// <summary>
        /// Hier wordt de titel van de pagina aangemaakt
        /// </summary>
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
        /// <summary>
        /// Deze button zorgt ervoor dat je een nieuw spel kan starten met de opties 1 of 2 spelers
        /// </summary>
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

        /// <summary>
        /// Dit is de button om het spel met 2 spelers te laden
        /// </summary>
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
        /// <summary>
        /// dit is de button om het spel met 1 speler te laden
        /// </summary>
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

        /// <summary>
        /// deze button verwijst je naar het loadgame scherm waar je je spel kan inladen
        /// </summary>
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
        /// <summary>
        /// deze button verwijst je naar het highscores menu waar de highscores kan bekijken
        /// </summary>
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
        /// <summary>
        /// deze button verwijst je naar het settings menu waar je enkele settings kan aanpassen
        /// </summary>
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
        /// <summary>
        /// deze button sluit de hele applicatie
        /// </summary>
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
        {// functie van de quit button, sluit de hele applicatie

            Application.Current.Shutdown();
        }

        public void Newgame_click(object sender, RoutedEventArgs e) 
        {// functie van de newgame buttons, 1 of 2 spelers worden hier door ingeladen
            AddNewGame1();
            AddNewGame2();
        }

        public void Newgame1_click(object sender, RoutedEventArgs e)
        { // dit is de functie voor 1 speler, laadt het spel voor 1 speler
            aantalSpelers = 1;
            var SelectScherm = new SelectOptions(aantalSpelers); //create your new form.
            SelectScherm.Show(); //show the new form.
            window.Close();
        }
        public void Newgame2_click(object sender, RoutedEventArgs e)
        {// dit is de functie voor 2 spelers, laadt het spel voor 2 spelers
            aantalSpelers = 2; 
            var SelectScherm = new SelectOptions(aantalSpelers); //create your new form.
            SelectScherm.Show(); //show the new form.
            window.Close();
        }

        public void Loadgame_click(object sender, RoutedEventArgs e)
        { // dit is de functie om je naar het loadgame scherm te sturen
            var Loading = new LoadScreen(); //create your new form.
            Loading.Show(); //show the new form.
            window.Close();

        }
        
        public void Highscores_click(object sender, RoutedEventArgs e)
        { // dit is de functie van de highscores button die je verwijst naar het highscores scherm
            var HighScores = new HighScores(); //create your new form.
            HighScores.Show(); //show the new form.
            window.Close();


        }



        // to test need to remove
        
        void settings_click(object sender, RoutedEventArgs e)
        { // dit is de functie van de settings button om je naar het settings scherm te verwijzen

            var SelectScherm = new Settings(); //create your new form.
            SelectScherm.Show(); //show the new form.
            window.Close();
        }

    }


}
