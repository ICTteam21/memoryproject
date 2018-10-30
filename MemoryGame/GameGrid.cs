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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Timers;
using System.Media;

namespace MemoryGame
{
    class GameGrid
    {
        
        private Window window;
        private Grid grid;
        private bool IsTaskRunning = false;
        Label Player1name = new Label();
        Label Score1 = new Label();
        Label Player1Score = new Label();
        Label Player2name = new Label();
        Label Score2 = new Label();
        Label Player2Score = new Label();
        Button SaveGameandClose = new Button();
        Button BackToMain = new Button();
        private static Timer aTimer; 

        string Player1Name; 
        string Player2Name;
        int newofloadteller;
        int regel = 0;
        int aandebeurt = 1;
        int P1Points = 0;
        int P2Points = 0;
        private int pairs = 0;

        private string themanaamsave;
        private int fileCount;
        string pathing;
        string path3;
        string statspath;
        ImageSource BackgroundSource;
        string padnaarsave;
        string tijdelijkestring;

        TimeSpan starttijd;
        TimeSpan eindtijd;
        string totaletijd;

        public List<string> plaatjesvolgorde = new List<string>();


        public GameGrid(Window window, Grid grid, int cols, int rows, string thema, int newofload)
        {   //settings//

            if (newofload == 1)
            {
                newofloadteller = 1;
                if (MainClass.windowstyle == 2)
                { window.WindowStyle = WindowStyle.None; }
                else
                { window.WindowStyle = WindowStyle.SingleBorderWindow; }
                if (MainClass.windowstate == 2)
                { window.WindowState = WindowState.Maximized; }
                else
                { window.WindowState = WindowState.Normal; }
                BackgroundSource = new BitmapImage(new Uri("Images/cardbacks/"+ thema +"back.png", UriKind.Relative));
                this.window = window;
                this.grid = grid;
                InitializeGameGrid(cols, rows);
                AddImages(thema, cols, rows);
                Savedgamesfolderlocatie();
                Playerstats(MainClass.aantalSpelers);
                padnaarstatistics();
                Savegameandclosebutton();
                starttijd = DateTime.Now.TimeOfDay;
                MainmenuButton();
            


                fileCount = (from file in Directory.EnumerateFiles(path3, "*", SearchOption.AllDirectories)
                             select file).Count();

            }
            else if(newofload == 2)
            {
                newofloadteller = 2;
                padnaarsave = thema;
                if (MainClass.windowstyle == 2)
                { window.WindowStyle = WindowStyle.None; }
                else
                { window.WindowStyle = WindowStyle.SingleBorderWindow; }
                if (MainClass.windowstate == 2)
                { window.WindowState = WindowState.Maximized; }
                else
                { window.WindowState = WindowState.Normal; }
                BackgroundSource = new BitmapImage(new Uri("Images/cardbacks/" + thema + "back.png", UriKind.Relative));
                this.window = window;
                this.grid = grid;
                InitializeGameGrid(cols, rows);
                addimagesload(cols,rows,thema);
                Savedgamesfolderlocatie();

                if (Convert.ToInt32(File.ReadLines(thema).Skip(16).Take(1).First()) == 1)
                {
                    Player1Name = File.ReadLines(thema).Skip(17).Take(1).First();
                    P1Points = Convert.ToInt32(File.ReadLines(thema).Skip(16).Take(1).First());

                } else
                {
                    Player1Name = File.ReadLines(thema).Skip(17).Take(1).First();
                    Player2Name = File.ReadLines(thema).Skip(18).Take(1).First();
                    aandebeurt = Convert.ToInt32(File.ReadLines(thema).Skip(19).Take(1).First());



                    P1Points = Convert.ToInt32(File.ReadLines(thema).Skip(20).Take(1).First());
                    P2Points = Convert.ToInt32(File.ReadLines(thema).Skip(21).Take(1).First());
                }

                pairs = Convert.ToInt32(File.ReadLines(thema).Skip(22).Take(1).First());
                Playerstats(Convert.ToInt32(File.ReadLines(thema).Skip(16).Take(1).First()));

                if (aandebeurt == 1)
                {
                    Player1name.Background = Brushes.Green;
                    Player2name.Background = Brushes.LightGray;
                }
                else
                {
                    Player2name.Background = Brushes.Green;
                    Player1name.Background = Brushes.LightGray;
                }

                padnaarstatistics();
                Savegameandclosebutton();
                starttijd = DateTime.Now.TimeOfDay;
                MainmenuButton();

                
                fileCount = (from file in Directory.EnumerateFiles(path3, "*", SearchOption.AllDirectories)
                             select file).Count();

            }
        }

        public void Savedgamesfolderlocatie()
        {
            pathing = System.AppDomain.CurrentDomain.BaseDirectory;
            //path2 = pathing.Replace("bin", "Textdocs");
            //path2 = path2.Replace("Debug", "NewGame");

            path3 = pathing.Replace("bin", "Textdocs");
            path3 = path3.Replace("Debug", "SavedGames");

            //Player1Name = File.ReadLines(path2 + "New.txt").Skip(0).Take(1).First();
            //Player2Name = File.ReadLines(path2 + "New.txt").Skip(1).Take(1).First();
            Player1Name = SelectClass.spelernaam1;
            Player2Name = SelectClass.spelernaam2;


        }
        
        private void InitializeGameGrid(int cols, int rows)
        {

            //rijen = rows;
            //kolommen = cols;
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
        /// 
        public List<ImageSource> imagesList = new List<ImageSource>();

        private List<ImageSource> GetImagesList(string thema)
        {



            for (int i = 0; i < 16; i++)
            {
                int imageNr = i % 8 + 1;
                ImageSource source = new BitmapImage(new Uri("Images/"+ thema +"/"+ imageNr + ".png", UriKind.Relative));
                imagesList.Add(source);
            }

           // imagesList.Shuffle();
            return imagesList;


        }


        /// <summary>
        /// Voegt de plaatjes aan de grid 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        
        private void AddImages(string thema, int rows, int cols)
        {
            // get lists
            List<ImageSource> images = GetImagesList(thema);

            // hier wordt het geselecteerde thema aangeroepen
            if (thema.Equals("logos"))
            {
                themanaamsave = "Logo's";
                for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < cols; column++)
                    {
                        Image backgroudImage = new Image
                        {
                            Source = BackgroundSource,
                            Tag = images.First()
                        };
                        tijdelijkestring = Convert.ToString(backgroudImage.Tag);
                        plaatjesvolgorde.Add(tijdelijkestring);
                        images.RemoveAt(0);
                        backgroudImage.MouseDown += new MouseButtonEventHandler(CardClick);
                        Grid.SetColumn(backgroudImage, column);
                        Grid.SetRow(backgroudImage, row);
                        grid.Children.Add(backgroudImage);
                    }
                }
            }
            else if (thema.Equals("gebouwen"))
            {
                themanaamsave = "Gebouwen";
                for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < cols; column++)
                    {
                        Image backgroudImage = new Image
                        {
                            Source = BackgroundSource,
                            Tag = images.First()
                        };
                        tijdelijkestring = Convert.ToString(backgroudImage.Tag);
                        plaatjesvolgorde.Add(tijdelijkestring);
                        images.RemoveAt(0);
                        backgroudImage.MouseDown += new MouseButtonEventHandler(CardClick);
                        Grid.SetColumn(backgroudImage, column);
                        Grid.SetRow(backgroudImage, row);
                        grid.Children.Add(backgroudImage);
                    }
                }
            }
            else if (thema.Equals("disney"))
            {

                themanaamsave = "Disney";
                for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < cols; column++)
                    {
                        Image backgroudImage = new Image
                        {
                            Source = BackgroundSource,
                            Tag = images.First()
                        };
                        plaatjesvolgorde.Add(Convert.ToString(backgroudImage.Tag));

                        images.RemoveAt(0);
                        backgroudImage.MouseDown += new MouseButtonEventHandler(CardClick);
                        Grid.SetColumn(backgroudImage, column);
                        Grid.SetRow(backgroudImage, row);
                        grid.Children.Add(backgroudImage);
                    }
                }
            }
            else if (thema.Equals("car"))
            {

                themanaamsave = "Autos";
                for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < cols; column++)
                    {
                        Image backgroudImage = new Image
                        {
                            Source = BackgroundSource,
                            Tag = images.First()
                        };
                        plaatjesvolgorde.Add(Convert.ToString(backgroudImage.Tag));
                        images.RemoveAt(0);
                        backgroudImage.MouseDown += new MouseButtonEventHandler(CardClick);
                        Grid.SetColumn(backgroudImage, column);
                        Grid.SetRow(backgroudImage, row);
                        grid.Children.Add(backgroudImage);
                    }
                }
            }
            else if (thema.Equals("planeten"))
            {

                themanaamsave = "Planeten";
                for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < cols; column++)
                    {
                        Image backgroudImage = new Image
                        {
                            Source = BackgroundSource,
                            Tag = images.First()
                        };
                        plaatjesvolgorde.Add(Convert.ToString(backgroudImage.Tag));
                        images.RemoveAt(0);
                        backgroudImage.MouseDown += new MouseButtonEventHandler(CardClick);
                        Grid.SetColumn(backgroudImage, column);
                        Grid.SetRow(backgroudImage, row);
                        grid.Children.Add(backgroudImage);
                    }
                }
            }
            else if (thema.Equals("shapes"))
            {

                themanaamsave = "Shapes";
                for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < cols; column++)
                    {
                        Image backgroudImage = new Image
                        {
                            Source = BackgroundSource,
                            Tag = images.First()
                        };
                        plaatjesvolgorde.Add(Convert.ToString(backgroudImage.Tag));
                        images.RemoveAt(0);
                        backgroudImage.MouseDown += new MouseButtonEventHandler(CardClick);
                        Grid.SetColumn(backgroudImage, column);
                        Grid.SetRow(backgroudImage, row);
                        grid.Children.Add(backgroudImage);
                    }
                }
            }

            if (SelectClass.diff.Equals(0))
            {

            }
            else
            {
                MessageBox.Show("Druk op ok om de tijd te starten", "Het spel gaat beginnen!");
                SetTimer();
            }

        }

        private void addimagesload(int rows, int cols,string pad)
        {

            plaatjesvolgorde.Clear();

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < cols; column++)
                {
                    ImageSource sourceplaatje = new BitmapImage(new Uri(File.ReadLines(pad).Skip(regel).Take(1).First(), UriKind.Relative));
                    if (File.ReadLines(pad).Skip(regel).Take(1).First() == "nulll")
                    {
                        sourceplaatje = null;
                    }
                    

                    Image backgroudImage = new Image
                    {
                        Source = new BitmapImage(new Uri("Images/background.png", UriKind.Relative)),
                        Tag = sourceplaatje
                    };

                    tijdelijkestring = Convert.ToString(backgroudImage.Tag);
                    if(sourceplaatje == null)
                    { plaatjesvolgorde.Add("nulll"); }
                    else
                    { plaatjesvolgorde.Add(tijdelijkestring); }
                    
                    

                    backgroudImage.MouseDown += new MouseButtonEventHandler(CardClick);
                    Grid.SetColumn(backgroudImage, column);
                    Grid.SetRow(backgroudImage, row);
                    if (File.ReadLines(pad).Skip(regel).Take(1).First() == "nulll")
                    {

                    }
                    else
                    {
                        grid.Children.Add(backgroudImage);
                    } 
                    regel++;
                }
            }








            if (SelectClass.diff.Equals(0))
            {

            }
            else
            {
                MessageBox.Show("Druk op ok om de tijd te starten", "Het spel gaat beginnen!");
                SetTimer();
            }


        }
        /// <summary>
        /// Is de functie die bepaald wat er gebeurt als je op een kaart klikt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private Image imgCardOne;
        private Image imgCardTwo;
        private string xyTwo;
        private string xyOne;
        private string tagOne;
        private string tagTwo;


        /// <summary>
        /// Slaat img.Tag op en gridpositie in string en geeft ze door aan CheckCards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            var element = (UIElement)e.Source;
            Image card = (Image)sender;

            ImageSource front = (ImageSource)card.Tag;
            CardFlipSoundEffect();

            if (IsTaskRunning == false)
            {
                if (imgCardOne == null)
                {
                    imgCardOne = (Image)sender;
                    tagOne = Convert.ToString(front);
                    int xOne = Grid.GetColumn(element);
                    int yOne = Grid.GetRow(element);
                    xyOne = Convert.ToString(xOne) + Convert.ToString(yOne);
                    card.Source = front;
                }
                else if (imgCardTwo == null)
                {
                    imgCardTwo = (Image)sender;
                    tagTwo = Convert.ToString(front);
                    int xTwo = Grid.GetColumn(element);
                    int yTwo = Grid.GetRow(element);
                    xyTwo = Convert.ToString(xTwo) + Convert.ToString(yTwo);
                    card.Source = front;
                    CheckCards(tagOne, tagTwo, xyOne, xyTwo);

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
        private bool win;
        private async void CheckCards(string tag1, string tag2, string pos1, string pos2)
        {

            IsTaskRunning = true;
            await Task.Delay(300);
            string Card1 = tag1.Substring(tag1.Length - 5);
            string Card2 = tag2.Substring(tag2.Length - 5);

            bool CardsEqual = Card1.Equals(Card2);
            bool PosEqual = pos1.Equals(pos2);

            if (CardsEqual && !PosEqual) // win 
            {
                MatchSoundEffect();
                win = true;
                pairs++;
                imgCardOne.Source = null;
                imgCardTwo.Source = null;
                CheckTurns();

                imgCardOne = null;
                imgCardTwo = null;

                for (int i = 0; i < plaatjesvolgorde.Count; i++)
                {
                    if (plaatjesvolgorde[i] == "nulll")
                    {  }
                    else
                    {
                        string plaatje = plaatjesvolgorde[i].Substring(plaatjesvolgorde[i].Length - 5);
                        if (plaatje == Card1)
                        {
                            plaatjesvolgorde[i] = plaatjesvolgorde[i].Replace(plaatjesvolgorde[i], "nulll");
                        }
                    }
                }

            }
            else if (!CardsEqual && !PosEqual) // lose
            {
                win = false;
                imgCardOne.Source = BackgroundSource;
                imgCardTwo.Source = BackgroundSource;
                CheckTurns();

                imgCardOne = null;
                imgCardTwo = null;
            }
            if (CardsEqual || PosEqual) // op hetzelfde kaartje geklikt
            {
                imgCardTwo = null;
                
                imgCardTwo = null;
            }



            IsTaskRunning = false;
        }
        /// <summary>
        ///  kijkt wie er aan de beurt is en kent punten toe 
        ///  kijkt eerst of er 1 of 2 spelers zijn.
        /// </summary>
        private void CheckTurns()
        {
            if (MainClass.aantalSpelers.Equals(1)) // als er 1 speler is 
            {
                if (win.Equals(true)) // geef punten aan speler als er een paar is gevonden 
                {
                    P1Points += 50;
                    Player1Score.Content = P1Points;
                }
                if (pairs.Equals(8) && !SelectClass.diff.Equals(0)) 
                {
                    eindtijd = DateTime.Now.TimeOfDay;
                    var diff = eindtijd.Subtract(starttijd);
                    totaletijd = String.Format("{0}:{1}:{2}", diff.Hours, diff.Minutes, diff.Seconds);

                    MessageBox.Show("Goed gedaan! Je hebt binnen de tijd alle paren gevonden!", "Klik op ok om de highscores te zien");
                    thegameisdone(SelectClass.diff, 1);
                    var highscoresWindow = new HighScores();
                    Deletesave();
                    window.Close();
                    highscoresWindow.Show();

                }else if (pairs.Equals(8))
                {
                    eindtijd = DateTime.Now.TimeOfDay;
                    var diff = eindtijd.Subtract(starttijd);
                    totaletijd = String.Format("{0}:{1}:{2}", diff.Hours, diff.Minutes, diff.Seconds);

                    MessageBox.Show("Goed gedaan! Je hebt alle paren gevonden!", "Klik op ok om de highscores te zien");
                    thegameisdone(SelectClass.diff, 1);
                    var highscoresWindow = new HighScores();
                    Deletesave();
                    window.Close();
                    highscoresWindow.Show();

                }
            }
            else if (MainClass.aantalSpelers.Equals(2)) // als er 2 spelers zijn 
            {
                if (win.Equals(true)) // als de huidige speler de kaartjes bij elkaar heeft geef punten 
                {

                    if (aandebeurt == 1)
                    {
                        P1Points += 50;
                        Player1Score.Content = P1Points;
                    }
                    else
                    {
                        P2Points += 50;
                        Player2Score.Content = P2Points;
                    }
                }
                else if (win.Equals(false)) // als er niet een paar is gevonden ga dan naar de volgende speler
                {
                    if (aandebeurt.Equals(1))
                    {
                        aandebeurt = 2;
                        Player2name.Background = Brushes.Green;
                        Player1name.Background = Brushes.LightGray;
                    }
                    else
                    {
                        aandebeurt = 1;
                        Player1name.Background = Brushes.Green;
                        Player2name.Background = Brushes.LightGray;
                    }
                }
                if (pairs.Equals(8)) // als er iemand alle plaatjes heeft gewonnen, ga naar highscores
                {
                    if (P1Points > P2Points) // hier heeft speler 1 gewonnen
                    {
                        int pDiff = P1Points - P2Points;

                        eindtijd = DateTime.Now.TimeOfDay;
                        var diff = eindtijd.Subtract(starttijd);
                        totaletijd = String.Format("{0}:{1}:{2}",diff.Hours,diff.Minutes, diff.Seconds);

                        MessageBox.Show("Speler " + Player1Name + " heeft gewonnen! \n" + Player1Name + " heeft met " + pDiff + " punten meer gewonnen! het duurde: " + totaletijd, "Klik op ok om je highscores te zien");
                        thegameisdone(SelectClass.diff, 2);
                        var highscoresWindow = new HighScores();
                        Deletesave();
                        window.Close();
                        highscoresWindow.Show();
                    }
                    else if ( P1Points < P2Points){ // hier heeft speler 2 gewonnen
                        int pDiff = P2Points - P1Points;

                        eindtijd = DateTime.Now.TimeOfDay;
                        var diff = eindtijd.Subtract(starttijd);
                        totaletijd = String.Format("{0}:{1}:{2}", diff.Hours, diff.Minutes, diff.Seconds);

                        MessageBox.Show("Speler " + Player2Name + " heeft gewonnen! \n" + Player2Name + " heeft met " + pDiff + " punten meer gewonnen! het duurde: " + totaletijd, "Klik op ok om je highscores te zien");
                        thegameisdone(SelectClass.diff, 2);
                        var highscoresWindow = new HighScores();
                        Deletesave();
                        window.Close();
                        highscoresWindow.Show();
                    }
                    else if (P1Points.Equals(P2Points)) // hier is het gelijkspel gebleven
                    {
                        eindtijd = DateTime.Now.TimeOfDay;
                        var diff = eindtijd.Subtract(starttijd);
                        totaletijd = String.Format("{0}:{1}:{2}", diff.Hours, diff.Minutes, diff.Seconds);

                        MessageBox.Show( Player1Name + " en " + Player2Name + " jullie zijn erg aan elkaar gewaagt !\n  " + "Probeer het nog een keer! het duurde: " + totaletijd, "Klik op ok om je highscores te zien");
                        thegameisdone(SelectClass.diff, 2);
                        var highscoresWindow = new HighScores();
                        Deletesave();
                        window.Close();
                        highscoresWindow.Show();
                    }
                }

            }
        }
        /// <summary>
        /// De timer en hierin de handelingen die er uitvoerd moeten 
        /// Resetten of gwn klaar etc.
        /// </summary>
        /// <param name="diff"> diff is de "globale" parameter dei gelijk staat aan de moeilijkheidsgraad </param>
        private void SetTimer()
        {
            if (MainClass.aantalSpelers.Equals(1)) // 1 speler + timer daarbij
            {
                if (SelectClass.diff.Equals(0))
                {

                }
                else if (SelectClass.diff.Equals(1))
                {
                    aTimer = new Timer(6000000);
                    aTimer.Elapsed += OnTimedEvent;
                    aTimer.Enabled = true;
                }
                else if (SelectClass.diff.Equals(2))
                {
                    aTimer = new Timer(3000000);
                    aTimer.Elapsed += OnTimedEvent;
                    aTimer.Enabled = true;
                }
                else if (SelectClass.diff.Equals(3))
                {
                    aTimer = new Timer(120000);
                    aTimer.Elapsed += OnTimedEvent;
                    aTimer.Enabled = true;
                }
                else if (SelectClass.diff.Equals(4))
                {
                    aTimer = new Timer(60000);
                    aTimer.Elapsed += OnTimedEvent;
                    aTimer.Enabled = true;
                }
            }
            if (MainClass.aantalSpelers.Equals(2)) // 2 spelers + de timer daarbij
            {
                if (SelectClass.diff.Equals(0))
                {

                }
                else if (SelectClass.diff.Equals(1))
                {
                    aTimer = new Timer(45000);
                    aTimer.Elapsed += OnTimedEvent;
                    aTimer.Enabled = true;
                }
                else if (SelectClass.diff.Equals(2))
                {
                    aTimer = new Timer(20000);
                    aTimer.Elapsed += OnTimedEvent;
                    aTimer.Enabled = true;
                }
                else if (SelectClass.diff.Equals(3))
                {
                    aTimer = new Timer(10000);
                    aTimer.Elapsed += OnTimedEvent;
                    aTimer.Enabled = true;
                }
                else if (SelectClass.diff.Equals(4))
                {
                    aTimer = new Timer(5000);
                    aTimer.Elapsed += OnTimedEvent;
                    aTimer.Enabled = true;
                }
            }
        }
        /// <summary>
        /// event handler voor de setTimer
        /// Dus wat er gebeurt als de timer is verstreken
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (MainClass.aantalSpelers.Equals(1))
            {
                MessageBox.Show("De tijd is op! ", "Klik om terug te gaan");
                var eindeSpelDoorTimer = new HighScores();
                Deletesave();
                eindeSpelDoorTimer.Show();
                window.Close();
            }
            if (MainClass.aantalSpelers.Equals(2))
            {
                if (aandebeurt.Equals(1)) //hier wordt de achtegrond kleur van de persoon groen/grijs gekleurd om te zien wie er aan de beurt is
                {
                    aandebeurt = 2;

                    Player2name.Background = Brushes.Green; // aan de beurt
                    Player1name.Background = Brushes.LightGray;
                }
                else
                {
                    aandebeurt = 1;

                    Player1name.Background = Brushes.Green; // aan de beurt
                    Player2name.Background = Brushes.LightGray;
                }
            }


        }
       
        /// <summary>
        /// hieronder wordt gekeken of je singleplayer of multiplayer speelt en laadt daarbij de benodigdheden bij
        /// </summary>
        /// <param name="aantalSpelers"></param>
        public void Playerstats(int aantalSpelers)
        {
            if (aantalSpelers.Equals(1))
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());

                // door de code hieronder komt het scoreboard + naam van player 1 in beeld

                Player1name.Background = Brushes.Green;
                Player1name.Content = Player1Name;
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

                Player1Score.Content = P1Points;
                Player1Score.FontSize = 30;
                Player1Score.HorizontalContentAlignment = HorizontalAlignment.Center;
                Player1Score.VerticalContentAlignment = VerticalAlignment.Center;
                Grid.SetRow(Player1Score, 0);
                Grid.SetColumn(Player1Score, 5);
                grid.Children.Add(Player1Score);
            }
            if (aantalSpelers.Equals(2)) // door de code hieronder komt het scoreboard + naam van player 1 in beeld
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());

                Player1name.Background = Brushes.Green;
                Player1name.Content = Player1Name;
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

                Player1Score.Content = P1Points;
                Player1Score.FontSize = 30;
                Player1Score.HorizontalContentAlignment = HorizontalAlignment.Center;
                Player1Score.VerticalContentAlignment = VerticalAlignment.Center;
                Grid.SetRow(Player1Score, 0);
                Grid.SetColumn(Player1Score, 5);
                grid.Children.Add(Player1Score);

                Player2name.Background = Brushes.LightGray;
                Player2name.Content = Player2Name;
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

                Player2Score.Content = P2Points;
                Player2Score.FontSize = 30;
                Player2Score.HorizontalContentAlignment = HorizontalAlignment.Center;
                Player2Score.VerticalContentAlignment = VerticalAlignment.Center;
                Grid.SetRow(Player2Score, 2);
                Grid.SetColumn(Player2Score, 5);
                grid.Children.Add(Player2Score);
            }  
        }



        public void Savegameandclosebutton() 
        {
           
            SaveGameandClose.Content = "Save Game";
            SaveGameandClose.FontSize = 30;

            Grid.SetRow(SaveGameandClose, 4);
            Grid.SetColumn(SaveGameandClose, 5);

            SaveGameandClose.Click += new RoutedEventHandler(SaveGame_Click); // hierdoor wordt het spel opgeslagen als je dr op klikt
            grid.Children.Add(SaveGameandClose);
        }


        /// <summary>
        /// Dit slaat het spel op in een text bestand.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SaveGame_Click(Object sender, RoutedEventArgs e)
        {

            string pathing;
            string path2;
            pathing = System.AppDomain.CurrentDomain.BaseDirectory;
            path2 = pathing.Replace("bin", "Textdocs");
            path2 = path2.Replace("Debug", "SavedGames");
            if (newofloadteller == 1)
            {
                plaatjesvolgorde.Add(Convert.ToString(MainClass.aantalSpelers));
            }
            else
            {
                plaatjesvolgorde.Add(File.ReadLines(padnaarsave).Skip(16).Take(1).First());
            }

            plaatjesvolgorde.Add(Player1Name);
            plaatjesvolgorde.Add(Player2Name);
            plaatjesvolgorde.Add(Convert.ToString(aandebeurt));
            plaatjesvolgorde.Add(Convert.ToString(P1Points));
            plaatjesvolgorde.Add(Convert.ToString(P2Points));
            plaatjesvolgorde.Add(Convert.ToString(pairs));

            if (newofloadteller == 2)
            { File.Delete(padnaarsave); }

            System.IO.File.WriteAllLines(path3 + (fileCount+1) +  " " + themanaamsave  + Player1Name + " vs " + Player2Name + ".sav", plaatjesvolgorde);
            var SelectScherm = new MainMenuWindow(); //create your new form.
            SelectScherm.Show(); //show the new form.
            window.Close();
        }

        public void MainmenuButton() // button verwijst je terug naar het main menu
        {
            BackToMain.Content = "Main Menu";
            BackToMain.FontSize = 30;

            Grid.SetRow(BackToMain, 4);
            Grid.SetColumn(BackToMain, 4);

            BackToMain.Click += BackToMain_Click;
            grid.Children.Add(BackToMain);

        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {

            var SelectScherm = new MainMenuWindow(); //create your new form.
            SelectScherm.Show(); //show the new form.
            window.Close();

        }

        /// <summary>
        /// Deze methode moet opgeroepen worden wanneer een spel klaar is.
        /// Hij zal vervolgens de data wegschrijven in excel.
        /// </summary>
        /// <param name="difficulty"></param>   moeilijkheidsgraad 1 tot 4
        /// <param name="players"></param>      aantal spelers 1 a 2.
        public void thegameisdone(int difficulty, int players)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            int worksheet;

            if(players == 1)
            {
                worksheet = 4 + difficulty;
            }else
            {
                worksheet = difficulty;
            }


            xlApp = new Microsoft.Office.Interop.Excel.Application();

            xlWorkBook = xlApp.Workbooks.Open(statspath, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlApp.UserControl = true;

            // dit selecteert op het moment het eerste werkblad ( variabel op difficulty en players ).
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(worksheet);
            range = xlWorkSheet.UsedRange;

            //geeft het aantal gebruikte rijen terug.
            double rij = xlApp.WorksheetFunction.CountA(xlWorkSheet.Columns[1]);

            //voert data in op basis van spelers.
            if (players == 1)
            {
                xlWorkSheet.Cells[rij + 1, 1] = Player1Name;
                xlWorkSheet.Cells[rij + 1, 2] = P1Points;
                xlWorkSheet.Cells[rij + 1, 3] = totaletijd;
            }
            else
            {
                xlWorkSheet.Cells[rij + 1, 1] = Player1Name;
                xlWorkSheet.Cells[rij + 1, 2] = P1Points;
                xlWorkSheet.Cells[rij + 1, 3] = totaletijd;
                xlWorkSheet.Cells[rij + 2, 1] = Player2Name;
                xlWorkSheet.Cells[rij + 2, 2] = P2Points;
                xlWorkSheet.Cells[rij + 2, 3] = totaletijd;
            }
            //dit pakt alle cellen met daarin scores en namen en sorteerd deze.
            range = xlWorkSheet.Range[xlWorkSheet.Cells[3, 1], xlWorkSheet.Cells[rij + 2, 3]];
            range.Sort(range.Columns[2], Excel.XlSortOrder.xlDescending);

            xlWorkBook.Save();
            xlApp.Quit();

        }

        public void Deletesave()
        {
            if (newofloadteller == 2)
            { File.Delete(padnaarsave); }
        }
        /// <summary>
        /// Haalt het pad op voor de methode die naar excel schrijft.
        /// </summary>
        public void padnaarstatistics()
        {
            pathing = System.AppDomain.CurrentDomain.BaseDirectory;
            statspath = pathing.Replace("bin", "Statistics");
            statspath = statspath.Replace("Debug", "Highscorestats");
            statspath = statspath + "HighscoresMemory.xlsx";

        }

        /// <summary>
        /// 
        /// </summary>
        private void CardFlipSoundEffect()
        {

            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri(@"../../Sounds/cardflip.wav", UriKind.Relative));
            mplayer.Play();
        }
        private void MatchSoundEffect()
        {
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri(@"../../Sounds/correct.wav", UriKind.Relative));
            mplayer.Play();
        }
    }
}
    