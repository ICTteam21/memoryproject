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


        string path3;
        StackPanel Savedgames = new StackPanel();
        
        
        private LoadScreen window;
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
            pathing();
            addsavesgrid();


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

            Grid.SetRow(Back, 9);
            Grid.SetColumn(Back, 2);
            Grid.SetColumnSpan(Back, 1);
            Grid.SetRowSpan(Back, 1);
            grid.Children.Add(Back);
            Back.Click += Back_Click1;
        }
        public void Title()
        {
            Label title = new Label();
            title.Content = "Load Game:";
            title.FontSize = 60;
            title.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(title, 0);
            Grid.SetColumn(title, 1);
            Grid.SetRowSpan(title, 2);
            grid.Children.Add(title);

        }
        public void Back_Click1(object sender, RoutedEventArgs e)
        {
            var SelectScherm = new MainMenuWindow(); //create your new form.
            SelectScherm.Show(); //show the new form.
            window.Close();
        }
        public void pathing()
        {
            path3 = System.AppDomain.CurrentDomain.BaseDirectory;
            path3 = path3.Replace("bin", "Textdocs");
            path3 = path3.Replace("Debug", "SavedGames");
        }
        public void addsavesgrid()
        {
            Savedgames.VerticalAlignment = VerticalAlignment.Stretch;
            Savedgames.HorizontalAlignment = HorizontalAlignment.Stretch;
            Grid.SetColumn(Savedgames, 0);
            Grid.SetRow(Savedgames, 2);
            Grid.SetRowSpan(Savedgames, 5);
            Grid.SetColumnSpan(Savedgames, 3);
            grid.Children.Add(Savedgames);

            String[] files = Directory.GetFiles(path3);
            foreach (string saves in files)
            {
                string naam = saves;
                //.Substring(saves.Length - 10);
                //naam = naam.Replace(".txt","");
                Button loadgame = new Button();
                loadgame.Content = naam;
                loadgame.FontSize = 20;

                loadgame.Click += new RoutedEventHandler(loadgame_Click);

                Savedgames.Children.Add(loadgame);


            }
        }

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

