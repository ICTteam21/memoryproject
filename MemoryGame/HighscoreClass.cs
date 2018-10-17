using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Highscores
{
    class HighscoreClass
    {
        private Grid grid;


        public HighscoreClass(Grid grid, int kolommen, int rijen)
        {
            this.grid = grid;
            InitializeMain(kolommen, rijen);
            Title();
            Highscoretabel();
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
            title.Content = "Highscores";
            title.FontSize = 40;
            title.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(title, 0);
            Grid.SetColumn(title, 1);
            Grid.SetColumnSpan(title, 3);
            Grid.SetRowSpan(title, 2);
            grid.Children.Add(title);
        }

        private void Highscoretabel()
        {
            Button disney = new Button();
            disney.Content = "testest";
            disney.FontSize = 20;
            //startgame.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(disney, 3);
            Grid.SetColumn(disney, 1);
            Grid.SetColumnSpan(disney, 3);
            Grid.SetRowSpan(disney, 2);
            grid.Children.Add(disney);
            disney.Click += new RoutedEventHandler(button_wow);


        }
        private void PlayClick()
        {
            MediaPlayer Sound1 = new MediaPlayer();
            Sound1.Open(new Uri(@"D:\stuff\school\Memory Project\Sound Effects - Memory Game\click.mp3"));
            Sound1.Play();
        }

        private void PlayCorrect()
        {
            MediaPlayer Sound1 = new MediaPlayer();
            Sound1.Open(new Uri(@"D:\stuff\school\Memory Project\Sound Effects - Memory Game\correct.mp3"));
            Sound1.Play();
        }

        private void PlayWow()
        {
            MediaPlayer Sound1 = new MediaPlayer();
            Sound1.Open(new Uri(@"D:\stuff\school\Memory Project\Sound Effects - Memory Game\wow.mp3"));
            Sound1.Play();
        }

        public void button_click(object sender, RoutedEventArgs e)
        {
            PlayClick();
        }

        public void button_correct(object sender, RoutedEventArgs e)
        {
            PlayCorrect();
        }

        public void button_wow(object sender, RoutedEventArgs e)
        {
            PlayWow();
        }
    }
}
