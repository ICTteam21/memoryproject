using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Timers;

namespace MemoryGame
{
    class LoadClass
    {
        private Grid grid;


        string pathing;
        StackPanel Savedgames = new StackPanel();
        private LoadScreen window;

        /// <summary>
        /// Dit is de methode die het Loadgame screen initieert.
        /// </summary>
        /// <param name="window"></param>
        /// <param name="grid"></param>
        /// <param name="kolommen"></param>
        /// <param name="rijen"></param>
        public LoadClass(LoadScreen window, Grid grid, int kolommen, int rijen)
        {   //settings//
            if (MainClass.windowstyle == 2)
            { window.WindowStyle = WindowStyle.None; }
            else
            { window.WindowStyle = WindowStyle.SingleBorderWindow; }
            if (MainClass.windowstate == 2)
            { window.WindowState = WindowState.Maximized; }
            else
            { window.WindowState = WindowState.Normal; }

            this.window = window;
            this.grid = grid;
            InitializeMain(kolommen, rijen);
            AddBack();
            Title();
            padnaarsavefiles();
            addsavesgrid();


        }

        /// <summary>
        /// De methode die het hoofdgrid aanmaakt.
        /// </summary>
        /// <param name="kolommen"></param>
        /// <param name="rijen"></param>
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
        /// Het toevoegen van de back button.
        /// </summary>
        public void AddBack()
        {
            Button Back = new Button
            {
                Content = "Back",
                FontSize = 40,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(3),
                FontFamily = new FontFamily("Bahnschrift"),
                Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue),
            };

            Grid.SetRow(Back, 9);
            Grid.SetColumn(Back, 2);
            Grid.SetColumnSpan(Back, 1);
            Grid.SetRowSpan(Back, 1);
            grid.Children.Add(Back);
            Back.Click += Back_Click1;
        }

        /// <summary>
        /// voegt de title toe aan het grid.
        /// </summary>
        public void Title()
        {
            Label title = new Label();
            title.Content = "Load Game:";
            title.FontSize = 80;
            title.FontFamily = new FontFamily("Bahnschrift");
            title.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(title, 0);
            Grid.SetColumn(title, 1);
            Grid.SetRowSpan(title, 2);
            grid.Children.Add(title);

        }

        /// <summary>
        /// de click funtie van de back button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Back_Click1(object sender, RoutedEventArgs e)
        {
            var SelectScherm = new MainMenuWindow(); //create your new form.
            SelectScherm.Show(); //show the new form.
            window.Close();
        }

        /// <summary>
        /// haalt de locatie op van de savefiles.
        /// </summary>
        public void padnaarsavefiles()
        {
            pathing = System.AppDomain.CurrentDomain.BaseDirectory;
            pathing = pathing.Replace("bin", "Textdocs");
            pathing = pathing.Replace("Debug", "SavedGames");
        }

        /// <summary>
        /// Maakt  voor elke savefile een button aan  in het grid.
        /// </summary>
        public void addsavesgrid()
        {
            Savedgames.VerticalAlignment = VerticalAlignment.Stretch;
            Savedgames.HorizontalAlignment = HorizontalAlignment.Stretch;
            Grid.SetColumn(Savedgames, 0);
            Grid.SetRow(Savedgames, 2);
            Grid.SetRowSpan(Savedgames, 5);
            Grid.SetColumnSpan(Savedgames, 3);
            grid.Children.Add(Savedgames);

            String[] files = Directory.GetFiles(pathing);
            foreach (string saves in files)
            {
                string naam = saves;
                //.Substring(saves.Length - 10);
                //naam = naam.Replace(".txt","");
                Button loadgame = new Button
                {
                    Content = naam,
                    FontSize = 20,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(3),
                    FontFamily = new FontFamily("Bahnschrift"),
                    Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue),
                };
                loadgame.Click += new RoutedEventHandler(loadgame_Click);

                Savedgames.Children.Add(loadgame);


            }
        }

        /// <summary>
        /// de methode die moet worden uitgevoerd zodra en op één van de buttons wordt geclicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void loadgame_Click(object sender, RoutedEventArgs e)
        {
            Button loadgame = (Button)sender;
            string savenaam = (string)loadgame.Content;

            var nieuwSpel = new GameWindow(savenaam, 2); //create your new form.
            nieuwSpel.Show(); //show the new form.
            window.Close();  //only if you want to close the current form.



        }

    }
}

