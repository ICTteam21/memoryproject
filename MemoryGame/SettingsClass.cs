using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MemoryGame
{
    class SettingsClass
    {
        RadioButton resize = new RadioButton();
        RadioButton resize2 = new RadioButton();
        RadioButton resize3 = new RadioButton();
        private Grid grid;

        private Settings window;
        public SettingsClass(Settings window, Grid grid, int kolommen, int rijen)
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
            AddTitle();
            Addback();
            Resize();
            Resize2();
            Resize3();


            //LightMode();

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
                Content = "Settings",
                FontSize = 80,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Bahnschrift"),
            };
            Grid.SetRow(title, 0);
            Grid.SetRowSpan(title, 3);
            Grid.SetColumn(title, 3);
            Grid.SetColumnSpan(title, 3);
            grid.Children.Add(title);
        }

        public void Addback()
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
            Grid.SetRow(Back, 18);
            Grid.SetRowSpan(Back, 2);
            Grid.SetColumn(Back, 8);
            Grid.SetColumnSpan(Back, 1);
            grid.Children.Add(Back);

            Back.Click += Back_Click; ;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            
            var SelectScherm = new MainMenuWindow(); //create your new form.
            SelectScherm.Show(); //show the new form.
            window.Close();

        }
        public void Resize()
        {

            resize.Content = "FullScreen";
            resize.FontSize = 50;
            resize.BorderBrush = Brushes.Black;
            resize.BorderThickness = new Thickness(3);
            resize.FontFamily = new FontFamily("Bahnschrift");
            resize.Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue);
            resize.Checked += Resize_Checked;
            resize.HorizontalAlignment = HorizontalAlignment.Left;

            Grid.SetRow(resize, 5);
            Grid.SetRowSpan(resize, 2);
            Grid.SetColumn(resize, 3);
            Grid.SetColumnSpan(resize, 3);
            grid.Children.Add(resize);
        }

        private void Resize_Checked(object sender, RoutedEventArgs e)
        {
            MainClass.windowstyle = 2;
            MainClass.windowstate = 2;

            window.WindowState = WindowState.Maximized;

            window.WindowStyle = WindowStyle.None;
        }

        public void Resize2()
        {

            resize2.Content = "Maximized + Top Bar";
            resize2.FontSize = 50;
            resize2.BorderBrush = Brushes.Black;
            resize2.BorderThickness = new Thickness(3);
            resize2.FontFamily = new FontFamily("Bahnschrift");
            resize2.Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue);
            resize2.Checked += Resize2_Checked;
            resize2.HorizontalAlignment = HorizontalAlignment.Left;

            Grid.SetRow(resize2, 9);
            Grid.SetRowSpan(resize2, 2);
            Grid.SetColumn(resize2, 3);
            Grid.SetColumnSpan(resize2, 4);
            grid.Children.Add(resize2);
        }

        private void Resize2_Checked(object sender, RoutedEventArgs e)
        {
            MainClass.windowstyle = 1;
            MainClass.windowstate = 2;

            window.WindowState = WindowState.Maximized;

            window.WindowStyle = WindowStyle.None;
        }
        public void Resize3()
        {

            resize3.Content = "Normal + top Bar";
            resize3.FontSize = 50;
            resize3.BorderBrush = Brushes.Black;
            resize3.BorderThickness = new Thickness(3);
            resize3.FontFamily = new FontFamily("Bahnschrift");
            resize3.Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue);
            resize3.Checked += Resize3_Checked;
            resize3.HorizontalAlignment = HorizontalAlignment.Left;

            Grid.SetRow(resize3, 13);
            Grid.SetRowSpan(resize3, 2);
            Grid.SetColumn(resize3, 3);
            Grid.SetColumnSpan(resize3, 3);
            grid.Children.Add(resize3);
        }

        private void Resize3_Checked(object sender, RoutedEventArgs e)
        {
            MainClass.windowstyle = 1;
            MainClass.windowstate = 1;

            window.WindowState = WindowState.Normal;

            window.WindowStyle = WindowStyle.SingleBorderWindow;

        }
    }
}
