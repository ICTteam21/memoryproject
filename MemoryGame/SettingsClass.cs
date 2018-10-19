using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MemoryGame
{
    class SettingsClass
    {
        private Grid grid;

        private Settings window;
        public SettingsClass(Settings window, Grid grid, int kolommen, int rijen)
        {
            this.window = window;
            this.grid = grid;
            InitializeMain(kolommen, rijen);
            AddSettings();
            Addback();

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
        public void AddSettings()
        {
            Button change = new Button();
            Grid.SetRow(change, 18);
            Grid.SetColumn(change, 5);
            Grid.SetColumnSpan(change, 1);
            Grid.SetRowSpan(change, 2);
            grid.Children.Add(change);

            change.Click += Change_Click;

        }
        public void Change_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            window.WindowState = WindowState.Maximized;

        }
        public void Addback()
        {
            Button Back = new Button();
            Grid.SetRow(Back, 10);
            Grid.SetColumn(Back, 5);
            Grid.SetColumnSpan(Back, 1);
            Grid.SetRowSpan(Back, 2);
            grid.Children.Add(Back);

            Back.Click += Back_Click; ;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            var SelectScherm = new MainMenuWindow(); //create your new form.
            SelectScherm.Show(); //show the new form.
            window.Close();
            
        }
    }
}
