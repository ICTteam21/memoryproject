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
        //Het hele scherm
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

        //Eerste thema
        private void Theme1()
        {
            Button disney = new Button();
            disney.Content = "Disney";
            disney.FontSize = 20;
            //startgame.HorizontalAlignment = HorizontalAlignment.Center;
            
            Grid.SetRow(disney, 3);
            Grid.SetColumn(disney, 1);
            Grid.SetColumnSpan(disney, 3);
            Grid.SetRowSpan(disney, 2);
            grid.Children.Add(disney);
            disney.Click += new RoutedEventHandler(button_click);
            disney.Click += new RoutedEventHandler(Disney_click);
           
        }

        //Tweede thema
        private void Theme2()
        {
            Button gebouwen = new Button();
            gebouwen.Content = "Gebouwen";
            gebouwen.FontSize = 20;
            //startgame.HorizontalAlignment = HorizontalAlignment.Center;
 
            Grid.SetRow(gebouwen, 6);
            Grid.SetColumn(gebouwen, 1);
            Grid.SetColumnSpan(gebouwen, 3);
            Grid.SetRowSpan(gebouwen, 2);
            grid.Children.Add(gebouwen);
            gebouwen.Click += new RoutedEventHandler(button_click);
            gebouwen.Click += new RoutedEventHandler(Gebouwen_click);
        }

        //Derde Thema
        private void Theme3()
        {   
            Button logo = new Button();
            logo.Content = "Logo's";
            logo.FontSize = 20;
            //startgame.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(logo, 9);
            Grid.SetColumn(logo, 1);
            Grid.SetColumnSpan(logo, 3);
            Grid.SetRowSpan(logo, 2);
            grid.Children.Add(logo);
            logo.Click += new RoutedEventHandler(button_click);
            logo.Click += new RoutedEventHandler(Logo_click);
        }
        public void Logo_click(object sender, RoutedEventArgs e)
        {

            var newForm = new GameWindow("1"); //create your new form.
            newForm.Show(); //show the new form.
            window.Close();  //only if you want to close the current form.
        }
        public void Gebouwen_click(object sender, RoutedEventArgs e)
        {
            
            var newForm = new GameWindow("2"); //create your new form.
            newForm.Show(); //show the new form.
            window.Close();  //only if you want to close the current form.
        }
        public void Disney_click(object sender, RoutedEventArgs e)
        {

            var newForm = new GameWindow("3"); //create your new form.
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
