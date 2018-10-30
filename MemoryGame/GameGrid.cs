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
using System.Windows.Threading;

namespace MemoryGame
{
    class GameGrid
    {
        private int time; 
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
        private DispatcherTimer aTimer;
        Label TimerDisplay = new Label();

        string Player1Name = SelectClass.spelernaam1;
        string Player2Name = SelectClass.spelernaam2;
        int newofloadteller;
        int regel = 0;
        int aandebeurt = 1;
        int P1Points = 0;
        int P2Points = 0;
        private int pairs = 0;


        string themavoorsave;
        private int fileCount;
        string pathing;
        string statspath;
        ImageSource BackgroundSource;
        string padnaarsave;
        string tijdelijkestring;

        TimeSpan starttijd;
        TimeSpan eindtijd;
        string totaletijd;

        private Image imgCardOne;
        private Image imgCardTwo;
        private string xyTwo;
        private string xyOne;
        private string tagOne;
        private string tagTwo;

        public List<ImageSource> imagesList = new List<ImageSource>();
        public List<string> plaatjesvolgorde = new List<string>();
        MediaPlayer mplayer = new MediaPlayer();
        MediaPlayer mplayer2 = new MediaPlayer();

        /// <summary>
        /// dit initieert het speelveld
        /// </summary>
        /// <param name="window"></param> 
        /// <param name="grid"></param>
        /// <param name="cols"></param>      Het aantal kolommen van het grid
        /// <param name="rows"></param>      Het aantal rijen van het grid
        /// <param name="thema"></param>     Het thema waarvoor gekozen is.
        /// <param name="newofload"></param> Een int die zegt of het een newgame of een loadgame is.
        public GameGrid(Window window, Grid grid, int cols, int rows, string thema, int newofload)
        {   //settings//

            if (newofload == 1)
            {
                CardFlipSoundEffect();
                MatchSoundEffect();

                themavoorsave = thema;
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
               
                Playerstats(MainClass.aantalSpelers);

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

                themavoorsave = File.ReadLines(thema).Skip(24).Take(1).First();
                BackgroundSource = new BitmapImage(new Uri("Images/cardbacks/" + themavoorsave + "back.png", UriKind.Relative));
                
                this.window = window;
                this.grid = grid;
                InitializeGameGrid(cols, rows);
                addimagesload(cols,rows,thema);

                Player1Name = File.ReadLines(thema).Skip(17).Take(1).First();
                Player2Name = File.ReadLines(thema).Skip(18).Take(1).First();
                aandebeurt = Convert.ToInt32(File.ReadLines(thema).Skip(19).Take(1).First());
                P1Points = Convert.ToInt32(File.ReadLines(thema).Skip(20).Take(1).First());
                P2Points = Convert.ToInt32(File.ReadLines(thema).Skip(21).Take(1).First());

                pairs = Convert.ToInt32(File.ReadLines(thema).Skip(22).Take(1).First());
                SelectClass.diff = Convert.ToInt32(File.ReadLines(thema).Skip(23).Take(1).First());
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
            }

            Savedgamesfolderlocatie();
            CardFlipSoundEffect();
            MatchSoundEffect();
            starttijd = DateTime.Now.TimeOfDay;
            MainmenuButton();
            padnaarstatistics();
            Savegameandclosebutton();

            aTimer = new DispatcherTimer();
            aTimer.Interval = new TimeSpan(0, 0, 1);
            aTimer.Tick += OnTimedEvent;
            aTimer.Start();

            fileCount = (from file in Directory.EnumerateFiles(pathing, "*", SearchOption.AllDirectories)
                         select file).Count();

        }

        /// <summary>
        /// Haalt het pad op van de savedgames folder.
        /// </summary>
        public void Savedgamesfolderlocatie()
        {
            pathing = System.AppDomain.CurrentDomain.BaseDirectory;
            pathing = pathing.Replace("bin", "Textdocs");
            pathing = pathing.Replace("Debug", "SavedGames");

        }

        /// <summary>
        /// maakt het grid aan.
        /// </summary>
        /// <param name="cols"></param> Aantal kolommen.
        /// <param name="rows"></param> Aantal rijen.
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
        private List<ImageSource> GetImagesList(string thema)
        {
            for (int i = 0; i < 16; i++)
            {
                int imageNr = i % 8 + 1;
                ImageSource source = new BitmapImage(new Uri("Images/"+ thema +"/"+ imageNr + ".png", UriKind.Relative));
                imagesList.Add(source);
            }

           imagesList.Shuffle();
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
        /// voegt plaatjes toe aan het grid ingeval van een loadgame
        /// </summary>
        /// <param name="rows"></param> Het aantal rijen van het grid.
        /// <param name="cols"></param> Het aantal kolommen van het grid.
        /// <param name="pad"></param>  De locatie van de savefile.
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
                        Source = BackgroundSource,
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
        /// Slaat img.Tag op en gridpositie in string en geeft ze door aan CheckCards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            var element = (UIElement)e.Source;
            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            

            if (IsTaskRunning == false)
            {
       
                if (imgCardOne == null)
                {
                    
                    imgCardOne = (Image)sender;
                    tagOne = Convert.ToString(front);
                    int xOne = Grid.GetColumn(element);
                    int yOne = Grid.GetRow(element);
                    xyOne = Convert.ToString(xOne) + Convert.ToString(yOne);
                    mplayer.Play();
                    card.Source = front;
                }
                else if (imgCardTwo == null)
                {
                    
                    imgCardTwo = (Image)sender;
                    tagTwo = Convert.ToString(front);
                    int xTwo = Grid.GetColumn(element);
                    int yTwo = Grid.GetRow(element);
                    xyTwo = Convert.ToString(xTwo) + Convert.ToString(yTwo);
                    mplayer.Play();
                    card.Source = front;
                    CheckCards(tagOne, tagTwo, xyOne, xyTwo);

                }
            }
        }

        /// <summary>
        ///  Checks cards and turns them with the delay
        /// </summary>
        /// <param name="tag1"></param> De tag van plaatje1
        /// <param name="tag2"></param> De tag van plaatje2
        /// <param name="pos1"></param> De coördinaten van plaatje1 
        /// <param name="pos2"></param> De coördinaten van plaatje2
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
                P1Points++;
                Player1Score.Content = P1Points;

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
                    mplayer2.Play();
                    if (aandebeurt == 1)
                    {
                        P1Points += 50;
                        Player1Score.Content = P1Points;
                        SetTimer();
                    }
                    else
                    {
                        P2Points += 50;
                        Player2Score.Content = P2Points;
                        SetTimer();
                    }
                }
                else if (win.Equals(false)) // als er niet een paar is gevonden ga dan naar de volgende speler
                {
                    if (aandebeurt.Equals(1))
                    {
                        aandebeurt = 2;
                        Player2name.Background = Brushes.Green;
                        Player1name.Background = Brushes.LightGray;
                        SetTimer();
                    }
                    else
                    {
                        aandebeurt = 1;
                        Player1name.Background = Brushes.Green;
                        Player2name.Background = Brushes.LightGray;
                        SetTimer();
                    }
                }
                if (pairs.Equals(8)) // als er iemand alle plaatjes heeft gewonnen, ga naar highscores
                {
                    aTimer.Stop();
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
                else if (SelectClass.diff.Equals(1)) // 10minuten
                {
                    time = 600;
                }
                else if (SelectClass.diff.Equals(2)) // 5 minuten
                {
                    time = 300;
                }
                else if (SelectClass.diff.Equals(3))// 2 minuten
                {
                    time = 120;
                }
                else if (SelectClass.diff.Equals(4)) // 1 minuut
                {
                    time = 60;
                }
            }
            if (MainClass.aantalSpelers.Equals(2)) // 2 spelers + de timer daarbij
            {
                if (SelectClass.diff.Equals(0))
                {

                }
                else if (SelectClass.diff.Equals(1)) // 45
                {
                    time = 45;
                }
                else if (SelectClass.diff.Equals(2)) // 5 minuten
                {
                    time = 20;
                }
                else if (SelectClass.diff.Equals(3))// 2 minuten
                {
                    time = 10;
                }
                else if (SelectClass.diff.Equals(4)) // 1 minuut
                {
                    time = 5;
                }
            }
        }
        
        /// <summary>
        /// event handler voor de setTimer
        /// Dus wat er gebeurt als de timer is verstreken
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(object source, EventArgs e)
        {
            time--;
            TimerDisplay.Content = String.Format("00:0{0}:{1}", time / 60, time % 60);
            if (time.Equals(0))
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
                        SetTimer();
                    }
                    else
                    {
                        aandebeurt = 1;

                        Player1name.Background = Brushes.Green; // aan de beurt
                        Player2name.Background = Brushes.LightGray;
                        SetTimer();
                    }
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
                if(SelectClass.diff > 0)
                {
                    TimerDisplay.HorizontalContentAlignment = HorizontalAlignment.Center;
                    TimerDisplay.VerticalContentAlignment = VerticalAlignment.Center;
                    TimerDisplay.Background = Brushes.LightGray;
                    TimerDisplay.FontSize = 30;
                    Grid.SetRow(TimerDisplay, 1);
                    Grid.SetColumn(TimerDisplay, 4);
                    Grid.SetColumnSpan(TimerDisplay, 2);
                    grid.Children.Add(TimerDisplay);
                }

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

                if (SelectClass.diff > 0)
                {
                    TimerDisplay.HorizontalContentAlignment = HorizontalAlignment.Center;
                    TimerDisplay.VerticalContentAlignment = VerticalAlignment.Center;
                    TimerDisplay.Background = Brushes.LightGray;
                    TimerDisplay.FontSize = 30;
                    Grid.SetRow(TimerDisplay, 1);
                    Grid.SetColumn(TimerDisplay, 4);
                    Grid.SetColumnSpan(TimerDisplay, 2);
                    grid.Children.Add(TimerDisplay);
                }

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


        /// <summary>
        /// De savegame button en bijbehorende click functie.
        /// </summary>
        public void Savegameandclosebutton() 
        {
           
            SaveGameandClose.Content = "Save Game";
            SaveGameandClose.FontSize = 30;

            Grid.SetRow(SaveGameandClose, 4);
            Grid.SetColumn(SaveGameandClose, 5);

            SaveGameandClose.Click += new RoutedEventHandler(SaveGame_Click); // hierdoor wordt het spel opgeslagen als je dr op klikt
            grid.Children.Add(SaveGameandClose);
        }
        public void SaveGame_Click(Object sender, RoutedEventArgs e)
        {

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
            plaatjesvolgorde.Add(Convert.ToString(SelectClass.diff));
            plaatjesvolgorde.Add(themavoorsave);
            if (newofloadteller == 2)
            { File.Delete(padnaarsave); }

            System.IO.File.WriteAllLines(pathing + (fileCount+1) +  " " + themavoorsave + " " + Player1Name + " vs " + Player2Name + ".sav", plaatjesvolgorde);
            var SelectScherm = new MainMenuWindow(); //create your new form.
            SelectScherm.Show(); //show the new form.
            window.Close();
        }

        /// <summary>
        /// Een button om terug te gaan naar het mainmenu.
        /// </summary>
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
        /// <param name="difficulty"></param>   moeilijkheidsgraad 0 tot 4
        /// <param name="players"></param>      aantal spelers 1 a 2.
        public void thegameisdone(int difficulty, int players)
        {

            if (difficulty > 0)
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Range range;
                int worksheet;

                if (players == 1)
                {
                    worksheet = 4 + difficulty;
                } else
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
        }

        /// <summary>
        /// roept een delete aan maar kijkt eerst of het wel de bedoeling is.
        /// </summary>
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
        /// Geluids effectjes.
        /// </summary>
        private void CardFlipSoundEffect()
        {
            mplayer.Open(new Uri(@"../../Sounds/cardflip.wav", UriKind.Relative)); 
        }
        private void MatchSoundEffect()
        {
            mplayer2.Open(new Uri(@"../../Sounds/correct.wav", UriKind.Relative));

        }
    }
}
    