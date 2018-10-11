using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Settings
{
    class ThemeClass
    {
        private Grid grid;


        public ThemeClass(Grid grid, int kolommen, int rijen)
        {
            this.grid = grid;
            InitializeMain(kolommen, rijen);
            Title();
            Theme1();
            Theme2();
            Theme3();
        }

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


        private void Title()
        {
            Label title = new Label();
            title.Content = "Theme Selector";
            title.FontSize = 40;
            title.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(title, 0);
            Grid.SetColumn(title, 1);
            Grid.SetColumnSpan(title, 3);
            Grid.SetRowSpan(title, 2);
            grid.Children.Add(title);
        }

        private void Theme1()
        {
            Button startgame = new Button();
            startgame.Content = "Disney";
            startgame.FontSize = 20;
            //startgame.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(startgame, 3);
            Grid.SetColumn(startgame, 1);
            Grid.SetColumnSpan(startgame, 3);
            Grid.SetRowSpan(startgame, 2);
            grid.Children.Add(startgame);
            
        }
        private void Theme2()
        {
            Button startgame = new Button();
            startgame.Content = "Gebouwen";
            startgame.FontSize = 20;
            //startgame.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(startgame, 6);
            Grid.SetColumn(startgame, 1);
            Grid.SetColumnSpan(startgame, 3);
            Grid.SetRowSpan(startgame, 2);
            grid.Children.Add(startgame);
        }
        private void Theme3()
        {
            Button startgame = new Button();
            startgame.Content = "Logo's";
            startgame.FontSize = 20;
            //startgame.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(startgame, 9);
            Grid.SetColumn(startgame, 1);
            Grid.SetColumnSpan(startgame, 3);
            Grid.SetRowSpan(startgame, 2);
            grid.Children.Add(startgame);
        }
    }
}
