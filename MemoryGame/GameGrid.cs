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

namespace MemoryGame
{
    class GameGrid
    {
        private Grid grid;


        public GameGrid(Grid grid, int cols, int rows)
        {
            this.grid = grid;
            InitializeGameGrid(cols, rows);
     
            AddImages(cols, rows);
        }

        private void InitializeGameGrid( int cols, int rows)
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
            Label title = new Label();
            title.Content = "Memory";
            title.FontFamily = new FontFamily("Impact");
            title.FontSize = 40;
            title.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetColumn(title, 1);
            grid.Children.Add(title);
        }
        /// <summary>
        /// Laad de images op een random manier in een list.
        /// </summary>
        /// <returns></returns>
        private List<ImageSource> GetImageList()
        {
            List<ImageSource> images = new List<ImageSource>();
            for (int i = 0; i < 16; i++)
            {
                int imageNr = i % 8 + 1;
                ImageSource source = new BitmapImage(new Uri("Images/logo" + imageNr + ".png", UriKind.Relative));
                images.Add(source);
            }

            //images.Shuffle();
            return images;
        }
        /// <summary>
        /// Voegt de plaatjes aan de grid 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        
        private void AddImages( int rows, int cols)
        {
            List<ImageSource> images = GetImageList();
            for ( int row = 0; row < rows; row++)
            {
                for(int column = 0; column < cols; column++)
                {
                    Image backgroudImage = new Image();
                    backgroudImage.Source = new BitmapImage(new Uri("Images/background.png", UriKind.Relative));
                    backgroudImage.Tag = images.First();
                    images.RemoveAt(0);
                    backgroudImage.MouseDown += new MouseButtonEventHandler(CardClick);
                    Grid.SetColumn(backgroudImage, column);
                    Grid.SetRow(backgroudImage, row);
                    grid.Children.Add(backgroudImage);
                }
            }
        }
        /// <summary>
        /// Is de functie die bepaald wat er gebeurt als je op een kaart klikt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private int kliks = 0;
        public string CardOne;
        public string xyOne;
        public string xyTwo;

        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            var element = (UIElement)e.Source;


            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            ImageSource back = new BitmapImage(new Uri("Images/background.png", UriKind.Relative));

            kliks++;
            card.Source = front;

            if (kliks.Equals(1))
            {
                CardOne = Convert.ToString(card.Tag);
                int xOne = Grid.GetColumn(element);
                int yOne = Grid.GetRow(element);
                xyOne = Convert.ToString(xOne) + Convert.ToString(yOne);
            }
            else if (kliks.Equals(2))
            {
                string CardTwo = Convert.ToString(card.Tag);
                int xTwo = Grid.GetColumn(element);
                int yTwo = Grid.GetRow(element);
                xyTwo = Convert.ToString(xTwo) + Convert.ToString(yTwo);

                if (CardOne.Equals(CardTwo) && !xyOne.Equals(xyTwo))
                {
                    MessageBox.Show("zijn gelijk");
                }
                else if (!CardTwo.Equals(CardOne))
                {
                    MessageBox.Show("zijn niet gelijk");
                }



                kliks = 0;
            }

        }

    
       

    }
}
