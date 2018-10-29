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
        CheckBox Darkmode = new CheckBox();
        CheckBox LightMode = new CheckBox();
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
            
            Addback();
            Resize();
            Resize2();
            Resize3();
            DarkMode();
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
      
        public void Addback()
        {
            Button Back = new Button();
            Back.Content = "Back";
            Grid.SetRow(Back, 20);
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
        public void Resize()
        {

            resize.Content = "FullScreen";
            resize.FontSize = 40;
            Grid.SetRow(resize, 2);
            Grid.SetColumn(resize, 2);
            Grid.SetColumnSpan(resize, 2);
            resize.BorderBrush = Brushes.Black;
            resize.BorderThickness = new Thickness(3);
            resize.FontFamily = new FontFamily("Bahnschrift");
            resize.Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue);
            resize.Checked += Resize_Checked;
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
            resize2.FontSize = 40;
            Grid.SetRow(resize2, 4);
            Grid.SetColumn(resize2, 2);
            Grid.SetColumnSpan(resize2, 3);
            resize2.BorderBrush = Brushes.Black;
            resize2.BorderThickness = new Thickness(3);
            resize2.FontFamily = new FontFamily("Bahnschrift");
            resize2.Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue);
            resize2.Checked += Resize2_Checked;
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
            resize3.FontSize = 40;
            Grid.SetRow(resize3, 6);
            Grid.SetColumn(resize3, 2);
            Grid.SetColumnSpan(resize3, 2);
            resize3.BorderBrush = Brushes.Black;
            resize3.BorderThickness = new Thickness(3);
            resize3.FontFamily = new FontFamily("Bahnschrift");
            resize3.Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue);
            resize3.Checked += Resize3_Checked;
            grid.Children.Add(resize3);
        }

        private void Resize3_Checked(object sender, RoutedEventArgs e)
        {
            MainClass.windowstyle = 1;
            MainClass.windowstate = 1;

            window.WindowState = WindowState.Normal;

            window.WindowStyle = WindowStyle.SingleBorderWindow;

        }
        public void DarkMode()
        {

            Darkmode.Content = "resize3";
            Darkmode.FontSize = 40;
            Grid.SetRow(Darkmode, 8);
            Darkmode.BorderBrush = Brushes.Black;
            Darkmode.BorderThickness = new Thickness(3);
            Darkmode.FontFamily = new FontFamily("Bahnschrift");
            Darkmode.Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue);
            Darkmode.Checked += Darkmode_Checked;
            grid.Children.Add(Darkmode);
        }

        private void Darkmode_Checked(object sender, RoutedEventArgs e)
        {
           
            window.Background = Brushes.DarkGray;

        }
    }
    
}
