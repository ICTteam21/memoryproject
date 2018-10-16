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


        public GameGrid(Grid grid, int cols, int rows, string thema)
        {
            this.grid = grid;
            InitializeGameGrid(cols, rows);

            AddImages(thema, cols, rows);
        }

        private void InitializeGameGrid(int cols, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int j = 0; j < cols; j++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
        /// <summary>
        /// Titlenaam toevoegen aan deze component
        /// </summary>
        private void AddLabel()
        {
            Label title = new Label
            {
                Content = "Memory",
                FontFamily = new FontFamily("Impact"),
                FontSize = 40,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            Grid.SetColumn(title, 1);
            grid.Children.Add(title);
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
        /// <summary>
        /// Voegt de plaatjes aan de grid 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>

        private void AddImages(string thema, int rows, int cols)
        {
            if (thema == "logo")
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
            }else if (thema == "gebouwen")
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
        }
        /// <summary>
        /// Is de functie die bepaald wat er gebeurt als je op een kaart klikt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private int pairs = 0;
        private int kliks = 0;
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
            card.Source = front;

            kliks++;
            if (kliks.Equals(1))
            {
                CardOne = Convert.ToString(card.Tag);
                int xOne = Grid.GetColumn(element);
                int yOne = Grid.GetRow(element);
                xyOne = Convert.ToString(xOne) + Convert.ToString(yOne);
                cardA = (Image)sender;
                
            }
            else if (kliks.Equals(2) )
            {

                CardTwo = Convert.ToString(card.Tag);
                int xTwo = Grid.GetColumn(element);
                int yTwo = Grid.GetRow(element);
                xyTwo = Convert.ToString(xTwo) + Convert.ToString(yTwo);
                cardB = (Image)sender;

                kliks = 0;

                CheckCards(CardOne, CardTwo, xyOne, xyTwo);

            }


        }

        /// <summary>
        ///  Checks cards and turns them with the delay
        /// </summary>
        /// <param name="tag1"></param>
        /// <param name="tag2"></param>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        private async void CheckCards(string tag1, string tag2, string pos1, string pos2)
        {
            ImageSource back = new BitmapImage(new Uri("Images/background.png", UriKind.Relative));

            await Task.Delay(300);

            if (tag1.Equals(tag2) && !pos1.Equals(pos2))
            {

                cardA.Source = null;
                cardB.Source = null;
            }
            else if (!tag1.Equals(tag2))
            {
                
                cardA.Source = back;
                cardB.Source = back;


                pairs++;
            }
            else 
            {
                cardA.Source = back;
            }

        }

    }   
}

