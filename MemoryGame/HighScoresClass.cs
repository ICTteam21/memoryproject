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
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;


namespace MemoryGame
{
    class HighScoresClass
    {
        private Grid grid;

        string pathing;
        string path1;

        Grid highscores1 = new Grid();
        Grid highscores2 = new Grid();
        Grid highscores3 = new Grid();
        Grid highscores4 = new Grid();
        Grid highscores5 = new Grid();
        Grid highscores6 = new Grid();
        Grid highscores7 = new Grid();
        Grid highscores8 = new Grid();
        Label highscoretitle = new Label();


        private HighScores window;


        public HighScoresClass(HighScores window, Grid grid, int kolommen, int rijen)
        {
            if (MainClass.windowstate == 2)
            { window.WindowState = WindowState.Maximized; }
            else
            { window.WindowState = WindowState.Normal; }
            this.window = window;
            this.grid = grid;

            InitializeMain(kolommen, rijen);

            padnaarscores(); //roept een methode op die de huidige locatie van het document ophaalt en aanpast.

            AddBack(); //voegt een back button toe.

            labelhighscores(); //voegt een title toe.

            sp(); //maakt 8 grids aan.

            exceldata();
        }

        /// <summary>
        /// Deze code voorziet de pagina van een hoofdgrid.
        /// </summary>
        /// <param name="kolommen"></param> Het aantal kolommen.
        /// <param name="rijen"></param>    Het aantal rijen.
        public void InitializeMain(int kolommen, int rijen)
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

        /// <summary>
        /// De code die de backbutton toevoegt.
        /// </summary>
        public void AddBack()
        {
            Button Back = new Button();
            Back.Content = "Back";
            Back.FontSize = 18;
            //startgame.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(Back, 9);
            Grid.SetColumn(Back, 9);
            Grid.SetColumnSpan(Back, 2);
            Grid.SetRowSpan(Back, 1);
            grid.Children.Add(Back);
            Back.Click += Back_Click1;
        }

        /// <summary>
        /// Dit is de click functie van de back button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Back_Click1(object sender, RoutedEventArgs e)
        {
            var SelectScherm = new MainMenuWindow(); //create your new form.
            SelectScherm.Show(); //show the new form.
            window.Close();
        }

        /// <summary>
        /// Dit is de HoofdTitle.
        /// </summary>
        private void labelhighscores()
        {
            highscoretitle.Content = "Highscores";
            highscoretitle.FontSize = 40;
            highscoretitle.BorderThickness = new Thickness(2);
            highscoretitle.BorderBrush = Brushes.Black;
            highscoretitle.HorizontalContentAlignment = HorizontalAlignment.Center;
            highscoretitle.VerticalContentAlignment = VerticalAlignment.Center;


            Grid.SetRow(highscoretitle, 0);
            Grid.SetColumn(highscoretitle, 2);
            Grid.SetColumnSpan(highscoretitle, 5);
            grid.Children.Add(highscoretitle);

        }

        /// <summary>
        /// Dit maakt en vult alle grids.
        /// </summary>
        public void sp()
        {

            Grid.SetRow(highscores1, 2);
            Grid.SetColumn(highscores1, 1);
            Grid.SetRowSpan(highscores1, 3);
            for (int i = 0; i < 7; i++)
            {
                highscores1.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < 3; i++)
            {
                highscores1.ColumnDefinitions.Add(new ColumnDefinition());
            }
            grid.Children.Add(highscores1);


            Grid.SetRow(highscores2, 2);
            Grid.SetColumn(highscores2, 3);
            Grid.SetRowSpan(highscores2, 3);
            for (int i = 0; i < 7; i++)
            {
                highscores2.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < 3; i++)
            {
                highscores2.ColumnDefinitions.Add(new ColumnDefinition());
            }
            grid.Children.Add(highscores2);

            Grid.SetRow(highscores3, 2);
            Grid.SetColumn(highscores3, 5);
            Grid.SetRowSpan(highscores3, 3);
            for (int i = 0; i < 7; i++)
            {
                highscores3.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < 3; i++)
            {
                highscores3.ColumnDefinitions.Add(new ColumnDefinition());
            }
            grid.Children.Add(highscores3);

            Grid.SetRow(highscores4, 2);
            Grid.SetColumn(highscores4, 7);
            Grid.SetRowSpan(highscores4, 3);
            for (int i = 0; i < 7; i++)
            {
                highscores4.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < 3; i++)
            {
                highscores4.ColumnDefinitions.Add(new ColumnDefinition());
            }
            grid.Children.Add(highscores4);

            Grid.SetRow(highscores5, 5);
            Grid.SetColumn(highscores5, 1);
            Grid.SetRowSpan(highscores5, 3);
            for (int i = 0; i < 7; i++)
            {
                highscores5.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < 3; i++)
            {
                highscores5.ColumnDefinitions.Add(new ColumnDefinition());
            }
            grid.Children.Add(highscores5);

            Grid.SetRow(highscores6, 5);
            Grid.SetColumn(highscores6, 3);
            Grid.SetRowSpan(highscores6, 3);
            for (int i = 0; i < 7; i++)
            {
                highscores6.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < 3; i++)
            {
                highscores6.ColumnDefinitions.Add(new ColumnDefinition());
            }
            grid.Children.Add(highscores6);

            Grid.SetRow(highscores7, 5);
            Grid.SetColumn(highscores7, 5);
            Grid.SetRowSpan(highscores7, 3);
            for (int i = 0; i < 7; i++)
            {
                highscores7.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < 3; i++)
            {
                highscores7.ColumnDefinitions.Add(new ColumnDefinition());
            }
            grid.Children.Add(highscores7);

            Grid.SetRow(highscores8, 5);
            Grid.SetColumn(highscores8, 7);
            Grid.SetRowSpan(highscores8, 3);
            for (int i = 0; i < 7; i++)
            {
                highscores8.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < 3; i++)
            {
                highscores8.ColumnDefinitions.Add(new ColumnDefinition());
            }
            grid.Children.Add(highscores8);

        }

        /// <summary>
        /// Dit vult alle data in de grids in.
        /// </summary>
        /// <param name="naam"></param>     Is de naam van de speler
        /// <param name="sheetnr"></param>  Is het grid/sheet nummer
        /// <param name="size"></param>     Is de fontsize
        /// <param name="score"></param>    Is de score
        /// <param name="nummer"></param>   Is het rijnummer
        public void labelspdata(string naam,int sheetnr,int size,double score,int nummer,string tijdsduur)
        {
            Label speler = new Label();
            speler.Content = naam;
            speler.FontSize = size;
            speler.VerticalContentAlignment = VerticalAlignment.Top;

            Label puntjes = new Label();
            puntjes.Content = score;
            puntjes.FontSize = size;
            puntjes.HorizontalContentAlignment = HorizontalAlignment.Center;
            puntjes.VerticalContentAlignment = VerticalAlignment.Top;

            Label tijdsduratie = new Label();
            tijdsduratie.Content = tijdsduur;
            tijdsduratie.FontSize = size;
            tijdsduratie.HorizontalContentAlignment = HorizontalAlignment.Center;
            tijdsduratie.VerticalContentAlignment = VerticalAlignment.Top;

            Grid.SetRow(speler, nummer);
            Grid.SetColumn(speler, 0);
            Grid.SetRow(puntjes, nummer);
            Grid.SetColumn(puntjes, 1);
            Grid.SetRow(tijdsduratie, nummer);
            Grid.SetColumn(tijdsduratie, 2);


            switch (sheetnr)
            {
                case 1:
                    highscores1.Children.Add(speler);
                    highscores1.Children.Add(puntjes);
                    highscores1.Children.Add(tijdsduratie);
                    break;
                case 2:
                    highscores2.Children.Add(speler);
                    highscores2.Children.Add(puntjes);
                    highscores2.Children.Add(tijdsduratie);
                    break;
                case 3:
                    highscores3.Children.Add(speler);
                    highscores3.Children.Add(puntjes);
                    highscores3.Children.Add(tijdsduratie);
                    break;
                case 4:
                    highscores4.Children.Add(speler);
                    highscores4.Children.Add(puntjes);
                    highscores4.Children.Add(tijdsduratie);
                    break;
                case 5:
                    highscores5.Children.Add(speler);
                    highscores5.Children.Add(puntjes);
                    highscores5.Children.Add(tijdsduratie);
                    break;
                case 6:
                    highscores6.Children.Add(speler);
                    highscores6.Children.Add(puntjes);
                    highscores6.Children.Add(tijdsduratie);
                    break;
                case 7:
                    highscores7.Children.Add(speler);
                    highscores7.Children.Add(puntjes);
                    highscores7.Children.Add(tijdsduratie);
                    break;
                case 8:
                    highscores8.Children.Add(speler);
                    highscores8.Children.Add(puntjes);
                    highscores8.Children.Add(tijdsduratie);
                    break;
            }
        }

        //Voegt in de grid de rij toe met Naam en Punten.
        public void labelsptitles2(string naam, int sheetnr, int size, string punten, int nummer,string tijdsduur)
        {
            Label speler = new Label();
            speler.Content = naam;
            speler.FontSize = size;

            Label puntjes = new Label();
            puntjes.Content = punten;
            puntjes.FontSize = size;
            puntjes.HorizontalContentAlignment = HorizontalAlignment.Center;

            Label tijdsduratie = new Label();
            tijdsduratie.Content = tijdsduur;
            tijdsduratie.FontSize = size;
            tijdsduratie.HorizontalContentAlignment = HorizontalAlignment.Center;

            Grid.SetRow(speler, nummer);
            Grid.SetColumn(speler, 0);
            Grid.SetRow(puntjes, nummer);
            Grid.SetColumn(puntjes, 1);
            Grid.SetRow(tijdsduratie, nummer);
            Grid.SetColumn(tijdsduratie, 2);

            switch (sheetnr)
            {
                case 1:
                    highscores1.Children.Add(speler);
                    highscores1.Children.Add(puntjes);
                    highscores1.Children.Add(tijdsduratie);
                    break;
                case 2:
                    highscores2.Children.Add(speler);
                    highscores2.Children.Add(puntjes);
                    highscores2.Children.Add(tijdsduratie);
                    break;
                case 3:
                    highscores3.Children.Add(speler);
                    highscores3.Children.Add(puntjes);
                    highscores3.Children.Add(tijdsduratie);
                    break;
                case 4:
                    highscores4.Children.Add(speler);
                    highscores4.Children.Add(puntjes);
                    highscores4.Children.Add(tijdsduratie);
                    break;
                case 5:
                    highscores5.Children.Add(speler);
                    highscores5.Children.Add(puntjes);
                    highscores5.Children.Add(tijdsduratie);
                    break;
                case 6:
                    highscores6.Children.Add(speler);
                    highscores6.Children.Add(puntjes);
                    highscores6.Children.Add(tijdsduratie);
                    break;
                case 7:
                    highscores7.Children.Add(speler);
                    highscores7.Children.Add(puntjes);
                    highscores7.Children.Add(tijdsduratie);
                    break;
                case 8:
                    highscores8.Children.Add(speler);
                    highscores8.Children.Add(puntjes);
                    highscores8.Children.Add(tijdsduratie);
                    break;
            }
        }

        //Voegt de hoofdtitle aan de Grids toe.
        public void labelsptitles1(string naam, int sheetnr, int size, int nummer)
        {
            Label categorie = new Label();
            categorie.Content = naam;
            categorie.FontSize = size;
            Grid.SetRow(categorie, nummer);
            Grid.SetColumn(categorie, 0);
            Grid.SetColumnSpan(categorie, 3);
            categorie.BorderThickness = new Thickness(1);
            categorie.BorderBrush = Brushes.Black;
            categorie.HorizontalContentAlignment = HorizontalAlignment.Center;
            categorie.VerticalContentAlignment = VerticalAlignment.Center;

            switch (sheetnr)
            {
                case 1:
                    highscores1.Children.Add(categorie);
                    break;
                case 2:
                    highscores2.Children.Add(categorie);
                    break;
                case 3:
                    highscores3.Children.Add(categorie);
                    break;
                case 4:
                    highscores4.Children.Add(categorie);
                    break;
                case 5:
                    highscores5.Children.Add(categorie);
                    break;
                case 6:
                    highscores6.Children.Add(categorie);
                    break;
                case 7:
                    highscores7.Children.Add(categorie);
                    break;
                case 8:
                    highscores8.Children.Add(categorie);
                    break;

            }
        }

        /// <summary>
        /// Dit haalt de gewenste highscore data uit Excel.
        /// </summary>
        public void exceldata()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string naam;
            double punten;
            double tijdsduur2;
            string tijdsduur;
            int rCnt;

            //Dit stukje opent een nieuwe excel app.
            xlApp = new Excel.Application();
            //Hier opent het mijn excel workbook.
            xlWorkBook = xlApp.Workbooks.Open(path1, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            //Vult alle 8 stackpanels met de top 5 scores.
            for (int i = 1; i < 9; i++)
            {


                double rw = 0;
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(i);
                //Hier set het de range op het gebruikte range(dus waar dingen staan).
                range = xlWorkSheet.UsedRange;

                var usedRows = xlApp.WorksheetFunction.CountA(xlWorkSheet.Columns[1]);

                //Zorgt ervoor dat het aantal scores maximaal 5 is.
                if(usedRows > 7)
                {
                    rw = 7;
                    
                }
                else
                {
                    rw = usedRows;
                }


                //voegt title toe aan een stackpanel.
                string sptitle = (string)(range.Cells[1, 1] as Excel.Range).Value2;
                labelsptitles1(sptitle, i, 16, 0);

                //voegt tabelkopjes toe aan een stackpanel.
                sptitle = (string)(range.Cells[2, 1] as Excel.Range).Value2;
                naam = (string)(range.Cells[2, 2] as Excel.Range).Value2;
                tijdsduur = (string)(range.Cells[2, 3] as Excel.Range).Value2;

                labelsptitles2(sptitle , i, 16, naam , 1, tijdsduur);

                //Loop die stackpanels vult met highscores.
                for (rCnt = 3; rCnt <= rw; rCnt++)
                {
                    int rij = rCnt - 1;

                    naam = (string)(range.Cells[rCnt, 1] as Excel.Range).Text;
                    punten = (double)(range.Cells[rCnt, 2] as Excel.Range).Value2;
                    tijdsduur2 = (double)(range.Cells[rCnt, 3] as Excel.Range).Value2;

                    string sDate = (range.Cells[rCnt, 3] as Excel.Range).Value2.ToString();
                    double date = double.Parse(sDate);
                    var dateTime = DateTime.FromOADate(date).ToLongTimeString();

                    labelspdata(naam, i, 16, punten, rij, dateTime);

                }
                Marshal.ReleaseComObject(xlWorkSheet);
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

        }

        /// <summary>
        /// Zoekt het huidige pad op en past deze aan.
        /// </summary>
        public void padnaarscores()
        {
            pathing = System.AppDomain.CurrentDomain.BaseDirectory;
            path1 = pathing.Replace("bin", "Statistics");
            path1 = path1.Replace("Debug", "Highscorestats");
            path1 = path1 + "/HighscoresMemory.xlsx";
        }



    }
}
