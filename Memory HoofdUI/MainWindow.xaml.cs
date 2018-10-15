using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;

namespace Memory_HoofdUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Hier begint het programma.
        /// Hij Calld de MainClass die het startscherm opbouwt.
        /// </summary>


        MainClass grid;

        public MainWindow()
        {
            InitializeComponent();

            grid = new MainClass(StartScherm);


        }



        /// <summary>
        /// Dit is het startscherm.
        /// </summary>
        public void StartUi()
        {
            Button newgame = new Button();
            newgame.Content = "New Game";
            newgame.FontSize = 20;
            newgame.Background = Brushes.Green;
            newgame.Click += new RoutedEventHandler(newgame_click);
            stackPanel1.Children.Add(newgame);

            Button loadgame = new Button();
            loadgame.Content = "Load Game";
            loadgame.FontSize = 20;
            loadgame.Background = Brushes.Green;
            loadgame.Click += new RoutedEventHandler(loadgame_click);
            stackPanel1.Children.Add(loadgame);

            Button highscores = new Button();
            highscores.Content = "Highscores";
            highscores.FontSize = 20;
            highscores.Background = Brushes.Green;
            highscores.Click += new RoutedEventHandler(highscores_click);
            stackPanel1.Children.Add(highscores);

            Button credits = new Button();
            credits.Content = "Credits";
            credits.FontSize = 20;
            credits.Background = Brushes.Green;
            credits.Click += new RoutedEventHandler(credits_click);
            stackPanel1.Children.Add(credits);

        }


        /// <summary>
        /// Dit is het scherm van het knopje NewGame.
        /// Hier kun je keuze's maken die leiden tot een nieuwe spelletje.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void newgame_click(object sender, RoutedEventArgs e)
        {
            stackPanel1.Children.Clear();
            Button newgame = new Button();
            newgame.Content = "New Game";
            newgame.FontSize = 20;
            newgame.Background = Brushes.Blue;
            newgame.Click += new RoutedEventHandler(newgame_click);
            stackPanel1.Children.Add(newgame);

            Button loadgame = new Button();
            loadgame.Content = "Load Game";
            loadgame.FontSize = 20;
            loadgame.Background = Brushes.Red;
            loadgame.Click += new RoutedEventHandler(loadgame_click);
            stackPanel1.Children.Add(loadgame);


        }


        /// <summary>
        /// Dit is het scherm van het knopje LoadGame,
        /// Hier kun je kiezen welk spel je wilt laden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void loadgame_click(object sender, RoutedEventArgs e)
        {
            stackPanel1.Children.Clear();
            Button newgame = new Button();
            newgame.Content = "New Game";
            newgame.FontSize = 20;
            newgame.Background = Brushes.Yellow;
            newgame.Click += new RoutedEventHandler(newgame_click);
            stackPanel1.Children.Add(newgame);
        }


        /// <summary>
        /// Dit is het scherm waarin je de Highscore's te zien krijgt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void highscores_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Highscores");
        }


        /// <summary>
        /// Dit is het scherm dat de credits toont.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void credits_click(object sender, RoutedEventArgs e)
        {
            stackPanel1.Children.Clear();
            Label wat = new Label();
            wat.FontSize = 50;
            wat.Content = "Credits: ";
            Label Chris = new Label();
            Chris.FontSize = 20;
            Chris.Content = "Chris-Jan";
            Label Robin = new Label();
            Robin.FontSize = 20;
            Robin.Content = "Robin";
            Label Maurice = new Label();
            Maurice.FontSize = 20;
            Maurice.Content = "Maurice";
            Label Jacco = new Label();
            Jacco.FontSize = 20;
            Jacco.Content = "Jacco";
            Label Tjeerd = new Label();
            Tjeerd.FontSize = 20;
            Tjeerd.Content = "Tjeerd";
            Button Terug = new Button();
            Terug.Content = "New Game";
            Terug.FontSize = 20;
            Terug.Background = Brushes.Red;
            Terug.Click += new RoutedEventHandler(terug_click);

            stackPanel1.Children.Add(Terug);
            stackPanel1.Children.Add(wat);
            stackPanel1.Children.Add(Chris);
            stackPanel1.Children.Add(Robin);
            stackPanel1.Children.Add(Maurice);
            stackPanel1.Children.Add(Jacco);
            stackPanel1.Children.Add(Tjeerd);


        }

        /// <summary>
        /// Deze Click functie stuurt je terug naar het hoofdmenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void terug_click(object sender, RoutedEventArgs e)
        {
            stackPanel1.Children.Clear();
            StartUi();
        }

        /// <summary>
        /// Moet het grid resetten.
        /// </summary>

        public void reset()
        {
            MessageBox.Show("Wat?????");

            StartScherm.Background = Brushes.Gray;
            StartScherm.Children.Clear();

            StartUi();

            MessageBox.Show("Wat!!!!!!");
        }

    }
}
