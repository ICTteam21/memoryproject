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


        public ThemaClass(Themas window, Grid grid, int kolommen, int rijen)
        {
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
                FontSize = 40,
                HorizontalAlignment = HorizontalAlignment.Center
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
            disney.Click += new RoutedEventHandler(button_click);
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
            gebouwen.Click += new RoutedEventHandler(button_click);
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
            logo.Click += new RoutedEventHandler(button_click);
            logo.Click += btnSelectThema;
        }




        private int i;

        public void btnSelectThema(object sender, RoutedEventArgs e)
        {
            
            if (sender == logo)
            {
                i = 1;
            }else if (sender == gebouwen)
            {
                i = 2; 
            }else if(sender == disney)
            {
                i = 3;
            }
            var newForm = new GameWindow( i ); //create your new form.
            newForm.Show(); //show the new form.
            window.Close();  //only if you want to close the current form.

        }






        //Click geluid laden
        private void PlayClick()
        {
                MediaPlayer Sound1 = new MediaPlayer();
                Sound1.Open(new Uri(@"D:\stuff\school\Memory Project\Sound Effects - Memory Game\click.mp3"));
                Sound1.Play();
        }

        //Correct geluid laden
        private void PlayCorrect()
        {
            MediaPlayer Sound1 = new MediaPlayer();
            Sound1.Open(new Uri(@"D:\stuff\school\Memory Project\Sound Effects - Memory Game\correct.mp3"));
            Sound1.Play();
        }

        //Wow geluid laden
        private void PlayWow()
        {
            MediaPlayer Sound1 = new MediaPlayer();
            Sound1.Open(new Uri(@"D:\stuff\school\Memory Project\Sound Effects - Memory Game\wow.mp3"));
            Sound1.Play();
        }

        //Click geluid private naar public zodat je het kan gebruiken
        public void button_click(object sender, RoutedEventArgs e)
        {
            PlayClick();
        }

        //Correct geluid private naar public zodat je het kan gebruiken
        public void button_correct(object sender, RoutedEventArgs e)
        {
            PlayCorrect();
        }

        //Wow geluid private naar public zodat je het kan gebruiken
        public void button_wow(object sender, RoutedEventArgs e)
        {
            PlayWow();
        }



    }
}
