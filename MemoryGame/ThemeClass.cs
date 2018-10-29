using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace MemoryGame
{
    class ThemaClass
    {
        private Themas window;
        private Grid grid;
        Button logo = new Button();
        Button gebouwen = new Button();
        Button disney = new Button();



        public ThemaClass(Themas window, Grid grid, int kolommen, int rijen, int windowstate, int windowstyle)
        {

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
            Title();
            Theme1();
            Theme2();
            Theme3();
            
        }
        //Grid
        private void InitializeMain(int kolommen, int rijen)
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

        //Titel bovenaan
        private void Title()
        {
            Label title = new Label
            {
                Content = "Theme Selector",
                FontSize = 80,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Bahnschrift"),
            };

            Grid.SetRow(title, 0);
            Grid.SetColumn(title, 1);
            Grid.SetColumnSpan(title, 3);
            Grid.SetRowSpan(title, 2);
            grid.Children.Add(title);
        }


        private void Theme1()
        {
            disney.Content = "Disney";
            disney.FontSize = 20;

            Grid.SetRow(disney, 3);
            Grid.SetColumn(disney, 1);
            Grid.SetColumnSpan(disney, 3);
            Grid.SetRowSpan(disney, 2);
            grid.Children.Add(disney);
            disney.Click += btnSelectThema;

        }


        private void Theme2()
        {
            gebouwen.Content = "Gebouwen";
            gebouwen.FontSize = 20;
            Grid.SetRow(gebouwen, 6);
            Grid.SetColumn(gebouwen, 1);
            Grid.SetColumnSpan(gebouwen, 3);
            Grid.SetRowSpan(gebouwen, 2);
            grid.Children.Add(gebouwen);
            gebouwen.Click += btnSelectThema;
        }


        private void Theme3()
        {
            logo.Content = "Logo's";
            logo.FontSize = 20;
            Grid.SetRow(logo, 9);
            Grid.SetColumn(logo, 1);
            Grid.SetColumnSpan(logo, 3);
            Grid.SetRowSpan(logo, 2);
            grid.Children.Add(logo);
            logo.Click += btnSelectThema;
        }




        private static string thema;

        public void btnSelectThema(object sender, RoutedEventArgs e)
        {
            
            if (sender == logo)
            {
                thema = "logos";
            }else if (sender == gebouwen)
            {
                thema = "gebouwen"; 
            }else if(sender == disney)
            {
                thema = "disney";
            }
            var nieuwSpel = new GameWindow( thema ,MainClass.windowstate, MainClass.windowstyle ); //create your new form.
            nieuwSpel.Show(); //show the new form.
            window.Close();  //only if you want to close the current form.

        }


      

    }
}
