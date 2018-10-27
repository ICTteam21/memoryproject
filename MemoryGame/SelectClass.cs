﻿using System;
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
    class SelectClass
    {
        private Grid grid;
        
        private SelectOptions window;
        
        
        RadioButton Check1 = new RadioButton();
        RadioButton Check2 = new RadioButton();
        RadioButton Check3 = new RadioButton();
        RadioButton Check4 = new RadioButton();
        TextBox Text1 = new TextBox();
        TextBox Text2 = new TextBox();
        
        Label size = new Label();
        public static int diff = 0;

        public SelectClass(SelectOptions window, Grid grid, int kolommen, int rijen, int aantalSpelers, int windowstate, int windowstyle)
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
            AddTitle2();
            AddContinue();
            AddBack();
            AddCheck1();
            AddCheck2();
            AddCheck3();
            AddCheck4();
           

            if(aantalSpelers == 1)
            {
                AddText1();
                AddName1();
            }
            else
            {
                AddName1();
                AddName2();
                AddText1();
                AddText2();
            }

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

        //Title//
        public void AddTitle2()
        {
            Label title = new Label
            {
                Content = "New Game Selector",
                FontSize = 30,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Bahnschrift"),
            };
            Grid.SetRow(title, 0);
            Grid.SetColumn(title, 2);
            Grid.SetColumnSpan(title, 4);
            Grid.SetRowSpan(title, 3);
            grid.Children.Add(title);
        }

        //Continue button//
        public void AddContinue()
        {
            Button Continue = new Button
            {   
                Content = "Continue",
                FontSize = 40,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(3),
                FontFamily = new FontFamily("Bahnschrift"),
                Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue),
            };

            Grid.SetRow(Continue, 18);
            Grid.SetColumn(Continue, 7);
            Grid.SetColumnSpan(Continue, 1);
            Grid.SetRowSpan(Continue, 2);
            grid.Children.Add(Continue);
            Continue.Click += Continue_Click;
        }

        public void Continue_Click(object sender, RoutedEventArgs e)
        {
           
            Transferdata();
            var Themes = new Themas(MainClass.windowstate,MainClass.windowstyle); //create your new form.
            Themes.Show(); //show the new form.
            window.Close();
        }

        //Back button// 
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
            Grid.SetRow(Back, 18);
            Grid.SetColumn(Back, 5);
            Grid.SetColumnSpan(Back, 1);
            Grid.SetRowSpan(Back, 2);
            grid.Children.Add(Back);
            Back.Click += Back_Click1;
                }

        public void Back_Click1(object sender, RoutedEventArgs e)
        {
            var SelectScherm = new MainMenuWindow(); //create your new form.
            SelectScherm.Show(); //show the new form.
            window.Close();
        }

        /// <summary>
        ///  Diffuculty 1 radiobutton
        /// </summary>
        public void AddCheck1()
        {

            Check1.Content = "Difficulty 1";
            Check1.FontSize = 40;
            Check1.BorderBrush = Brushes.Black;
            Check1.BorderThickness = new Thickness(3);
            Check1.FontFamily = new FontFamily("Bahnschrift");
            Check1.Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue);

            Grid.SetRow(Check1, 7);
            Grid.SetColumn(Check1, 1);
            Grid.SetColumnSpan(Check1, 2);
            Grid.SetRowSpan(Check1, 2);
            grid.Children.Add(Check1);
            Check1.Checked += RadioButtonClicked;
 
        }
        /// <summary>
        ///  Diffuculty 2 radiobutton
        /// </summary>
        public void AddCheck2()
        {

            Check2.Content = "Difficulty 2";
            Check2.FontSize = 40;
            Check2.BorderBrush = Brushes.Black;
            Check2.BorderThickness = new Thickness(3);
            Check2.FontFamily = new FontFamily("Bahnschrift");
            Check2.Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue);


            Grid.SetRow(Check2, 9);
            Grid.SetColumn(Check2, 1);
            Grid.SetColumnSpan(Check2, 2);
            Grid.SetRowSpan(Check2, 2);
            grid.Children.Add(Check2);
            Check2.Checked += RadioButtonClicked;

        }

        /// <summary>
        ///  Diffuculty 3 radiobutton
        /// </summary>
        public void AddCheck3()
        {

            Check3.Content = "Difficulty 3";
            Check3.FontSize = 40;
            Check3.BorderBrush = Brushes.Black;
            Check3.BorderThickness = new Thickness(3);
            Check3.FontFamily = new FontFamily("Bahnschrift");
            Check3.Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue);


            Grid.SetRow(Check3, 11);
            Grid.SetColumn(Check3, 1);
            Grid.SetColumnSpan(Check3, 2);
            Grid.SetRowSpan(Check3, 2);
            grid.Children.Add(Check3);
            Check3.Checked += RadioButtonClicked;
 
        }

        /// <summary>
        ///  Diffuculty 4 radiobutton
        /// </summary>
        public void AddCheck4()
        {

            Check4.Content = "Difficulty 4";
            Check4.FontSize = 40;
            Check4.BorderBrush = Brushes.Black;
            Check4.BorderThickness = new Thickness(3);
            Check4.FontFamily = new FontFamily("Bahnschrift");
            Check4.Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue);


            Grid.SetRow(Check4, 13);
            Grid.SetColumn(Check4, 1);
            Grid.SetColumnSpan(Check4, 2);
            Grid.SetRowSpan(Check4, 2);
            grid.Children.Add(Check4);
            Check4.Checked += RadioButtonClicked;

        }

        /// <summary>
        /// diffuculty selector and sets the preview image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            Image preview2 = new Image
            {
                Source = new BitmapImage(new Uri("Images/4x4 preview.png", UriKind.Relative)),
            };
            Grid.SetRow(preview2, 7);
            Grid.SetColumn(preview2, 5);
            Grid.SetColumnSpan(preview2, 7);
            Grid.SetRowSpan(preview2, 7);
            //Label setup//
            size.FontSize = 12;
            Grid.SetRow(size, 5);
            Grid.SetColumn(size, 6);
            Grid.SetColumnSpan(size, 7);
            Grid.SetRowSpan(size, 2);
            if (MainClass.aantalSpelers.Equals(1))
            {
                if (Check1.IsChecked == true)
                {
                    //Remove and Add Image//

                    grid.Children.Remove(preview2);
                    grid.Children.Add(preview2);

                // label 2//
                size.Content = "10 minute time limit";
                size.FontSize = 25;
                size.FontFamily = new FontFamily("Bahnschrift");
                grid.Children.Remove(size);
                grid.Children.Add(size);
                diff = 1;
                return;

                }
                else if (Check2.IsChecked == true)
                {

                    //Remove and Add Image//
                    grid.Children.Remove(preview2);
                    grid.Children.Add(preview2);

                // label 1//
                size.Content = "5 minute time limit";
                size.FontSize = 25;
                size.FontFamily = new FontFamily("Bahnschrift");
                grid.Children.Remove(size);
                grid.Children.Add(size);
                diff = 2;
                return;
            }
            else if (Check3.IsChecked == true)
            {
                //Remove and Add Image//
                grid.Children.Remove(preview2);
                grid.Children.Add(preview2);

                // label 3//
                size.Content = "2 minute time limit";
                size.FontSize = 25;
                size.FontFamily = new FontFamily("Bahnschrift");
                grid.Children.Remove(size);
                grid.Children.Add(size);
                diff = 3;
                return;
            }
            else if (MainClass.aantalSpelers.Equals(2))
            {
                if (Check1.IsChecked == true)
                {
                    //Remove and Add Image//

                // label 4//
                size.Content = "1 minute time limit";
                size.FontSize = 25;
                size.FontFamily = new FontFamily("Bahnschrift");
                grid.Children.Remove(size);
                grid.Children.Add(size);
                diff = 4;
                return;
            }


        }

        


        //Name box 1//
        public void AddText1()
        {
            
            Text1.FontSize = 40;
            Text1.BorderBrush = Brushes.Black;
            Text1.BorderThickness = new Thickness(3);
            Text1.FontFamily = new FontFamily("Bahnschrift");

            Grid.SetRow(Text1, 3);
            Grid.SetColumn(Text1, 2);
            Grid.SetColumnSpan(Text1, 1);
            Grid.SetRowSpan(Text1, 1);
            grid.Children.Add(Text1);
            
           
        }
        //Name box 2//
        public void AddText2()
        {
            
            Text2.FontSize = 13;
            

            Grid.SetRow(Text2, 3);
            Grid.SetColumn(Text2, 6);
            Grid.SetColumnSpan(Text2, 1);
            Grid.SetRowSpan(Text2, 1);
            grid.Children.Add(Text2);

        }
        //Label player//
        public void AddName1()
        {
            Label Name1 = new Label();
            Name1.Content = "Name Player 1 : ";
            Name1.FontSize = 25;
            Name1.FontFamily = new FontFamily("Bahnschrift");


            Grid.SetRow(Name1, 3);
            Grid.SetColumn(Name1, 1);
            Grid.SetColumnSpan(Name1, 1);
            Grid.SetRowSpan(Name1, 2 );
            grid.Children.Add(Name1);

        }
        //label player 2//
        public void AddName2()
        {
            Label Name2 = new Label();
            Name2.Content = "Name Player 2 : ";
            Name2.FontSize = 25;
            Name2.FontFamily = new FontFamily("Bahnschrift");

            Grid.SetRow(Name2, 3);
            Grid.SetColumn(Name2, 5);
            Grid.SetColumnSpan(Name2, 1);
            Grid.SetRowSpan(Name2, 2);
            grid.Children.Add(Name2);
        }

        public void Transferdata()
        {
            string[] lines = { Text1.Text, Text2.Text, };
            string pathing;
            string path2;
            pathing = System.AppDomain.CurrentDomain.BaseDirectory;
            path2 = pathing.Replace("bin", "Textdocs");
            path2 = path2.Replace("Debug", "NewGame");

            System.IO.File.WriteAllLines(path2 + "New.txt", lines);
            
        }

    }
}
