using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Security.Cryptography;
using System.Threading;

namespace MemoryGame
{
    class GameGrid
    {
        private Grid grid;
        private bool IsTaskRunning = false;

        Label Player1name = new Label();
        Label Score1 = new Label();
        Label Player1Score = new Label();
        Label Player2name = new Label();
        Label Score2 = new Label();
        Label Player2Score = new Label();

        int aandebeurt = 1;
        int P1Points = 0;
        int P2Points = 0;

        public GameGrid(Grid grid, int cols, int rows, int thema)
        {
            this.grid = grid;
            InitializeGameGrid(cols, rows);

            AddImages(thema, cols, rows);
            Playerstats();
        }

        private void InitializeGameGrid(int cols, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int j = 0; j < cols ; j++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        /// <summary>
        /// Laad de images op een random manier in een list.
        /// </summary>
        /// <returns></returns>
        private List<ImageSource> GetImageListLogos()
        {
            List<ImageSource> imagesLogos = new List<ImageSource>();
            for (int i = 0; i < 16; i++)
            {
                int imageNr = i % 8 + 1;
                ImageSource source = new BitmapImage(new Uri("Images/logos/logo" + imageNr + ".png", UriKind.Relative));
                imagesLogos.Add(source);
            }

            imagesLogos.Shuffle();
            return imagesLogos;
        }
        private List<ImageSource> GetImageListGebouwen()
        {
            List<ImageSource> imagesGebouwen = new List<ImageSource>();
            for (int i = 0; i < 16; i++)
            {
                int imageNr = i % 8 + 1;
                ImageSource source = new BitmapImage(new Uri("Images/gebouwen/" + imageNr + "-1.jpg", UriKind.Relative));
                imagesGebouwen.Add(source);
            }

            imagesGebouwen.Shuffle();
            return imagesGebouwen;
        }
        private List<ImageSource> GetImageListDisney()
        {
            List<ImageSource> imagesGebouwen = new List<ImageSource>();
            for (int i = 0; i < 16; i++)
            {
                int imageNr = i % 8 + 1;
                ImageSource source = new BitmapImage(new Uri("Images/disney/" + imageNr + "-1.png", UriKind.Relative));
                imagesGebouwen.Add(source);
            }

            imagesGebouwen.Shuffle();
            return imagesGebouwen;
        }
        /// <summary>
        /// Voegt de plaatjes aan de grid 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        
        private void AddImages(int thema, int rows, int cols)
        {

            if (thema.Equals(1))
            {
                List<ImageSource> images = GetImageListLogos();
                for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < cols; column++)
                    {
                        Image backgroudImage = new Image
                        {
                            Source = new BitmapImage(new Uri("Images/background.png", UriKind.Relative)),
                            Tag = images.First()
                        };
                        images.RemoveAt(0);
                        backgroudImage.MouseDown += new MouseButtonEventHandler(CardClick);
                        Grid.SetColumn(backgroudImage, column);
                        Grid.SetRow(backgroudImage, row);
                        grid.Children.Add(backgroudImage);
                    }
                }
            }
            else if (thema.Equals(2))
            {
                List<ImageSource> images = GetImageListGebouwen();
                for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < cols; column++)
                    {
                        Image backgroudImage = new Image
                        {
                            Source = new BitmapImage(new Uri("Images/background.png", UriKind.Relative)),
                            Tag = images.First()
                        };
                        images.RemoveAt(0);
                        backgroudImage.MouseDown += new MouseButtonEventHandler(CardClick);
                        Grid.SetColumn(backgroudImage, column);
                        Grid.SetRow(backgroudImage, row);
                        grid.Children.Add(backgroudImage);
                    }
                }
            }
            else if (thema.Equals(3))
            {
                List<ImageSource> images = GetImageListDisney();
                for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < cols; column++)
                    {
                        Image backgroudImage = new Image
                        {
                            Source = new BitmapImage(new Uri("Images/background.png", UriKind.Relative)),
                            Tag = images.First()
                        };
                        images.RemoveAt(0);
                        backgroudImage.MouseDown += new MouseButtonEventHandler(CardClick);
                        Grid.SetColumn(backgroudImage, column);
                        Grid.SetRow(backgroudImage, row);
                        grid.Children.Add(backgroudImage);
                    }
                }
            }

        }


        /// <summary>
        /// Is de functie die bepaald wat er gebeurt als je op een kaart klikt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private int pairs = 0;
        private string CardOne;
        private string CardTwo;
        private string xyOne;
        private string xyTwo;
        private Image cardA;
        private Image cardB;
  
        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            var element = (UIElement)e.Source;
            Image card = (Image)sender;
            ImageSource back = new BitmapImage(new Uri("Images/background.png", UriKind.Relative));
            ImageSource front = (ImageSource)card.Tag;


            if(IsTaskRunning == false)
            {
                if (cardA == null)
                {

                    CardOne = Convert.ToString(card.Tag);
                    int xOne = Grid.GetColumn(element);
                    int yOne = Grid.GetRow(element);
                    xyOne = Convert.ToString(xOne) + Convert.ToString(yOne);
                    cardA = (Image)sender;
                    card.Source = front;
                }
                else if (cardB == null)
                {

                    CardTwo = Convert.ToString(card.Tag);
                    int xTwo = Grid.GetColumn(element);
                    int yTwo = Grid.GetRow(element);
                    xyTwo = Convert.ToString(xTwo) + Convert.ToString(yTwo);
                    cardB = (Image)sender;
                    card.Source = front;
                    CheckCards(CardOne, CardTwo, xyOne, xyTwo);

                }
            }
        }

        /// <summary>
        ///  Checks cards and turns them with the delay
        /// </summary>
        /// <param name="tag1"></param>
        /// <param name="tag2"></param>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        /// 



        private async void CheckCards(string tag1, string tag2, string pos1, string pos2)
        {
            ImageSource back = new BitmapImage(new Uri("Images/background.png", UriKind.Relative));
            IsTaskRunning = true;
            await Task.Delay(300);

            if (tag1.Equals(tag2) && !pos1.Equals(pos2)) // win 
            {

                cardA.Source = null;
                cardB.Source = null;

                //kijkt wie er aan de beurt is en kent punten toe of verandert de beurt.
                if (aandebeurt == 1)
                {
                    P1Points++;
                    Player1Score.Content = P1Points;
                }
                else
                {
                    P2Points++;
                    Player2Score.Content = P2Points;
                }
                

            }
            else if (!tag1.Equals(tag2)) // lose
            {

                cardA.Source = back;
                cardB.Source = back;
                pairs++;

                if (aandebeurt == 1)
                {
                    aandebeurt = 2;
                    Player2name.Background = Brushes.Green;
                    Player1name.Background = Brushes.Orange;
                }
                else
                {
                    aandebeurt = 1;
                    Player1name.Background = Brushes.Green;
                    Player2name.Background = Brushes.Orange;
                }
            }
            else
            {
                cardA.Source = back;
            }

            cardA = null;
            cardB = null;
            IsTaskRunning = false;
        }

        public void Playerstats()
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            Player1name.Background = Brushes.Green;
            Player1name.Content = "Tjeerd";
            Player1name.FontSize = 30;
            Player1name.HorizontalContentAlignment = HorizontalAlignment.Center;
            Grid.SetRow(Player1name, 0);
            Grid.SetColumn(Player1name, 4);
            Grid.SetColumnSpan(Player1name, 2);
            grid.Children.Add(Player1name);

            
            Score1.Content = "Score:";
            Score1.FontSize = 30;
            Score1.HorizontalContentAlignment = HorizontalAlignment.Center;
            Score1.VerticalContentAlignment = VerticalAlignment.Center;
            Grid.SetRow(Score1, 0);
            Grid.SetColumn(Score1, 4);
            grid.Children.Add(Score1);
            
            Player1Score.Content = 0;
            Player1Score.FontSize = 30;
            Player1Score.HorizontalContentAlignment = HorizontalAlignment.Center;
            Player1Score.VerticalContentAlignment = VerticalAlignment.Center;
            Grid.SetRow(Player1Score, 0);
            Grid.SetColumn(Player1Score, 5);
            grid.Children.Add(Player1Score);


            
            Player2name.Background = Brushes.Orange;
            Player2name.Content = "Jacco";
            Player2name.FontSize = 30;
            Player2name.HorizontalContentAlignment = HorizontalAlignment.Center;
            Grid.SetRow(Player2name, 2);
            Grid.SetColumn(Player2name, 4);
            Grid.SetColumnSpan(Player2name, 2);
            grid.Children.Add(Player2name);
            
            Score2.Content = "Score:";
            Score2.FontSize = 30;
            Score2.HorizontalContentAlignment = HorizontalAlignment.Center;
            Score2.VerticalContentAlignment = VerticalAlignment.Center;
            Grid.SetRow(Score2, 2);
            Grid.SetColumn(Score2, 4);
            grid.Children.Add(Score2);
            
            Player2Score.Content = 0;
            Player2Score.FontSize = 30;
            Player2Score.HorizontalContentAlignment = HorizontalAlignment.Center;
            Player2Score.VerticalContentAlignment = VerticalAlignment.Center;
            Grid.SetRow(Player2Score, 2);
            Grid.SetColumn(Player2Score, 5);
            grid.Children.Add(Player2Score);


        }

    }   
}

