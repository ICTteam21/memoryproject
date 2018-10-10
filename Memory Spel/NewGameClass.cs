using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Memory_Spel
{
    class NewGameClass
    {
        private Grid grid;


        public NewGameClass(Grid grid, int kolommen, int rijen)
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
        }

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
        }
        private void AddCheck1()
        {
            RadioButton Check1 = new RadioButton();
            Check1.Content = "Difficulty 1";
            Check1.FontSize = 15;


            Grid.SetRow(Check1, 7);
            Grid.SetColumn(Check1, 1);
            Grid.SetColumnSpan(Check1, 1);
            Grid.SetRowSpan(Check1, 1);
            grid.Children.Add(Check1);
        }

        private void AddCheck2()
        {
            RadioButton Check2 = new RadioButton();
            Check2.Content = "Difficulty 2";
            Check2.FontSize = 15;


            Grid.SetRow(Check2, 9);
            Grid.SetColumn(Check2, 1);
            Grid.SetColumnSpan(Check2, 1);
            Grid.SetRowSpan(Check2, 1);
            grid.Children.Add(Check2);
        }
        private void AddCheck3()
        {
            RadioButton Check3 = new RadioButton();
            Check3.Content = "Difficulty 3";
            Check3.FontSize = 15;


            Grid.SetRow(Check3, 11);
            Grid.SetColumn(Check3, 1);
            Grid.SetColumnSpan(Check3, 1);
            Grid.SetRowSpan(Check3, 1);
            grid.Children.Add(Check3);
        }
        private void AddCheck4()
        {
            RadioButton Check4 = new RadioButton();
            Check4.Content = "Difficulty 4";
            Check4.FontSize = 15;


            Grid.SetRow(Check4, 13);
            Grid.SetColumn(Check4, 1);
            Grid.SetColumnSpan(Check4, 1);
            Grid.SetRowSpan(Check4, 1);
            grid.Children.Add(Check4);
        }
        private void AddText1()
        {
            TextBox Text1 = new TextBox();
            Text1.FontSize = 13;


            Grid.SetRow(Text1, 2);
            Grid.SetColumn(Text1, 2);
            Grid.SetColumnSpan(Text1, 1);
            Grid.SetRowSpan(Text1, 1);
            grid.Children.Add(Text1);
        }

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
        private void AddName1()
        {
            Label Name1 = new Label();
            Name1.Content = "Naam speler : ";
            Name1.FontSize = 13;

            Grid.SetRow(Name1, 2);
            Grid.SetColumn(Name1, 1);
            Grid.SetColumnSpan(Name1, 1);
            Grid.SetRowSpan(Name1, 1);
            grid.Children.Add(Name1);

        }
        private void AddName2()
        {
            Label Name2 = new Label();
            Name2.Content = "Naam speler : ";
            Name2.FontSize = 13;

            Grid.SetRow(Name2, 2);
            Grid.SetColumn(Name2, 5);
            Grid.SetColumnSpan(Name2, 1);
            Grid.SetRowSpan(Name2, 1);
            grid.Children.Add(Name2);
        }
    }
}
