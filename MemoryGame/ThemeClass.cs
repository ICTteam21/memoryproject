using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace MemoryGame
{
    class ThemaClass
    {
        private Themas window;
        private Grid grid;
        Image logo = new Image();
        Image gebouwen = new Image();
        Image disney = new Image();
        Image autos = new Image();
        Image planeten = new Image();
        Image shapes = new Image();


        public ThemaClass(Themas window, Grid grid, int kolommen, int rijen)
        {
            //settings//
            if (MainClass.windowstyle == 2)
            { window.WindowStyle = WindowStyle.None; }
            else
            { window.WindowStyle = WindowStyle.SingleBorderWindow; }
            if (MainClass.windowstate == 2)
            { window.WindowState = WindowState.Maximized; }
            else
            { window.WindowState = WindowState.Normal; }

            this.window = window;
            this.grid = grid;
            rijen = 20;
            kolommen = 13;
            InitializeMain(kolommen, rijen);
            Title();
            Theme1();
            Theme2();
            Theme3();
            Theme4();
            Theme5();
            Theme6();

            AddBack();
            


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
                FontSize = 120,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Bahnschrift"),
            };

            Grid.SetRow(title, 0);
            Grid.SetColumn(title, 0);
            Grid.SetColumnSpan(title, 13);
            Grid.SetRowSpan(title, 3);
            grid.Children.Add(title);
        }
        // thema 1 = disney
        private void Theme1()
        {
            disney.Source = new BitmapImage(new Uri("Images/banners/disneybanner.png", UriKind.Relative));
            disney.MouseDown += new MouseButtonEventHandler(SelectThema);
            Grid.SetRow(disney, 4);
            Grid.SetColumn(disney, 1);
            Grid.SetColumnSpan(disney, 5);
            Grid.SetRowSpan(disney, 6);
            grid.Children.Add(disney);

        }
        // thema 2 = gebouwen
        private void Theme2()
        {
            gebouwen.Source = new BitmapImage(new Uri("Images/banners/gebouwenbanner.png", UriKind.Relative));
            gebouwen.MouseDown += new MouseButtonEventHandler(SelectThema);
            Grid.SetRow(gebouwen, 8);
            Grid.SetColumn(gebouwen, 1);
            Grid.SetColumnSpan(gebouwen, 5);
            Grid.SetRowSpan(gebouwen, 6);
            grid.Children.Add(gebouwen);
        }

        // thema 3 = logo
        private void Theme3()
        {
            logo.Source = new BitmapImage(new Uri("Images/banners/logobanner.png", UriKind.Relative));
            logo.MouseDown += new MouseButtonEventHandler(SelectThema);
            Grid.SetRow(logo, 12);
            Grid.SetColumn(logo, 1);
            Grid.SetColumnSpan(logo, 5);
            Grid.SetRowSpan(logo, 6);
            grid.Children.Add(logo);
        }
        // thema 4 = auto
        private void Theme4()
        {
            autos.Source = new BitmapImage(new Uri("Images/banners/autobanner.png", UriKind.Relative));
            autos.MouseDown += new MouseButtonEventHandler(SelectThema);
            Grid.SetRow(autos, 4);
            Grid.SetColumn(autos, 7);
            Grid.SetColumnSpan(autos, 5);
            Grid.SetRowSpan(autos, 6);
            grid.Children.Add(autos);
        }
        // thema 5 = planeten
        private void Theme5()
        {
            planeten.Source = new BitmapImage(new Uri("Images/banners/planetenbanner.png", UriKind.Relative));
            planeten.MouseDown += new MouseButtonEventHandler(SelectThema);
            Grid.SetRow(planeten, 8);
            Grid.SetColumn(planeten, 7);
            Grid.SetColumnSpan(planeten, 5);
            Grid.SetRowSpan(planeten, 6);
            grid.Children.Add(planeten);
        }        
        // thema 6 = shapes
        private void Theme6()
        {
            shapes.Source = new BitmapImage(new Uri("Images/banners/vormenbanner.png", UriKind.Relative));
            shapes.MouseDown += new MouseButtonEventHandler(SelectThema);
            Grid.SetRow(shapes, 12);
            Grid.SetColumn(shapes, 7);
            Grid.SetColumnSpan(shapes, 5);
            Grid.SetRowSpan(shapes, 6);
            grid.Children.Add(shapes);
        }



        /// <summary>
        /// hier wordt gekeken welke optie je hebt aangedrukt en welke thema hij dus moet laden
        /// </summary>
        private static string thema;

        public void SelectThema(object sender, RoutedEventArgs e)
        {
            
            if (sender == logo)
            {
                thema = "logos";
            }else if (sender == gebouwen)
            {
                thema = "gebouwen"; 
            }else if(sender == disney)
            {
                thema = "disney";
            }else if(sender == autos)
            {
                thema = "autos";
            }
            else if (sender == planeten)
            {
                thema = "planeten";
            }
            else if (sender == shapes)
            {
                thema = "shapes";
            }
            var nieuwSpel = new GameWindow( thema  ); //create your new form.
            nieuwSpel.Show(); //show the new form.
            window.Close();  //only if you want to close the current form.
        }



        //Back button (to select)//
        public void AddBack()
        {
            Button Back = new Button
            {
                Content = "Back",
                FontSize = 40,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(3),
                FontFamily = new FontFamily("Bahnschrift"),
                Background = new RadialGradientBrush(Colors.White, Colors.LightSteelBlue),
            };

            Grid.SetRow(Back, 18);
            Grid.SetRowSpan(Back, 4);
            Grid.SetColumn(Back, 11);
            Grid.SetColumnSpan(Back, 2);
            grid.Children.Add(Back);
            Back.Click += Back_Click1;
        }

        public void Back_Click1(object sender, RoutedEventArgs e)
        { // functie om naar de vorige pagina te gaan
            var SelectScherm = new SelectOptions(MainClass.aantalSpelers); //create your new form.
            SelectScherm.Show(); //show the new form.
            window.Close();
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
