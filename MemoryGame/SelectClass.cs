using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MemoryGame
{
    class SelectClass
    {
        private Grid grid;
        
        RadioButton Check4 = new RadioButton();
        RadioButton Check1 = new RadioButton();
        RadioButton Check2 = new RadioButton();
        RadioButton Check3 = new RadioButton();
        Label size = new Label();

        public SelectClass(Grid grid, int kolommen, int rijen)
        {
            this.grid = grid;
            InitializeMain(kolommen, rijen);
            AddTitle2();
            AddContinue();
            AddBack();
            AddCheck1();
            AddCheck2();
            AddCheck3();
            AddCheck4();
            AddText1();
            AddText2();
            AddName1();
            AddName2();

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

        //Title//
        private void AddTitle2()
        {
            Label title = new Label();
            title.Content = "New Game Selector";
            title.FontSize = 30;
            title.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(title, 0);
            Grid.SetColumn(title, 3);
            Grid.SetColumnSpan(title, 3);
            Grid.SetRowSpan(title, 2);
            grid.Children.Add(title);
        }
        //Continue button//
        private void AddContinue()
        {
            Button Continue = new Button();
            Continue.Content = "Continue";
            Continue.FontSize = 18;
            //startgame.HorizontalAlignment = HorizontalAlignment.Center;


            Grid.SetRow(Continue, 18);
            Grid.SetColumn(Continue, 7);
            Grid.SetColumnSpan(Continue, 1);
            Grid.SetRowSpan(Continue, 1);
            grid.Children.Add(Continue);
            Continue.Click += Continue_Click;
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("continue");
        }

        //Back button// 
        private void AddBack()
        {
            Button Back = new Button();
            Back.Content = "Back";
            Back.FontSize = 18;
            //startgame.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(Back, 18);
            Grid.SetColumn(Back, 5);
            Grid.SetColumnSpan(Back, 1);
            Grid.SetRowSpan(Back, 1);
            grid.Children.Add(Back);
            Back.Click += Back_Click1;
                }

        private void Back_Click1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("back");
        }

      
        //Radiobutton 1//
        public void AddCheck1()
        {
           
            Check1.Content = "Difficulty 1";
            Check1.FontSize = 15;


            Grid.SetRow(Check1, 7);
            Grid.SetColumn(Check1, 1);
            Grid.SetColumnSpan(Check1, 1);
            Grid.SetRowSpan(Check1, 1);
            grid.Children.Add(Check1);
            Check1.Checked += Check1_Checked;

        }

      

        public void Check1_Checked(object sender, RoutedEventArgs e)
        {

            labelenplaatjenieuw();
        }



        //Radiobutton 2//
        public void AddCheck2()
        {
            
            Check2.Content = "Difficulty 2";
            Check2.FontSize = 15;


            Grid.SetRow(Check2, 9);
            Grid.SetColumn(Check2, 1);
            Grid.SetColumnSpan(Check2, 1);
            Grid.SetRowSpan(Check2, 1);
            grid.Children.Add(Check2);
            Check2.Checked += Check2_Checked; ;
        }

        public void Check2_Checked(object sender, RoutedEventArgs e)
        {
          


            labelenplaatjenieuw();



        }



        //Radiobutton 3//
        public void AddCheck3()
        {
            
            Check3.Content = "Difficulty 3";
            Check3.FontSize = 15;


            Grid.SetRow(Check3, 11);
            Grid.SetColumn(Check3, 1);
            Grid.SetColumnSpan(Check3, 1);
            Grid.SetRowSpan(Check3, 1);
            grid.Children.Add(Check3);
            Check3.Checked += Check3_Checked;
        }

        private void Check3_Checked(object sender, RoutedEventArgs e)
        {
            labelenplaatjenieuw();
        }

        //Radiobutton 4//
        public void AddCheck4()
        {
            
            Check4.Content = "Difficulty 4";
            Check4.FontSize = 15;


            Grid.SetRow(Check4, 13);
            Grid.SetColumn(Check4, 1);
            Grid.SetColumnSpan(Check4, 1);
            Grid.SetRowSpan(Check4, 1);
            grid.Children.Add(Check4);
            Check4.Checked += Check4_Checked;
        }

        private void Check4_Checked(object sender, RoutedEventArgs e)
        {
            labelenplaatjenieuw();
        }

        //Name box 1//
        private void AddText1()
        {
            TextBox Text1 = new TextBox();


            Grid.SetRow(Text1, 2);
            Grid.SetColumn(Text1, 2);
            Grid.SetColumnSpan(Text1, 1);
            Grid.SetRowSpan(Text1, 1);
            grid.Children.Add(Text1);
           
        }
        //Name box 2//
        private void AddText2()
        {
            TextBox Text2 = new TextBox();
            Text2.FontSize = 13;


            Grid.SetRow(Text2, 2);
            Grid.SetColumn(Text2, 6);
            Grid.SetColumnSpan(Text2, 1);
            Grid.SetRowSpan(Text2, 1);
            grid.Children.Add(Text2);

        }
        //Label player//
        private void AddName1()
        {
            Label Name1 = new Label();
            Name1.Content = "Name Player 1 : ";
            Name1.FontSize = 13;

            Grid.SetRow(Name1, 2);
            Grid.SetColumn(Name1, 1);
            Grid.SetColumnSpan(Name1, 1);
            Grid.SetRowSpan(Name1, 1);
            grid.Children.Add(Name1);

        }
        //label player 2//
        private void AddName2()
        {
            Label Name2 = new Label();
            Name2.Content = "Name Player 2 : ";
            Name2.FontSize = 13;

            Grid.SetRow(Name2, 2);
            Grid.SetColumn(Name2, 5);
            Grid.SetColumnSpan(Name2, 1);
            Grid.SetRowSpan(Name2, 1);
            grid.Children.Add(Name2);
        }
        

        public void labelenplaatjenieuw()
        {
            if (Check2.IsChecked == true)
            {
                
                Image preview2 = new Image();
                preview2.Source = new BitmapImage(new Uri("4x4preview.png", UriKind.Relative));
                Grid.SetRow(preview2, 7);
                Grid.SetColumn(preview2, 5);
                Grid.SetColumnSpan(preview2, 7);
                Grid.SetRowSpan(preview2, 7);
                grid.Children.Remove(preview2);
                grid.Children.Add(preview2);

                size.Content = "4x4 + 30 seconds time limit";
                size.FontSize = 12;
                Grid.SetRow(size, 5);
                Grid.SetColumn(size, 6);
                Grid.SetColumnSpan(size, 7);
                Grid.SetRowSpan(size, 1);
                grid.Children.Remove(size);
                grid.Children.Add(size);

                return;

            }
            else if (Check1.IsChecked == true)
            {
                Image preview2 = new Image();
                preview2.Source = new BitmapImage(new Uri("4x4preview.png", UriKind.Relative));
                Grid.SetRow(preview2, 7);
                Grid.SetColumn(preview2, 5);
                Grid.SetColumnSpan(preview2, 7);
                Grid.SetRowSpan(preview2, 7);
                grid.Children.Remove(preview2);
                grid.Children.Add(preview2);



               
                size.Content = "4x4 + No time limit";
                size.FontSize = 12;
                Grid.SetRow(size, 5);
                Grid.SetColumn(size, 6);
                Grid.SetColumnSpan(size, 7);
                Grid.SetRowSpan(size, 1);
                grid.Children.Remove(size);
                grid.Children.Add(size); 
                return;
            }
            else if (Check3.IsChecked == true)
            {
                Image preview2 = new Image();
                preview2.Source = new BitmapImage(new Uri("4x4preview.png", UriKind.Relative));
                Grid.SetRow(preview2, 7);
                Grid.SetColumn(preview2, 5);
                Grid.SetColumnSpan(preview2, 7);
                Grid.SetRowSpan(preview2, 7);
                grid.Children.Remove(preview2);
                grid.Children.Add(preview2);




                size.Content = "4x4 + 10 seconds time limit";
                size.FontSize = 12;
                Grid.SetRow(size, 5);
                Grid.SetColumn(size, 6);
                Grid.SetColumnSpan(size, 7);
                Grid.SetRowSpan(size, 1);
                grid.Children.Remove(size);
                grid.Children.Add(size); ;
                return;
            }
            else if (Check4.IsChecked == true)
            {
                Image preview2 = new Image
                {
                    Source = new BitmapImage(new Uri("4x4preview.png", UriKind.Relative))
                };
                Grid.SetRow(preview2, 7);
                Grid.SetColumn(preview2, 5);
                Grid.SetColumnSpan(preview2, 7);
                Grid.SetRowSpan(preview2, 7);
                grid.Children.Remove(preview2);
                grid.Children.Add(preview2);





                size.Content = "4x4 + 5 seconds time limit";
                size.FontSize = 12;
                Grid.SetRow(size, 5);
                Grid.SetColumn(size, 6);
                Grid.SetColumnSpan(size, 7);
                Grid.SetRowSpan(size, 1);
                grid.Children.Remove(size);
                grid.Children.Add(size);
                return;
            }


          
        }
    }
}
